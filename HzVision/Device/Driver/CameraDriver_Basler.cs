using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;
using ProCommon.Communal;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       CameraDriver_Basler
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProDriver.Driver
 * File      Name：       CameraDriver_Basler
 * Creating  Time：       10/30/2019 5:58:32 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProDriver.Driver
{
    public class CameraDriver_Basler:CamDriver
    {
        /// <summary>
        /// if >= Sfnc2_0_0,说明是ＵＳＢ３的相机
        /// </summary>
        public static Version SFNC2_0_0 = new Version(2, 0, 0);
        private List<Basler.Pylon.ICameraInfo> _deviceList;
        private Basler.Pylon.Camera _device;

        private long _imageWidth = 0;         // 图像宽
        private long _imageHeight = 0;        // 图像高
        private System.Diagnostics.Stopwatch _stopWatch;
        private IntPtr _latestFrameAddress = IntPtr.Zero;
        private Basler.Pylon.PixelDataConverter _converter;//像素格式转换
        private HalconDotNet.HObject _hPylonImage = null;

        private bool _isBandedCameraEvent;

        public override event CameraImageGrabbedDel CameraImageGrabbedEvt;

        public CameraDriver_Basler()
        {
            _stopWatch = new System.Diagnostics.Stopwatch();
            _converter = new PixelDataConverter();
            _isBandedCameraEvent = false;
        }

        public CameraDriver_Basler(ProCommon.Communal.Camera cam)
            : this()
        {
            Camera = cam;
        }

        private void DeviceStreamGrabber_ImageGrabbedEvent(object sender, ImageGrabbedEventArgs e)
        {
            Basler.Pylon.IGrabResult grabResult = e.GrabResult;
            if (grabResult.GrabSucceeded)
            {
                Basler.Pylon.PixelType pixelType = grabResult.PixelTypeValue;
                if (pixelType == Basler.Pylon.PixelType.Mono8)
                {
                    //allocate the m_stream_size amount of bytes in non-managed environment 
                    if (_latestFrameAddress == IntPtr.Zero)
                    {
                        _latestFrameAddress = System.Runtime.InteropServices.Marshal.AllocHGlobal((Int32)grabResult.PayloadSize);
                    }

                    _converter.OutputPixelFormat = Basler.Pylon.PixelType.Mono8;
                    _converter.Convert(_latestFrameAddress, grabResult.PayloadSize, grabResult);
                    HalconDotNet.HOperatorSet.GenImage1(out HoImage, "byte", (HalconDotNet.HTuple)grabResult.Width, (HalconDotNet.HTuple)grabResult.Height, (HalconDotNet.HTuple)_latestFrameAddress);
                }
                else if (grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerBG8
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerGB8
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerRG8
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerGR8
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerRG12Packed
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.YUV422packed
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.YUV422_YUYV_Packed
                         || grabResult.PixelTypeValue == Basler.Pylon.PixelType.BayerRG12
                         )
                {
                    if (_latestFrameAddress == IntPtr.Zero)
                    {
                        _latestFrameAddress = System.Runtime.InteropServices.Marshal.AllocHGlobal((Int32)(3 * grabResult.Width * grabResult.Height));
                    }

                    _converter.OutputPixelFormat = Basler.Pylon.PixelType.BGR8packed;// 根据bayer格式不同切换以下代码                       
                    _converter.Convert(_latestFrameAddress, 3 * grabResult.Width * grabResult.Height, grabResult);
                    HalconDotNet.HOperatorSet.GenImageInterleaved(out HoImage, _latestFrameAddress, "bgr", (HalconDotNet.HTuple)_imageWidth, (HalconDotNet.HTuple)_imageHeight, -1, "byte", (HalconDotNet.HTuple)_imageWidth, (HalconDotNet.HTuple)_imageHeight, 0, 0, -1, 0);
                }

                System.Runtime.InteropServices.Marshal.FreeHGlobal(_latestFrameAddress);
                _latestFrameAddress = IntPtr.Zero;


                if (HoImage != null
                        && HoImage.IsInitialized())
                {
                    IsImageGrabbed = true;
                    if (CameraImageGrabbedEvt != null)
                        CameraImageGrabbedEvt(Camera, HoImage);
                }
            }
        }

        private void Device_ConnectionLost(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 枚举在线相机
        /// </summary>
        /// <returns></returns>
        public override bool DoEnumerateCameraList()
        {
            bool rt = false;
            try
            {
                System.GC.Collect();              

                if (_deviceList == null)
                    _deviceList = Basler.Pylon.CameraFinder.Enumerate();

                if (_deviceList != null
                    && _deviceList.Count() > 0)
                    rt = true;
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机枚举设备失败!\n错误代码:{0:X8}", 99));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        public override string[] EnumerateCameraSNList()
        {
            if (_deviceList == null)
                _deviceList = Basler.Pylon.CameraFinder.Enumerate();

            List<string> list = new List<string>();
            if (_deviceList != null)
            {
                for (int i = 0; i < _deviceList.Count; i++)
                {
                    list.Add(_deviceList[i][Basler.Pylon.CameraInfoKey.SerialNumber]);
                }
            }
            return list.ToArray();
        }



        /// <summary>
        /// 计算在线相机数量
        /// </summary>
        /// <returns></returns>
        public override int DoGetCameraListCount()
        {
            return _deviceList.Count();
        }

        /// <summary>
        /// 根据相机索引获取相机
        /// [相机索引号由其上电顺序得来，非固定]
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool DoGetCameraByIdx(int index)
        {
            bool rt = false;
            try
            {
                if (_deviceList != null)
                {
                    if (index >= 0 && index < _deviceList.Count())
                    {
                        foreach (Basler.Pylon.ICameraInfo cameraInfo in _deviceList)
                        {
                            string s = cameraInfo[Basler.Pylon.CameraInfoKey.DeviceIdx];
                            if(!string.IsNullOrEmpty(s))
                            {
                                if (index == System.Convert.ToInt32(s.Substring(2, s.Length - 2), 10))
                                {
                                    _device = new Basler.Pylon.Camera(cameraInfo);
                                    rt = true;
                                    break;
                                }
                            }                           
                        }

                        if (!rt)
                        {
                            if (DriverExceptionDel != null)
                                DriverExceptionDel(string.Format("错误：巴斯勒相机获取设备失败!\n索引:{0}\n异常描述:{1}",
                                   index, "未找到指定索引相机(字符串形式索引)"));
                        }
                    }
                    else
                    {
                        if (DriverExceptionDel != null)
                            DriverExceptionDel(string.Format("错误：巴斯勒相机获取设备失败!\n索引:{0}\n异常描述:{1}",
                                  index, "超出设备索引范围"));
                    }
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机获取索引对应设备失败!\n:{0}",
                               "设备列表为空"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 获取索引指定相机的序列号
        /// </summary>
        /// <param name="index">相机索引</param>
        /// <returns></returns>
        public override string DoGetCameraSN(int index)
        {
            if (DoGetCameraByIdx(index))
            {
                if (!_device.IsConnected)
                    DoOpen();
                return _device.CameraInfo[Basler.Pylon.CameraInfoKey.SerialNumber];
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据相机名称获取相机
        /// </summary>
        /// <param name="camName"></param>
        /// <returns></returns>
        public override bool DoGetCameraByName(string camName)
        {
            bool rt = false;
            try
            {
                if (_deviceList != null)
                {
                    foreach (Basler.Pylon.ICameraInfo cameraInfo in _deviceList)
                    {
                        if (camName == cameraInfo[Basler.Pylon.CameraInfoKey.UserDefinedName])
                        {
                            _device = new Basler.Pylon.Camera(cameraInfo);
                            rt = true;
                            break;
                        }
                    }

                    if (!rt)
                    {
                        if (DriverExceptionDel != null)
                            DriverExceptionDel(string.Format("错误：巴斯勒相机获取设备失败!\n设备名称:{0}\n异常描述{1}",
                                camName, "指定名称不匹配"));
                    }                   
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机获取索引对应设备失败!\n:{0}",
                               "设备列表为空"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 根据相机序列号获取相机
        /// </summary>
        /// <param name="camSN"></param>
        /// <returns></returns>
        public override bool DoGetCameraBySN(string camSN)
        {
            bool rt = false;
            try
            {
                if (_deviceList != null)
                {
                    foreach (Basler.Pylon.ICameraInfo cameraInfo in _deviceList)
                    {
                        if (camSN == cameraInfo[Basler.Pylon.CameraInfoKey.SerialNumber])
                        {
                            _device = new Basler.Pylon.Camera(cameraInfo);
                            rt = true;
                            break;
                        }
                    }
                    if (!rt)
                    {
                        if (DriverExceptionDel != null)
                            DriverExceptionDel(string.Format("错误：巴斯勒相机获取设备失败!\n设备序列号:{0}\n异常描述{1}",
                                camSN, "指定序列号不匹配"));
                    }                   
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机获取索引对应设备失败!\n:{0}",
                               "设备列表为空"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        public override bool DoOpen()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    if(!_device.IsOpen)
                        _device.Open();
                    if (!_isBandedCameraEvent)
                    {
                        _device.StreamGrabber.ImageGrabbed += DeviceStreamGrabber_ImageGrabbedEvent;                 // 绑定采集回调函数
                        _device.ConnectionLost += Device_ConnectionLost;
                        _isBandedCameraEvent = true;
                    }

                    if(_device.GetSfncVersion()<SFNC2_0_0)
                    {
                        _imageWidth = _device.Parameters[Basler.Pylon.PLCamera.Width].GetValue();               // 获取图像宽 
                        _imageHeight = _device.Parameters[Basler.Pylon.PLCamera.Height].GetValue();             // 获取图像高  
                    }
                    else
                    {
                        _imageWidth = _device.Parameters[Basler.Pylon.PLUsbCamera.Width].GetValue();
                        _imageHeight = _device.Parameters[Basler.Pylon.PLUsbCamera.Height].GetValue();
                    }                                   

                    rt = true; 
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机打开失败!\n:{0}",
                        "设备未连接"));
                }
            }
            catch (System.Exception ex)           
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机打开失败!\n错误描述:{0}",
                       ex.Message));
            }
            finally
            {

            }

            return rt;
        }      

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public override bool DoClose()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    SetFreeRun();
                    _device.Close();
                    _device.Dispose();
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机关闭失败!\n:{0}",
                        "设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机关闭失败!\n错误描述:{0}",
                       ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 方法：设置采集模式
        /// </summary>
        /// <param name="acqmode"></param>
        /// 0-连续采集，触发采集[1-单帧模式，2-多帧模式]
        /// <param name="frameNum">
        /// 多帧模式下的帧数</param>
        /// <returns></returns>
        public override bool DoSetAcquisitionMode(ProCommon.Communal.AcquisitionMode acqmode, uint frameNum)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    if (_device.StreamGrabber.IsGrabbing)
                        DoStopGrab();
                    switch (acqmode)
                    {
                        case AcquisitionMode.Continue:   
                            if (SetFreeRun())
                                rt = SetContinueRun();
                            break;
                        case AcquisitionMode.ExternalTrigger:                 
                            {
                                if (SetExternalTrigger())
                                    rt = SetFrameNumber(frameNum);
                                rt = true;
                            }
                            break;
                        case AcquisitionMode.SoftTrigger:   
                            {
                                if (SetInternalTrigger())
                                    rt=SetFrameNumber(frameNum);                               
                            }
                            break;
                        default: break;
                    }
                }
                else
                { 
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "设备未连接"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 自由采集模式
        /// [不采集]
        /// </summary>
        /// <returns></returns>
        private bool SetFreeRun()
        {
            bool rt = false;
            if (_device.GetSfncVersion() < SFNC2_0_0)
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);                        
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);                       
                    }
                    rt = true;
                }
                else
                {                   
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            else
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);                       
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);                       
                    }
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备自由采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            if (rt) _stopWatch.Reset();
            return rt;
        }

        /// <summary>
        /// 连续采集模式
        /// </summary>
        /// <returns></returns>
        private bool SetContinueRun()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    _device.Parameters[Basler.Pylon.PLCamera.AcquisitionMode].TrySetValue(PLCamera.AcquisitionMode.Continuous);
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置连续采集失败!\n:{0}", "设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置连续采集失败!\n错误描述:{0}", ex.Message));
            }
            finally
            {

            }
            return rt;
        }

        /// <summary>
        /// 设置内部触发采集(软触发)
        /// </summary>
        /// <returns></returns>
        private bool SetInternalTrigger()
        {
            bool rt = false;
            if (_device.GetSfncVersion() < SFNC2_0_0)
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Software);
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Software);
                    }
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            else
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Software);
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Software);
                    }
                    rt = true; 
                }
                else
                {                  
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            if(rt) _stopWatch.Reset();
            return rt;
        }

        /// <summary>
        /// 设置外部触发采集(硬触发)
        /// </summary>
        /// <returns></returns>
        private bool SetExternalTrigger()
        {
            bool rt = false;
            if (_device.GetSfncVersion() < SFNC2_0_0)
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Line1);
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.AcquisitionStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Line1);
                    }

                    //Sets the absolute value of the selected line debouncer time in microseconds
                    _device.Parameters[Basler.Pylon.PLCamera.LineSelector].TrySetValue(PLCamera.LineSelector.Line1);
                    _device.Parameters[PLCamera.LineMode].TrySetValue(PLCamera.LineMode.Input);
                    _device.Parameters[PLCamera.LineDebouncerTimeAbs].SetValue(3);       // 设置去抖延时，过滤触发信号干扰
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            else
            {
                if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart))
                {
                    if (_device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart))
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.Off);

                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Line1);
                    }
                    else
                    {
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSelector].TrySetValue(Basler.Pylon.PLCamera.TriggerSelector.FrameBurstStart);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerMode].TrySetValue(Basler.Pylon.PLCamera.TriggerMode.On);
                        _device.Parameters[Basler.Pylon.PLCamera.TriggerSource].TrySetValue(Basler.Pylon.PLCamera.TriggerSource.Line1);
                    }

                    //Sets the absolute value of the selected line debouncer time in microseconds
                    _device.Parameters[Basler.Pylon.PLCamera.LineSelector].TrySetValue(PLCamera.LineSelector.Line1);
                    _device.Parameters[PLCamera.LineMode].TrySetValue(PLCamera.LineMode.Input);
                    _device.Parameters[PLCamera.LineDebouncerTime].SetValue(0);       // 设置去抖延时，过滤触发信号干扰                 

                    rt = true;                    
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备采集模式失败!\n:{0}", "获取配置采集开启的触发器异常"));
                }
            }
            if (rt) _stopWatch.Reset();
            return rt;
        }

        /// <summary>
        /// 设置触发采集时的帧数
        /// </summary>
        /// <param name="frameNum"></param>
        /// <returns></returns>
        private bool SetFrameNumber(uint frameNum)
        {
            bool rt = false;
            try
            {
                if (frameNum == 1)
                {
                    //_device.Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                    rt = true;

                }
                else
                {
                    //_device.Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.MultiFrame);
                    rt = true;
                }
                rt = true;
            }catch(Exception ex)
            {

            }
           
            return rt;
        }

        /// <summary>
        /// 方法：设置触发模式(开启/关闭)
        /// </summary>
        /// <param name="mode">0-关闭，1-开启</param>
        /// <returns></returns>
        public bool DoEnableTriggerMode(bool onoff)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    rt = true;//巴斯勒相机设置触发模式(是指外触发),且在切换采集模式时已经完成启动
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备触发模式失败!\n:{0}", "设备未连接"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 方法：设置触发源
        /// 0-Line0,1-Line1,2-Line2,3-Line3,4-Counter,7-Software
        /// </summary>
        /// <param name="srcCode">触发源</param>
        /// <returns></returns>
        public bool DoSetTriggerSource(int srccode)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    rt = true;//巴斯勒相机设置触发源(是指外触发),且在切换采集模式时已经完成启动
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备触发源失败!\n:{0}","设备未连接"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 方法:设置触发信号边缘
        /// [注:用于触发源为硬触发]
        /// </summary>
        /// <param name="dege">边缘信号</param>
        /// <returns></returns>
        public override bool DoSetTriggerActivation(ProCommon.Communal.TriggerLogic edge)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    switch (edge)
                    {
                        case TriggerLogic.FallEdge: 
                            _device.Parameters[Basler.Pylon.PLCamera.TriggerActivation].TrySetValue(Basler.Pylon.PLCamera.TriggerActivation.FallingEdge);
                            rt = true;
                            break;
                        case TriggerLogic.LogicFalse:          
                            //注意此处巴斯勒用的是高低电平，非有效逻辑或无效逻辑(按照国内习惯,高电平为无效电平)
                            _device.Parameters[Basler.Pylon.PLCamera.TriggerActivation].TrySetValue(Basler.Pylon.PLCamera.TriggerActivation.LevelHigh);
                            rt = true;
                            break;
                        case TriggerLogic.LogicTrue:    
                            //注意此处巴斯勒用的是高低电平，非有效逻辑或无效逻辑(按照国内习惯,低电平为有效电平)
                            _device.Parameters[Basler.Pylon.PLCamera.TriggerActivation].TrySetValue(Basler.Pylon.PLCamera.TriggerActivation.LevelLow);
                            rt = true;
                            break;
                        case TriggerLogic.RaiseEdge:      
                            _device.Parameters[Basler.Pylon.PLCamera.TriggerActivation].TrySetValue(Basler.Pylon.PLCamera.TriggerActivation.RisingEdge);
                            rt = true;
                            break;
                        default:break;
                    }                  
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置设备触发信号边沿失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 开启采集
        /// </summary>
        /// <returns></returns>
        public override bool DoStartGrab()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    _device.StreamGrabber.Start(Basler.Pylon.GrabStrategy.LatestImages, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);                   
                     _stopWatch.Restart();    // ****  重启采集时间计时器   ****
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机开启采集失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机开启采集失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 暂停采集
        /// </summary>
        /// <returns></returns>
        public override bool DoPauseGrab()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    rt = true; //巴斯勒相机暂停采集(无此功能)
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机暂停采集失败!\n:{0}","设备未连接"));
                }
            }
            catch
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <returns></returns>
        public override bool DoStopGrab()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    if (_device.StreamGrabber.IsGrabbing)
                    {
                        _device.StreamGrabber.Stop();
                    }
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机停止采集失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机停止采集失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 软触发一次
        /// </summary>
        /// <returns></returns>
        public override bool DoSoftTriggerOnce()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    //if (_device.WaitForFrameTriggerReady(2000, Basler.Pylon.TimeoutHandling.ThrowException))
                    {
                        _device.ExecuteSoftwareTrigger();
                        _stopWatch.Restart();
                        rt = true;
                    }
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机单次软触发采集失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机单次软触发采集失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 注册掉线异常回调函数
        /// </summary>
        /// <returns></returns>
        public override bool DoRegisterExceptionCallBack()
        {
            bool rt = false;
            try
            {
                rt = true; //巴斯勒相机断线重连功能待续
            }
            catch (System.Exception ex)
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 注册图像采集到回调函数
        /// </summary>
        /// <returns></returns>
        public override bool DoRegisterImageGrabbedCallBack()
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    rt = true; //巴斯勒相机图像采集到事件绑定即可
                }
                else
                {                  
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机注册图像采集到事件失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机注册图像采集到事件失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 设置曝光时间
        /// [注:时间单位微秒]
        /// </summary>
        /// <param name="exposuretime"></param>
        /// <returns></returns>
        public override bool DoSetExposureTime(float exposuretime)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    exposuretime *= 10;
                    _device.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Off);
                    _device.Parameters[PLCamera.ExposureMode].TrySetValue(PLCamera.ExposureMode.Timed);
                    if (_device.GetSfncVersion() < SFNC2_0_0)
                    {                       
                        _device.Parameters[PLCamera.ExposureTimeAbs].SetValue((long)exposuretime);
                    }
                    else
                    {
                        _device.Parameters[PLCamera.ExposureTime].SetValue((double)exposuretime);
                    }                                        
                    rt = true;                   
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置曝光时间失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置曝光时间失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 设置帧率
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public override bool DoSetFrameRate(float fps)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    
                    if (_device.GetSfncVersion() < SFNC2_0_0)
                    {
                        _device.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue((double)fps);
                    }
                    else
                    {
                        _device.Parameters[PLCamera.AcquisitionFrameRate].SetValue((double)fps);                       
                    }
                    _device.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置帧率失败!\n:{0}","设备未连接"));
                }               
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置帧率失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gain"></param>
        /// <returns></returns>
        public override bool DoSetGain(float gain)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    _device.Parameters[PLCamera.GainAuto].TrySetValue(PLCamera.GainAuto.Off);
                    if (_device.GetSfncVersion() < SFNC2_0_0)
                    {
                        _device.Parameters[PLCamera.GainRaw].SetValue((long)gain);
                    }
                    else
                    {
                        _device.Parameters[PLUsbCamera.Gain].SetValue((double)gain);
                    }
                    
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置增益失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置增益败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 设置触发延时
        /// </summary>
        /// <param name="trigdelay"></param>
        /// <returns></returns>
        public override bool DoSetTriggerDelay(float trigdelay)
        {
            bool rt = false;
            try
            {
                if (_device != null)
                {
                    _device.Parameters[Basler.Pylon.PLCamera.TriggerDelay].SetValue(trigdelay);  //Sets the trigger delay time in microseconds.//float
                    _device.Parameters[Basler.Pylon.PLCamera.LineSelector].TrySetValue(PLCamera.LineSelector.Line1);//Sets the absolute value of the selected line debouncer time in microseconds
                    _device.Parameters[Basler.Pylon.PLCamera.LineMode].TrySetValue(PLCamera.LineMode.Input);
                    _device.Parameters[Basler.Pylon.PLCamera.LineDebouncerTime].SetValue(5);       // 设置去抖延时，过滤触发信号干扰
                    rt = true;
                }
                else
                {
                    if (DriverExceptionDel != null)
                        DriverExceptionDel(string.Format("错误：巴斯勒相机设置触发延迟时间失败!\n:{0}","设备未连接"));
                }
            }
            catch (System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置触发延迟时间失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 设置相机的输出信号
        /// </summary>
        /// <param name="onOff"></param>
        /// <returns></returns>
        public override bool DoSetOutPut(bool onOff)
        {
            bool rt = false;
            try
            {
                if(_device!=null)
                {
                    _device.Parameters[Basler.Pylon.PLCamera.UserOutputValue].SetValue(onOff);
                    rt = true;
                }
            }catch(System.Exception ex)
            {
                if (DriverExceptionDel != null)
                    DriverExceptionDel(string.Format("错误：巴斯勒相机设置输出信号失败!\n错误描述:{0}",ex.Message));
            }
            finally
            {
            }
            return rt;
        }

        /// <summary>
        /// 创建参数设置窗口
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <param name="promption"></param>
        /// <returns></returns>
        public override bool DoCreateCameraSetPage(System.IntPtr windowHandle, string promption)
        {
            bool rt = false;
            try
            {

            }
            catch (System.Exception ex)
            {

            }
            finally
            {

            }

            return rt;
        }

        /// <summary>
        /// 显示参数设置窗口
        /// </summary>
        /// <returns></returns>
        public override bool DoShowCameraSetPage()
        {
            bool rt = false;
            try
            {

            }
            catch (System.Exception ex)
            {

            }
            finally
            {

            }

            return rt;
        }

        public override string ToString()
        {
            return "CameraDriver[Basler]";
        }

    
    }
}
