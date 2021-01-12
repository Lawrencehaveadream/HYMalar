using CommonRs;
using System.Threading;

namespace CommonRs
{
    /// <summary>
    /// 状态机，状态
    /// </summary>
	public enum FsmStaDef : int
    {
        INIT = 0,       //初始态
        STOP = 1,       //停止态
        RUN = 2,        //运行态
        RESET = 3,      //复位态
        SCRAM = 4,      //急停态
        PAUSE = 5,      //暂停态
        ALARM = 7,      //警告状态，不需要复位
        ERROR = 8,      //错误停止，需要复位
    }
    /// <summary>
    /// 运行模式
    /// </summary>
	public enum RunModeDef : int
    {
        NORMAL = 0,     //正常模式
        AGING = 1,		//老化模式
        STEP = 2,       //单步
        SIGNEL = 3,    //单次
    }
    /// <summary>
    /// 手自动模式
    /// </summary>
    public enum AutoManual : int
    {
        Auto = 0,   //自动
        Manual = 1, //手动
    }


    /// <summary>
    /// 状态机
    /// </summary>
	public class Fsm
    {

        #region 把当前类静态化
        static object _syncObj = new object();
        static Fsm FSM;
        public static Fsm Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (FSM == null)
                    {
                        FSM = new Fsm();
                    }
                }
                return FSM;
            }
        }
        #endregion


        private FsmStaDef Status { get; set; }
        public static RunModeDef RunMode { get; set; }
        private static AutoManual _autoManualSel;
        private static AutoManual _autoManualSelTerm;
        public static AutoManual AutoManualMode { get { return _autoManualSel; } }
        public Fsm()
        {
            Status = FsmStaDef.INIT;
            RunMode = RunModeDef.NORMAL;
            _autoManualSel = AutoManual.Auto;
            _autoManualSelTerm = AutoManual.Auto;
        }
        /// <summary>
        /// 自动 和 手动切换
        /// </summary>
        /// <param name="AutoManualSel"></param>
        public void AutoOrManualSwtich(AutoManual AutoManualSel)
        {
            _autoManualSel = AutoManualSel;
            if (_autoManualSel != _autoManualSelTerm)
            {
                _autoManualSelTerm = _autoManualSel;
                this.Status = FsmStaDef.INIT;
            }
        }

        public void Run()
        {
            if (this.Status == FsmStaDef.STOP || this.Status == FsmStaDef.PAUSE)
            {
                this.Status = FsmStaDef.RUN;
            }
        }

        public void Init()
        {
            if (this.Status == FsmStaDef.SCRAM || this.Status == FsmStaDef.PAUSE || this.Status == FsmStaDef.STOP)
            {
                this.Status = FsmStaDef.INIT;
            }
        }

        public void Stop()
        {
            if (this.Status != FsmStaDef.INIT && this.Status != FsmStaDef.SCRAM && this.Status != FsmStaDef.RESET)// && this.Status != FsmStaDef.RESET
            {
                this.Status = FsmStaDef.STOP;
            }
        }

        public void Ready()
        {
            if (this.Status != FsmStaDef.INIT && this.Status != FsmStaDef.SCRAM && this.Status == FsmStaDef.RESET)
            {
                this.Status = FsmStaDef.STOP;
            }
        }
        public void ErrorReady()
        {
            if (this.Status == FsmStaDef.ERROR || this.Status == FsmStaDef.ALARM || this.Status == FsmStaDef.RESET)
            {
                this.Status = FsmStaDef.STOP;
            }
        }
        //错误停止
        public void ErrorStop()
        {
            if (this.Status != FsmStaDef.INIT && this.Status != FsmStaDef.SCRAM)
            {
                this.Status = FsmStaDef.ERROR;
            }
        }
        //警告停止
        public void AlarmStop()
        {
            if (this.Status != FsmStaDef.INIT && this.Status != FsmStaDef.SCRAM)
            {
                this.Status = FsmStaDef.ALARM;
            }

        }
        public void Pause()
        {
            if (this.Status == FsmStaDef.RUN)
            {
                this.Status = FsmStaDef.PAUSE;
            }
        }
        public void Reset()
        {
            if (this.Status == FsmStaDef.STOP || this.Status == FsmStaDef.PAUSE || this.Status == FsmStaDef.INIT || this.Status == FsmStaDef.ERROR)
            {
                this.Status = FsmStaDef.RESET;
            }
        }
        public void Scram()
        {
            this.Status = FsmStaDef.SCRAM;
        }

        public void StepRun()
        {
            if (this.Status == FsmStaDef.STOP)
            {
                //this.Status = FsmStaDef.STEPMODE;
            }
        }
        public FsmStaDef GetStatus
        {
            get
            {
                return this.Status;
            }
        }

        public FsmStaDef status
        {
            get
            {
                return this.Status;
            }
        }
    }
}
