using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*************************************************************************************
 * CLR    Version：       4.0.30319.42000
 * Class     Name：       CameraDriver_DaHua
 * Machine   Name：       DESKTOP-RSTK3M3
 * Name     Space：       ProDriver.Driver
 * File      Name：       CameraDriver_DaHua
 * Creating  Time：       2/22/2020 11:52:11 PM
 * Author    Name：       xYz_Albert
 * Description   ：
 * Modifying Time：
 * Modifier  Name：
*************************************************************************************/

namespace ProDriver.Driver
{
    /// <summary>
    /// 奥普特相机SDK二次包装驱动函数接口
    /// [注:二次包装驱动函数接口待完善
    /// 日期:200-06-20]
    /// </summary>
    class CameraDriver_OPT : CamDriver
    {
        StringBuilder ErrorMessage = new StringBuilder();

        /// <summary>
        /// 覆写抽象事件
        /// </summary>
        public override event CameraImageGrabbedDel CameraImageGrabbedEvt; //图像抓取到事件(统一事件)

        System.Collections.Generic.List<ThridLibray.IDeviceInfo> _deviceInfoList;  //设备描述信息列表
        private ThridLibray.IDeviceInfo _deviceInfo;                               //当前设备描述信息
        private ThridLibray.IDevice _deviceRef;                                    //当前设备的资源引用  

        private string _trigSrc;                                                   //触发源:Software,Line1,Line2;且Line1与Line2会影响IOLine2的模式

        //--------------------------------------------------------------------------------------------------------------------------------------

        //--OPT相机彩色相机可以正常切换采集模式,或者设置关闭触发、设置单次触发采集帧数等功能函数;而对于黑白相机则在切换采集模式后,关闭触发模式失败,
        //--设置单次触发采集帧数等功能失败,因此统一在关闭相机的采集流之后再设置功能函数,这个时候需要重新进行SDK图像采集到事件的注册.故此定义了以下两个标记

        /// <summary>
        /// 是否注册过SDK图像采集到事件的回调
        /// </summary>
        private bool _isRegisterImageCallBack;

        /// <summary>
        /// 是否注册过SDK相机断连事件的回调
        /// </summary>
        private bool _isRegisterCameraLostCallBack;

        //-------------------------------------------------------------------------------------------------------------------------------------

        public CameraDriver_OPT(ProCommon.Communal.Camera cam)
        {
            _trigSrc = ThridLibray.TriggerSourceEnum.Line1;
            _isRegisterImageCallBack = false;
            _isRegisterCameraLostCallBack = false;
            Camera = cam;
        }


        /// <summary>
        /// SDK图像采集到事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StreamGrabber_ImageGrabbed(object sender, ThridLibray.GrabbedEventArgs e)
        {
            if (HoImage != null
              && HoImage.IsInitialized())
            {
                HoImage.Dispose();
                //System.Threading.Thread.Sleep(10);
                //System.GC.Collect();
                //System.GC.WaitForPendingFinalizers();
                IsImageGrabbed = false;
            }

            #region OPT相机SDK内部像素格式转换
            ThridLibray.IGrabbedRawData frame = e.GrabResult.Clone();
            if(frame!=null)
            {
                System.Drawing.Bitmap btmp=null;
                if (frame.PixelFmt==ThridLibray.GvspPixelFormatType.gvspPixelMono8
                    || frame.PixelFmt == ThridLibray.GvspPixelFormatType.gvspPixelMono10)
                    btmp = frame.ToBitmap(false);
                else if(frame.PixelFmt == ThridLibray.GvspPixelFormatType.gvspPixelRGB8
                    || frame.PixelFmt == ThridLibray.GvspPixelFormatType.gvspPixelRGB10)
                {
                    btmp = frame.ToBitmap(true);
                }

                if(btmp!=null)
                {
                    BitmapToHObject(btmp, out HoImage);
                    btmp.Dispose();
                }
            }

            #endregion

            if (HoImage != null
              && HoImage.IsInitialized())
            {
                IsImageGrabbed = true;
                if (CameraImageGrabbedEvt != null)
                    CameraImageGrabbedEvt(Camera, HoImage);
            }
        }

        /// <summary>
        /// 相机断连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _deviceRef_ConnectionLost(object sender, EventArgs e)
        {

        }

        #region 实现抽象函数

        /// <summary>
        /// 枚举在线相机
        /// </summary>
        /// <returns></returns>
        public override bool DoEnumerateCameraList()
        {
            bool rt = false; string err = null;
            try
            {
                System.GC.Collect();
                _deviceInfoList = ThridLibray.Enumerator.EnumerateDevices();

                if(_deviceInfoList!=null)
                    rt = true;
                else
                {
                    err = "大华相机枚举设备失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }

        public override string[] EnumerateCameraSNList()
        {
            List<string> list = new List<string>();
            try
            {
                _deviceInfoList = ThridLibray.Enumerator.EnumerateDevices();
                if (_deviceInfoList != null)
                {
                    for (int i = 0; i < _deviceInfoList.Count; i++)
                    {
                        string sn = _deviceInfoList[i].SerialNumber;
                        list.Add(sn);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list.ToArray();
        }


        /// <summary>
        /// 计算在线相机数量
        /// </summary>
        /// <returns></returns>
        public override int DoGetCameraListCount()
        {
            int count = 0;
            if(_deviceInfoList!=null)
                count = _deviceInfoList.Count;

            return count;
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
            string err = null;
                   
            try
            {
                if (_deviceInfoList.Count > 0)
                {
                    if (index < _deviceInfoList.Count)
                    {
                        _deviceRef = ThridLibray.Enumerator.GetDeviceByIndex(index);

                        if (_deviceRef != null)
                            rt = true;

                        if (!rt)
                        {
                            err = "大华相机获取设备失败;设备索引异常";
                             ErrorMessage.Clear();ErrorMessage.Append(err);
                        }
                    }
                    else
                    {
                        err = string.Format("大华相机获取设备失败;索引:{0}超出设备索引范围", index);
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取设备失败;设备列表为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }

        /// <summary>
        /// 获取索引指定相机的名称
        /// </summary>
        /// <param name="index">相机索引</param>
        /// <returns></returns>
        public override string DoGetCameraSN(int index)
        {
            string strRT = string.Empty;
            string err = null;

            try
            {
                if (_deviceInfoList!=null
                    && _deviceInfoList.Count > 0)
                {
                    if (index >= 0
                        && (index < _deviceInfoList.Count))
                    {
                        strRT = _deviceInfoList[index].SerialNumber;
                    }
                    else
                    {
                        err = "大华相机获取设备失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取设备失败;设备列表为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return strRT;
        }

        /// <summary>
        /// 根据相机名称获取相机
        /// </summary>
        /// <param name="camName"></param>
        /// <returns></returns>
        public override bool DoGetCameraByName(string camName)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceInfoList!=null
                    && _deviceInfoList.Count > 0)
                {
                    ThridLibray.IDeviceInfo tmpdevice;
                    for (int i = 0; i < _deviceInfoList.Count; i++)
                    {
                        tmpdevice = _deviceInfoList[i];
                        if(tmpdevice.Name== camName)
                        {
                            _deviceInfo = tmpdevice;
                            if (DoGetCameraByIdx(i))
                            {
                                rt = true;
                                break;
                            }
                        }
                    }

                    if (!rt)
                    {
                        err = string.Format("大华相机获取设备失败;设备名称:{0}不匹配", camName);
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取设备失败;设备列表为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }

        /// <summary>
        /// 根据相机SN地址获取相机
        /// </summary>
        /// <param name="camSN"></param>
        /// <returns></returns>
        public override bool DoGetCameraBySN(string camSN)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceInfoList!=null
                    && _deviceInfoList.Count > 0)
                {
                    ThridLibray.IDeviceInfo tmpdevice;
                    for (int i = 0; i < _deviceInfoList.Count; i++)
                    {
                        tmpdevice = _deviceInfoList[i];
                        if (tmpdevice.SerialNumber == camSN)
                        {
                            _deviceInfo = tmpdevice;
                            if (DoGetCameraByIdx(i))
                            {
                                rt = true;
                                break;
                            }
                        }
                    }

                    if (!rt)
                    {                      
                        err = string.Format("大华相机获取设备失败;设备SN:{0}不匹配", camSN);                      
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取设备失败;设备列表为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }

        /// <summary>
        /// 打开设备
        /// </summary>
        /// <returns></returns>
        public override bool DoOpen()
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (!_deviceRef.IsOpen)
                        rt = _deviceRef.Open();

                    if (!rt)
                    {
                        err = "大华相机打开设备失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机打开设备失败,设备为空"; 
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <returns></returns>
        public override bool DoClose()
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (_deviceRef.StreamGrabber != null)
                    {
                        _deviceRef.StreamGrabber.ImageGrabbed -= StreamGrabber_ImageGrabbed; /* 反注册回调 | unregister grab event callback */
                    }
       
                    rt=_deviceRef.ShutdownGrab();                                           /* 停止码流 | stop grabbing */
                    if(rt)
                    {
                        rt=_deviceRef.Close();                                                  /* 关闭相机 | close camera */

                        if (!rt)
                        {
                            err = "大华相机关闭设备失败";
                             ErrorMessage.Clear();ErrorMessage.Append(err);
                        }
                    }
                    else
                    {
                        err = "大华相机关闭设备失败,停止采集异常";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机关闭设备失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 方法：设置采集模式
        /// </summary>
        /// <param name="acqmode"></param>
        /// <param name="lineIdx"></param>
        /// <returns></returns>
        public override bool DoSetAcquisitionMode(ProCommon.Communal.AcquisitionMode acqmode, uint lineIdx)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    switch (acqmode)
                    {
                        case ProCommon.Communal.AcquisitionMode.Continue:
                                rt = SetContinueRun();
                            break;
                        case ProCommon.Communal.AcquisitionMode.ExternalTrigger:
                                rt = SetExternalTrigger(lineIdx, 1);                         
                            break;
                        case ProCommon.Communal.AcquisitionMode.SoftTrigger:
                                rt = SetInternalTrigger(1);                        
                            break;
                        default: break;
                    }
                }
                else
                {
                    err = "大华相机采集模式设置失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 连续采集模式
        /// </summary>
        /// <returns></returns>
        private bool SetContinueRun()
        {
            bool rt = false; string err = null;
            //先关闭流，设置，再开启
            if(DoStopGrab())
            {
                rt = _deviceRef.TriggerSet.Close();//关闭触发采集(开启连续采集)

                if (!rt)
                {
                    err = "大华相机关闭触发采集失败";
                    ErrorMessage.Clear(); ErrorMessage.Append(err);
                }
                else
                {
                    if (DoRegisterImageGrabbedCallBack())
                        rt = DoStartGrab();
                }
            }           
            return rt;
        }

        /// <summary>
        /// 设置内部触发采集(软触发)
        /// 0-Line0,1-Line1,2-Line2,3-Line3,4-Counter,7-Software
        /// </summary>
        /// <returns></returns>
        private bool SetInternalTrigger(uint frameNum)
        {
            bool rt = false; string err = null;
            //先关闭流，设置，再开启
            if (DoStopGrab())
            {
                rt = _deviceRef.TriggerSet.Open(ThridLibray.TriggerSourceEnum.Software); //开启触发模式:软触发
                if (!rt)
                {
                    err = "大华相机内触发源(Software)设置失败";
                    ErrorMessage.Clear(); ErrorMessage.Append(err);
                }
                else
                {
                    if(SetFrameNumber(frameNum))
                        if (DoRegisterImageGrabbedCallBack())
                            rt = DoStartGrab();
                }
            }           
            return rt;
        }      

        /// <summary>
        /// 设置外部触发采集
        /// </summary>
        /// <param name="lineIdx"></param>
        /// <param name="delaytime"></param>
        /// <param name="debouncertime"></param>
        /// <returns></returns>                       
        private bool SetExternalTrigger(uint lineIdx, uint frameNum)
        {
            bool rt = false; string err = null;
            string src = ThridLibray.TriggerSourceEnum.Line1;
            //先关闭流，设置，再开启
            if (DoStopGrab())
            {
                switch (lineIdx)
                {
                    case 2:
                        src = ThridLibray.TriggerSourceEnum.Line2;
                        break;
                    //预留
                    case 3:
                        src = ThridLibray.TriggerSourceEnum.Line3;
                        break;
                    //预留
                    case 4:
                        src = ThridLibray.TriggerSourceEnum.Line4;
                        break;
                    //预留
                    case 5:
                        src = ThridLibray.TriggerSourceEnum.Line5;
                        break;
                    //预留
                    case 6:
                        src = ThridLibray.TriggerSourceEnum.Line6;
                        break;
                    default:
                        src = ThridLibray.TriggerSourceEnum.Line1;
                        break;
                }

                _trigSrc = src;
                rt = _deviceRef.TriggerSet.Open(src);//开启触发模式:外触发

                if (!rt)
                {
                    err = "大华相机外触发源设置失败";
                    ErrorMessage.Clear(); ErrorMessage.Append(err);
                }
                else
                {
                    if (SetFrameNumber(frameNum))
                        if (DoRegisterImageGrabbedCallBack())
                            rt = DoStartGrab();
                }
            }           
            return rt;
        }

        /// <summary>
        /// 设置触发采集时的帧数
        /// </summary>
        /// <param name="frameNum"></param>
        /// <returns></returns>
        private bool SetFrameNumber(uint frameNum)
        {
            bool rt = false; string err = null;
            using (ThridLibray.IIntegraParameter p = _deviceRef.ParameterCollection[new ThridLibray.IntegerName("AcquisitionFrameCount")])
            {
                rt = p.SetValue(frameNum);
            }

            if (!rt)
            {
                err = "大华相机设置采集帧数失败";
                 ErrorMessage.Clear();ErrorMessage.Append(err);
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
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (_trigSrc == ThridLibray.TriggerSourceEnum.Line1)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line1");

                        if (!rt)
                        {
                            err = "大华相机触发信号线Line1设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }
                    else if (_trigSrc == ThridLibray.TriggerSourceEnum.Line2)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line2");
                        if (rt)
                        {
                            rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineMode].SetValue("Input");
                            if (!rt)
                            {
                                err = "大华相机触发信号线Line2设置输入模式失败";
                                ErrorMessage.Clear(); ErrorMessage.Append(err);
                            }
                        }
                        else
                        {
                            err = "大华相机触发信号线Line2设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }

                    if (rt)
                    {
                        switch (edge)
                        {
                            case ProCommon.Communal.TriggerLogic.FallEdge:
                                {
                                    rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.TriggerActivation].SetValue("FallingEdge");
                                }
                                break;
                            case ProCommon.Communal.TriggerLogic.RaiseEdge:
                                {
                                    rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.TriggerActivation].SetValue("RisingEdge");
                                }
                                break;
                            default:
                                break;
                        }

                        if (!rt)
                        {
                            err = "大华相机触信号边沿设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }                   
                }
                else
                {
                    err = "大华相机触信号边沿设置失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoStartGrab()
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    rt = _deviceRef.GrabUsingGrabLoopThread();

                    if (!rt)
                    {
                        err = "大华相机开启采集失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机开启采集失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }               
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoPauseGrab()
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机暂停采集失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }

        public override bool DoStopGrab()
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (_deviceRef.IsGrabbing)
                        rt = _deviceRef.ShutdownGrab();
                    else
                        rt = true;
                    if (!rt)
                    {
                        err = "大华相机停止采集失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                    else
                    {
                        DoUnRegisterImageGrabbedCallBack();
                    }
                }
                else
                {
                    err = "大华相机停止采集失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoSoftTriggerOnce()
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    rt = _deviceRef.ExecuteSoftwareTrigger();
                    if (!rt)
                    {
                        err = "大华相机单次软触发采集失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机单次软触发采集失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoSetExposureTime(float exposuretime)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    using (ThridLibray.IFloatParameter p = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.ExposureTime])
                    {
                        //SDK内部范围,[16,1000000],单位微秒
                        exposuretime *= 1000;

                        if (exposuretime < 16)
                            exposuretime = 16.0f;

                        if (exposuretime >1000000)
                            exposuretime = 1000000.0f;

                        rt =p.SetValue(exposuretime);                       
                    }

                    if (!rt)
                    {
                        err = "大华相机设置曝光失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机设置曝光失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoSetFrameRate(float fps)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    using (ThridLibray.IFloatParameter p = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.AcquisitionFrameRate])
                    {
                        rt = p.SetValue(fps);
                    }

                    if (!rt)
                    {
                        err = "大华相机设置帧率失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机设置帧率失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public override bool DoSetGain(float gain)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    using (ThridLibray.IFloatParameter p = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.GainRaw])
                    {
                        //SDK内部范围,[1,32]

                        if (gain < 1)
                            gain = 1;

                        if (gain > 32)
                            gain = 32;

                        rt = p.SetValue(gain);
                    }

                    if (!rt)
                    {
                        err = "大华相机设置增益失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机设置增益失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置Gamma
        /// </summary>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public bool DoSetGamma(float gamma)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    using (ThridLibray.IFloatParameter p = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.Gamma])
                    {
                        //SDK内部范围,[0,3.99998]
                        if (gamma < 0)
                            gamma = 1;

                        if (gamma > 3.99998)
                            gamma = 3.99998f;

                        rt = p.SetValue(gamma);
                    }
                    if (!rt)
                    {
                        err = "大华相机设置伽马失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机设置伽马失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }               
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }       

        /// <summary>
        /// 设置相机触发延时
        /// </summary>
        /// <param name="lineIdx">外触发端口</param>
        /// <param name="trigdelay">延时时间,单位毫秒</param>
        /// <returns></returns>
        public bool DoSetTriggerDelay(int lineIdx,float trigdelay)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {

                    if (_trigSrc == ThridLibray.TriggerSourceEnum.Line1)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line1");

                        if (!rt)
                        {
                            err = "大华相机触发信号线Line1设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }
                    else if (_trigSrc == ThridLibray.TriggerSourceEnum.Line2)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line2");
                        if (rt)
                        {
                            rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineMode].SetValue("Input");
                            if (!rt)
                            {
                                err = "大华相机触发信号线Line2设置输入模式失败";
                                ErrorMessage.Clear(); ErrorMessage.Append(err);
                            }
                        }
                        else
                        {
                            err = "大华相机触发信号线Line2设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }

                    if(rt)
                    {
                        //SDK--时间单位微秒
                        trigdelay *= 1000;
                        if (trigdelay < 0)
                            trigdelay = 0;
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.TriggerDelay].SetValue(trigdelay);

                        if (!rt)
                        {
                            err = "大华相机设置触发延时失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }
                }
                else
                {
                    err = "大华相机设置触发延时失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        public bool DoSetDebouncerTime(int lineIdx, float debouncertime)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (_trigSrc == ThridLibray.TriggerSourceEnum.Line1)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line1");

                        if (!rt)
                        {
                            err = "大华相机触发信号线Line1设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }
                    else if (_trigSrc == ThridLibray.TriggerSourceEnum.Line2)
                    {
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineSelector].SetValue("Line2");
                        if (rt)
                        {
                            rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineMode].SetValue("Input");
                            if (!rt)
                            {
                                err = "大华相机触发信号线Line2设置输入模式失败";
                                ErrorMessage.Clear(); ErrorMessage.Append(err);
                            }
                        }
                        else
                        {
                            err = "大华相机触发信号线Line2设置失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }

                    if(rt)
                    {
                        //SDK--时间单位微秒,范围[0,1000000]
                        if (debouncertime < 0)
                            debouncertime = 0;
                        if (debouncertime > 1000000)
                            debouncertime = 1000000f;
                        rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.IOLineDebouncerTimeAbs].SetValue(debouncertime);

                        if (!rt)
                        {
                            err = "大华相机设置消抖时间失败";
                            ErrorMessage.Clear(); ErrorMessage.Append(err);
                        }
                    }
                }
                else
                {
                    err = "大华相机设置消抖时间失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }               
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置对比度
        /// </summary>
        /// <param name="contrast"></param>
        /// <returns></returns>
        public bool DoSetContrast(float contrast)
        {
            bool rt = false; string err = null;
            try
            {
                if(!rt)
                {
                    err = "大华相机设置对比度失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置饱和度
        /// </summary>
        /// <param name="saturation"></param>
        /// <returns></returns>
        public bool DoSetSaturation(float saturation)
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机设置饱和度失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置锐度
        /// </summary>
        /// <param name="sharpness"></param>
        /// <returns></returns>
        public bool DoSetSharpness(float sharpness)
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机设置锐度失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置三通道的增益
        /// </summary>
        /// <param name="redGain">红色通道增益</param>
        /// <param name="greenGain">绿色通道增益</param>
        /// <param name="blueGain">蓝色通道增益</param>
        /// <returns></returns>
        public bool DoSetGain(float redGain, float greenGain, float blueGain)
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机设置三通道增益失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 设置彩色相机是否黑白模式
        /// </summary>
        /// <param name="isColorful"></param>
        /// <returns></returns>
        public bool DoSetColorCameraMode(bool isColorful)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if(isColorful)
                    {
                        /* 设置缓存个数为8（默认值为16） */
                        /* set buffer count to 8 (default 16) */
                        rt = _deviceRef.StreamGrabber.SetBufferCount(16);
                        if (rt)
                        {
                            /* 设置图像格式 */
                            /* set PixelFormat --Mono8,BayerRG8,BayerRG10,BayerRg12,BayerRG10Packed,BayerRg12Packed,RGB8Packed,YUV422Packed*/
                            rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.ImagePixelFormat].SetValue("RGB8Packed");
                            if (!rt)
                            {
                                err = "大华相机设置彩色模式失败";
                                 ErrorMessage.Clear();ErrorMessage.Append(err);
                            }
                        }
                        else
                        {
                            err = "大华相机设置彩色模式缓存失败";
                             ErrorMessage.Clear();ErrorMessage.Append(err);
                        }
                    }
                    else
                    {
                        /* 设置缓存个数为8（默认值为16） */
                        /* set buffer count to 8 (default 16) */
                        rt=_deviceRef.StreamGrabber.SetBufferCount(8);
                        if(rt)
                        {
                            /* 设置图像格式 */
                            /* set PixelFormat */
                            rt = _deviceRef.ParameterCollection[ThridLibray.ParametrizeNameSet.ImagePixelFormat].SetValue("Mono8");
                            if (!rt)
                            {
                                err = "大华相机设置彩色模式失败";
                                 ErrorMessage.Clear();ErrorMessage.Append(err);
                            }
                        }
                        else
                        {
                            err = "大华相机设置彩色模式缓存失败";
                             ErrorMessage.Clear();ErrorMessage.Append(err);
                        }
                    }
                }
                else
                {
                    err = "大华相机设置彩色模式失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }
        public bool DoGetInPut(int lineIdx, out bool onOff)
        {
            bool rt = false; string err = null;
            onOff = false;

            try
            {
                if (_deviceRef != null)
                {
                    //暂不支持

                    if (!rt)
                    {
                        err = "大华相机获取指定输入端口状态失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取指定输入端口状态失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }      
        public bool DoSetOutPut(int idx, bool onOff)
        {
            bool rt = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    //暂不支持

                    if (!rt)
                    {
                        err = "大华相机设置指定输出端口状态失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机设置指定输出端口状态失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }
        public override bool DoCreateCameraSetPage(System.IntPtr windowHandle, string promption)
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机创建设置窗口失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }
        public override bool DoShowCameraSetPage()
        {
            bool rt = false; string err = null;
            try
            {
                if (!rt)
                {
                    err = "大华相机显示设置窗口失败";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }

            return rt;
        }
        public override string ToString()
        {
            return "CameraDriver[DaHua]";
        }
        public bool DoGetCameraConnectedState(out bool isConnected)
        {
            bool rt = false; isConnected = false; string err = null;
            try
            {
                if (_deviceRef != null)
                {
                    if (!rt)
                    {
                        err = "大华相机获取在线状态失败";
                         ErrorMessage.Clear();ErrorMessage.Append(err);
                    }
                }
                else
                {
                    err = "大华相机获取在线状态失败,设备为空";
                     ErrorMessage.Clear();ErrorMessage.Append(err);
                }
            }
            catch (System.Exception ex) { throw ex; }
            finally { }
            return rt;
        }

        /// <summary>
        /// 方法：注册异常回调函数(大华)
        /// </summary>
        /// <returns></returns>
        public override bool DoRegisterExceptionCallBack()
        {
            bool rt = false; string err = null;
            if (_deviceRef != null)
            {
                _deviceRef.ConnectionLost += _deviceRef_ConnectionLost;
                rt = true;
            }
            else
            {
                err = "大华相机注册异常事件失败,设备为空";
                 ErrorMessage.Clear();ErrorMessage.Append(err);
            }
            return rt;
        }

        /// <summary>
        /// 方法:注册采集数据更新回调(大华)
        /// </summary>
        /// <returns></returns>
        public override bool DoRegisterImageGrabbedCallBack()
        {
            bool rt = false; string err = null;

            if (_deviceRef != null)
            {
                if(!_isRegisterImageCallBack)
                {
                    _deviceRef.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;                   
                    _isRegisterImageCallBack = true;
                }
                rt = true;
            }
            else
            {
                err = "大华相机注册采集回调失败,设备为空";
                 ErrorMessage.Clear();ErrorMessage.Append(err);
            }
            return rt;
        }

        private void DoUnRegisterImageGrabbedCallBack()
        {
            if (_deviceRef != null)
            {
                if(_isRegisterImageCallBack)
                {
                    _deviceRef.StreamGrabber.ImageGrabbed -= StreamGrabber_ImageGrabbed;
                    _isRegisterImageCallBack = false;
                }
            }
        }

        #endregion

        #region OPT相机SDK官方函数

        #endregion

        #region BitMap转HObject 方法

        /// <summary>
        /// Bitmap转HObject
        /// </summary>
        /// <param name="bmp">24位Bitmap</param>
        /// <param name="hobj"></param>
        /// <returns></returns>
        private bool BitmapBpp24ToHObject(System.Drawing.Bitmap bmp, out HalconDotNet.HObject hobj)
        {
            bool rt = false;
            HalconDotNet.HOperatorSet.GenEmptyObj(out hobj);

            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData srcBmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                HalconDotNet.HOperatorSet.GenImageInterleaved(out hobj, srcBmpData.Scan0, "bgr", bmp.Width, bmp.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
                bmp.UnlockBits(srcBmpData);
                rt = true;
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
        /// Bitmap转HObject
        /// </summary>
        /// <param name="bmp">8位Bitmap</param>
        /// <param name="hobj"></param>
        /// <returns></returns>
        private bool BitmapBpp8ToHObject(System.Drawing.Bitmap bmp, out HalconDotNet.HObject hobj)
        {
            bool rt = false;
            HalconDotNet.HOperatorSet.GenEmptyObj(out hobj);

            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData srcBmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                HalconDotNet.HOperatorSet.GenImage1(out hobj, "byte", bmp.Width, bmp.Height, srcBmpData.Scan0);
                bmp.UnlockBits(srcBmpData);
                rt = true;
            }
            catch
            {
            }
            finally
            {
            }
            return rt;
        }

        private bool BitmapToHObject(System.Drawing.Bitmap bmp, out HalconDotNet.HObject hobj)
        {
            bool rt = false;
            HalconDotNet.HOperatorSet.GenEmptyObj(out hobj);

            try
            {
                switch (bmp.PixelFormat)
                {
                    case System.Drawing.Imaging.PixelFormat.Format16bppArgb1555:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format16bppGrayScale:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format16bppRgb555:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format16bppRgb565:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format1bppIndexed:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                        if (BitmapBpp24ToHObject(bmp, out hobj))
                            rt = true;
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format32bppPArgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format48bppRgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format4bppIndexed:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format64bppArgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format64bppPArgb:
                        break;
                    case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
                        if (BitmapBpp8ToHObject(bmp, out hobj))
                            rt = true;
                        break;
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

        public override bool DoSetTriggerDelay(float trigdelay)
        {
            throw new NotImplementedException();
        }

        public override bool DoSetOutPut(bool onOff)
        {
            throw new NotImplementedException();
        }

        #endregion


        public override bool GetExposureTime(out float exposuretime)
        {
            exposuretime = this.Camera.ExposureTime;
            return true;
        }

        public override bool GetGain(out float gain)
        {
            gain = this.Camera.Gain;
            return true;
        }

    }
}
