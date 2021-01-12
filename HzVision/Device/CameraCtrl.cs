using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HalconDotNet;
using ProCommon.Communal;
using Vision.Tool;

namespace HzVision.Device
{
    public class CameraCtrl : HWindowControl
    {
        public CameraCtrl()
        {
            if (!this.DesignMode)
            {
                if (_showThread == null)
                {
                    _showExit = false;
                    _showThread = new Thread(ShowMethod1);
                    _showThread.IsBackground = true;
                    _showThread.Start();
                }
            }
        }


        private int _id = 0;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                if (this.DesignMode == false)
                {
                    StartCamera(this._id);
                }
            }
        }

        protected CameraDevice Device = null;
        protected readonly object locker = new object();
        private bool drawEvent = false;


        protected HImage himage = new HImage();

        public object Locker
        {
            get { return locker; }
        }
    
        public void CloseCamera()
        {
            if (Device != null)
            {
                Device.ImageGrabbedEvt -= Device_ImageGrabbedEvt;
                if (cameraCtrls.Contains(this))
                {
                    lock (cameraCtrls)
                    {
                        cameraCtrls.Remove(this);
                    }
                }
                if (!_showExit && cameraCtrls.Count == 0)
                {
                    _showExit = true;
                    _showThread.Join();
                    _showThread = null;
                }

                lock (locker)
                {
                    if (himage != null)
                    {
                        himage.Dispose();
                    }
                }
            }
        }

        public bool StartCamera(CtrllerBrand ctrller, string serialNo)
        {
            this.CloseCamera();
            this.Device = CameraMgr.Inst.Start(ctrller, serialNo);
            if (Device != null)
            {
                //Device.CameraConfig.Number = this.ID;
                InitShow();
                return true;
            }

            return false;
        }

        public bool StartCamera(int id)
        {
            if (this.Device != CameraMgr.Inst[ID])
            {
                this.CloseCamera();
                this.Device = CameraMgr.Inst[ID];
                if (Device != null)
                {
                    InitShow();
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        protected void InitShow()
        {
            if (Device != null)
            {
                Device.ImageGrabbedEvt += Device_ImageGrabbedEvt;
                lock (cameraCtrls)
                {
                    cameraCtrls.Add(this);
                }

                if (_showExit == true && _showThread == null)
                {
                    _showExit = false;
                    _showThread = new Thread(ShowMethod1);
                    _showThread.IsBackground = true;
                    _showThread.Start();
                }
            }
        }



        protected virtual void Render()
        {
            //HalconDotNet.HSystem.SetSystem("flush_graphic", "false"); //不更新图形变量
        
            base.HalconWindow.SetDraw("margin");
            if (himage.IsInitialized())
            {
                base.SetFullImagePart(himage);
                base.HalconWindow.DispObj(himage);
            }
            else
            {
                base.HalconWindow.ClearWindow();
            }
            //HalconDotNet.HSystem.SetSystem("flush_graphic", "true"); //更新图形变量
            //base.HalconWindow.SetColor("black");
            //base.HalconWindow.DispLine(-100.0, -100.0, -101.0, -101.0); //不知何用
        }

        public event EventHandler<DrawEventArgs> Draw;
        private void OnDraw(DrawEventArgs displayHWindow)
        {
            EventHandler<DrawEventArgs> temp = Draw;
            if (temp != null)
            {
                temp(this, displayHWindow);
            }
        }

        public void ReDraw()
        {
            if (this.Visible)
            {
                drawEvent = true;
                //drawEvent.Set();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.DesignMode)
            {
                this.CloseCamera();
            }
            base.Dispose(disposing);
        }

        private void Device_ImageGrabbedEvt(object sender, EventArgs e)
        {
            lock (locker)
            {
                himage.Dispose();
                himage = Device.GetCurrentImage();
                ReDraw();
            }

            Frequency++;
            if(Frequency>100)
            {
                Frequency = 0;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
            }
        }


        public CameraDevice Camera
        {
            get
            {
                return Device;
            }
        }

        static int Frequency = 0;

        private void ShowMethodImpl()
        {
            if (DesignMode == true)
            {
                return;
            }

            if (this.Visible && this.Created && this.Disposing == false)
            {
                lock (locker)
                {
                    try
                    {
                        this.Render();
                        OnDraw(new DrawEventArgs(this));
                    }
                    catch (HOperatorException ex)
                    {
                        int errolCode = ex.GetErrorCode();
                        if (errolCode != 9400 && errolCode != 5)
                        {
                            //throw;
                        }
                    }

                }
            }
        }



        private static bool _showExit;
        private static Thread _showThread;
        private static List<CameraCtrl> cameraCtrls = new List<CameraCtrl>();
        static CameraCtrl()
        {
    
        }

        private static void ShowMethod1()
        {
            while (!_showExit)
            {
                lock (cameraCtrls)
                {
                    foreach (var item in cameraCtrls)
                    {
                        if (item.drawEvent == true)
                        {
                            item.ShowMethodImpl();
                            item.drawEvent = false;
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
    }







    public class DrawEventArgs : EventArgs
    {
        public HWindow HWindow { get; private set; }
        
        public DrawEventArgs(HWindowControl hWindow)
        {
            this.HWindow = hWindow.HalconWindow;
        }
    }
}
