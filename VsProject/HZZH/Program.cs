using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Collections;
using System.Text;
using HZZH.Logic.Commmon;
using ApiClass;
using LicenseManagement;
using System.IO;
using System.Diagnostics;
using CommonRs;
using HZZH.UI2;

namespace UI
{
   

    //使用方法:定义一个启动类，应用程序从启动类启动，该类会使用继承自启动窗体虚基类的一个启动窗体类，在该类中定义启动窗体和主窗体。启动窗体和主窗体的代码略去，注意要删除机器生成的窗体代码的Main方法部分。
    public class StartUpClass
    {
        public static IntPtr handle = IntPtr.Zero;
 
        [STAThread]
        static void Main()
        {
            bool createdNew;
            const string globalGuid = "Global\\C5E5A797-0BF2-494B-BBED-056ABA095C12";
            Mutex mutex = new Mutex(true, globalGuid, out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("程序正在运行");
                return;
            }

           

            #region  加密狗运行

#if DEBUG
            if (Api.LoginSafeDog(ref handle) != 0) //
            {
                MessageBox.Show("启动失败：Dog不存在或不匹配");
            }
            else
            {
                string strdogmsg = Api.ReadDog(0, handle);
                if (strdogmsg == string.Empty)
                {

                    Application.ApplicationExit += Application_ApplicationExit;
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);


                    TaskRun.Instance.LogicThread.Start();
                    try
                    {
                        Application.Run(new mycontext());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    if (!File.Exists(@"armcc01_intr"))
                    {
                        MessageBox.Show("启动失败：加密文件丢失");
                    }
                    else
                    {
                        try
                        {
                            string dogHID = AESHelper.DecryptStr(LicenseMsg.readMachineLicense(@"armcc01_intr"));

                            string term0 = AESHelper.Decrypt(strdogmsg, "qwertyuiop");
                            string dogcpu = term0.Substring(0, 8);

                            string term1 = Api.ReadDog(128, handle);

                            string term2 = AESHelper.Decrypt(term1, "qwertyuiop");
                            string machinecpu = term2.Substring(0, 8);

                            if (dogHID.CompareTo(dogcpu) == 0 && dogHID.CompareTo(machinecpu) == 0)
                            {
                                Application.ApplicationExit += Application_ApplicationExit;
                                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);


                                TaskRun.Instance.LogicThread.Start();
                                try
                                {
                                    Application.Run(new mycontext());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                            }
                            else
                            {
                                MessageBox.Show("启动失败：电脑不匹配：" + "请联系厂家");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("启动失败：Dog参数文件被手动修改" + ex.Message + "/" + "请联系厂家");
                        }
                    }

                }

            }
#else
            Application.ApplicationExit += Application_ApplicationExit;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            //TaskRun.Instance.LogicThread.Start();
            try
            {
                Application.Run(new mycontext());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
#endif
            #endregion

        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //ConfigSpace.ConfigHandle.Instance.Save();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(GetExceptionMsg(e.Exception, e.ToString()), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(GetExceptionMsg(e.ExceptionObject as Exception, e.ToString()), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("****************************异常文本****************************");
            builder.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                builder.AppendLine("【异常类型】：" + ex.GetType().Name);
                builder.AppendLine("【异常信息】：" + ex.Message);
                builder.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                builder.AppendLine("【未处理异常】：" + backStr);
            }
            builder.AppendLine("***************************************************************");
            return builder.ToString();
        }



    }

    //启动画面虚基类,启动画面会停留一段时间，该时间是设定的时间和主窗体构造所需时间两个的最大值 

    public abstract class SplashScreenApplicationContext : ApplicationContext
    {
        /// <summary>
        /// 启动窗体 
        /// </summary>
        private Form _SplashScreenForm;
        /// <summary>
        /// 主窗体 
        /// </summary>
        public Form _PrimaryForm;

        private System.Timers.Timer _SplashScreenTimer;

        private int _SplashScreenTimerInterVal = 3000;// 3000;//默认是启动窗体显示5秒 

        private bool _bSplashScreenClosed = false;

        private delegate void DisposeDelegate();//关闭委托，下面需要使用控件的Invoke方法，该方法需要这个委托 



        public SplashScreenApplicationContext()
        {

            this.ShowSplashScreen();//这里创建和显示启动窗体 
            this.MainFormLoad();//这里创建和显示启动主窗体 

        }



        protected abstract void OnCreateSplashScreenForm();



        protected abstract void OnCreateMainForm();



        protected abstract void SetSeconds();



        protected Form SplashScreenForm
        {

            set
            {

                this._SplashScreenForm = value;

            }

        }



        protected Form PrimaryForm
        {//在派生类中重写OnCreateMainForm方法，在MainFormLoad方法中调用OnCreateMainForm方法 
            //  ,在这里才会真正调用Form1(主窗体)的构造函数，即在启动窗体显示后再调用主窗体的构造函数 
            //  ，以避免这种情况:主窗体构造所需时间较长,在屏幕上许久没有响应，看不到启动窗体       
            set
            {
                this._PrimaryForm = value;
            }
        }



        protected int SecondsShow
        {//未设置启动画面停留时间时，使用默认时间  
            set
            {
                if (value != 0)
                {

                    this._SplashScreenTimerInterVal = 1000 * value;
                }
            }
        }



        private void ShowSplashScreen()
        {
            this.SetSeconds();
            this.OnCreateSplashScreenForm();
            this._SplashScreenTimer = new System.Timers.Timer(((double)(this._SplashScreenTimerInterVal)));
            _SplashScreenTimer.Elapsed += new System.Timers.ElapsedEventHandler(new System.Timers.ElapsedEventHandler(this.SplashScreenDisplayTimeUp));
            this._SplashScreenTimer.AutoReset = false;
            Thread DisplaySpashScreenThread = new Thread(new ThreadStart(DisplaySplashScreen));
            DisplaySpashScreenThread.Start();
        }



        private void DisplaySplashScreen()
        {
            this._SplashScreenTimer.Enabled = true;
            Application.Run(this._SplashScreenForm);
        }



        private void SplashScreenDisplayTimeUp(object sender, System.Timers.ElapsedEventArgs e)
        {

            this._SplashScreenTimer.Dispose();

            this._SplashScreenTimer = null;

            this._bSplashScreenClosed = true;

        }



        private void MainFormLoad()
        {
            this.OnCreateMainForm();
            while (!(this._bSplashScreenClosed))
            {
                Application.DoEvents();
            }
            DisposeDelegate SplashScreenFormDisposeDelegate = new DisposeDelegate(this._SplashScreenForm.Dispose);
            this._SplashScreenForm.Invoke(SplashScreenFormDisposeDelegate);
            this._SplashScreenForm = null;
            //必须先显示，再激活，否则主窗体不能在启动窗体消失后出现
            
            this._PrimaryForm.Show();
            this._PrimaryForm.Activate();
            this._PrimaryForm.Closed += new EventHandler(_PrimaryForm_Closed);
        }



        private void _PrimaryForm_Closed(object sender, EventArgs e)
        {
            base.ExitThread();
        }

    }


    //启动窗体类(继承自启动窗体虚基类),启动画面会停留一段时间，该时间是设定的时间和主窗体构造所需时间两个的最大值 
    public class mycontext : SplashScreenApplicationContext
    {

        protected override void OnCreateSplashScreenForm()
        {

            this.SplashScreenForm = new frm_SplashScreen();//启动窗体  
        }



        protected override void OnCreateMainForm()
        {
            //this.PrimaryForm = new FormMain();//主窗体 
            this.PrimaryForm = new HZZH.UI2.MainForm();//主窗体 
            InitSysterm();
        }


        static void InitSysterm()
        {
            StartUpdate.SendStartMsg("读取配置文件");
            Thread.Sleep(100);
            //StartUpdate.SendStartMsg("初始化相机");
            //CameraMgr.Inst.GetHashCode();
            StartUpdate.SendStartMsg("初始化几面窗口");
            FrmMgr.Init();
            Thread.Sleep(200);
            HZZH.Common.Config.AlarmLog.LoadLogData(AppDomain.CurrentDomain.BaseDirectory + "Logs\\", DateTime.Now.ToString("yyyy-MM-dd"));
        }
        protected override void SetSeconds()
        {
            this.SecondsShow = 3;//启动窗体显示的时间(秒)  
        }

    }

}
