using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CommonRs
{
    public class LogicTaskDef
    {
        public void Start()
        {
            LG.Exe();
        }

        public int GetSta()
        {
            return LG.GetSta();
        }
        public LogicDataDef LG = new LogicDataDef();
    }
    /// <summary>
    /// 逻辑类，用于写逻辑流程
    /// </summary>
    /// <param name="addr">地址</param>
    /// <param name="numbers">数量</param>
    /// <param name="dt">读取的数据类型</param>
    public class LogicDataDef//每个任务运行的控制参数	下位的LogicParaDef
    {
        private int execute;
        private int _step;
        public int step { get { return _step; } }
        public int Step { get { return _step; } }
        public int busy;

        private string _taskName = "";
        /// <summary>
        /// 流程名称
        /// </summary>
        public string TaskName { get { return _taskName; } }

        private int stepBuff;
        public int done;
        public int count;
        public int index;
        public int errCode;
        private System.DateTime et;
        private System.DateTime tm;
        private bool trigBuff;
        private System.DateTime trigTm;
        private bool trigBuff1;
        public Action CompletedAct;
        public LogicDataDef(string TaskName)
            : this()
        {
            _taskName = TaskName;
        }
        public LogicDataDef()
        {
            execute = 0;
            _step = 0;
            busy = 0;
            stepBuff = 0;
            done = 0;
            count = 0;
            index = 0;
            errCode = 0;
        }
        /// <summary>
        /// 下一步，只有运行状态下，才能往下执行
        /// </summary>
        /// <param name="stepVal"></param>
        /// <returns></returns>
        public bool StepNextRun(int stepVal)
        {
            if (Fsm.AutoManualMode == AutoManual.Manual)
            {
                _step = stepVal;
                return true;
            }
            else
            {
                if (Fsm.Instance.GetStatus == FsmStaDef.RUN)
                {
                    _step = stepVal;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="stepVal"></param>
        public void StepNext(int stepVal)
        {
            if (Fsm.RunMode == RunModeDef.STEP)
            {
                if (Fsm.Instance.GetStatus == FsmStaDef.RUN)
                {
                    _step = stepVal;
                    //FSM.Stop();
                }
            }
            else
            {
                _step = stepVal;
            }
        }
        //流程开始程序
        /// <summary>
        /// 流程头部程序，一直调用
        /// </summary>
        public void HeadLg()
        {
            if (execute == 1 && step == 0)
            {
                _step = 1;
                done = 0;
                count = 0;
                index = 0;
                errCode = 0;
                busy = 1;
            }

            if (step != stepBuff)
            {
                stepBuff = step;
                TRst();
            }
            //状态机进入初始态和复位态，逻辑自动结束
            if (Fsm.Instance.GetStatus == FsmStaDef.INIT || Fsm.Instance.GetStatus == FsmStaDef.RESET)
            {
                execute = 0;
                _step = 0;
                busy = 0;
                stepBuff = 0;
                done = 0;
                count = 0;
                index = 0;
                errCode = 0;
            }
            //但不模式下，运行状态智慧维持10MS。
            if (Fsm.RunMode == RunModeDef.STEP)
            {
                //
                if (TonP(Fsm.Instance.GetStatus == FsmStaDef.RUN, 10))
                {
                    Fsm.Instance.Stop();
                }
            }
        }
        /// <summary>
        /// 流程开始执行
        /// </summary>
        /// <param name="act"></param
        public void Exe(Action act = null)
        {
            this.CompletedAct = act;
            this.execute = 1;
            this.busy = 1;
            this.count = 0;
            this.errCode = 0;
            this.done = 0;
        }
        /// <summary>
        /// 流程开始执行
        /// </summary>
        /// <param name="act"></param
        public void Start(Action act = null)
        {
            this.CompletedAct = act;
            this.execute = 1;
            this.busy = 1;
            this.count = 0;
            this.errCode = 0;
            this.done = 0;
        }

        /// <summary>
        /// 获取流程状态
        /// </summary>
        /// <returns></returns>
        public int GetSta()
        {
            return this.execute;
        }



        /// <summary>
        /// 流程结束
        /// </summary>
        public void End() //通用的任务开始方法
        {
            execute = 0;
            _step = 0;
            busy = 0;
            done = 1;
        }
        /// <summary>
        /// 错误停止
        /// </summary>
        public void ErrorStop() //通用的任务开始方法
        {
            execute = 0;
            _step = 0;
            busy = 0;
            done = 0;
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="clk">触发条件</param>
        /// <param name="et_ms">预设时间</param>
        /// <returns></returns>
        public bool Ton(bool clk, int et_ms)
        {
            if (clk)
            {
                TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(et);
                if (singleTimeSpan.TotalMilliseconds >= et_ms)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                et = System.DateTime.Now;
                return false;
            }
        }

        public DateTime et1 = new DateTime();
        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="clk">触发条件</param>
        /// <param name="et_ms">预设时间</param>
        /// <returns></returns>
        private bool TonP(bool clk, int et_ms)
        {
            if (clk)
            {
                TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(et1);
                if (singleTimeSpan.TotalMilliseconds >= et_ms)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                et1 = System.DateTime.Now;
                return false;
            }
        }
        /// <summary>
        /// 定时器复位
        /// </summary>
        public void TonRst()
        {
            et = System.DateTime.Now;
        }

        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="delay_ms">延时时间</param>
        /// <returns></returns>
        public bool TCnt(int delay_ms)
        {
            TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(tm);
            if (delay_ms <= (uint)singleTimeSpan.TotalMilliseconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 计时器清零
        /// </summary>
        public void TRst()
        {
            tm = System.DateTime.Now;
        }

        /// <summary>
        /// 上升沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public bool R_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (clk)
                    return true;
            }
            return false;
        }
        //
        /// <summary>
        /// 下降沿触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <returns></returns>
        public bool F_Trig(bool clk)
        {
            if (clk != trigBuff)
            {
                trigBuff = clk;
                if (!clk)
                    return true;
            }
            return false;
        }
        //
        /// <summary>
        /// 延时触发，持续一个扫描周期
        /// </summary>
        /// <param name="clk"></param>
        /// <param name="delay_ms"></param>
        /// <returns></returns>
        public bool Trig(bool clk, int delay_ms)
        {
            if (clk)
            {
                if (clk != trigBuff1)
                {
                    TimeSpan singleTimeSpan = System.DateTime.Now.Subtract(trigTm);
                    if (singleTimeSpan.TotalMilliseconds >= delay_ms)
                    {
                        trigBuff1 = clk;
                        return true;
                    }
                }
            }
            else
            {
                trigTm = System.DateTime.Now;
            }
            return false;
        }

        private string _stepDescription = "";
        /// <summary>
        /// 步骤描述
        /// </summary>
        public string stepDescription
        {
            get { return TaskName + "(step = " + step + "):" + _stepDescription; }
        }
        /// <summary>
        /// 流程注释
        /// </summary>
        /// <param name="Description">注释信息</param>
        public void StepMessage(string Description)
        {
            if (_stepDescription != Description)
            {
                //ShowMessge.SendStartMsg(TaskName + "(step = "+step+"):" + Description);
            }
            _stepDescription = Description;
        }
    }





}
