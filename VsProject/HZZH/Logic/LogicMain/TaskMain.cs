using HzControl.Logic;
using HZZH.Logic.SubLogicPrg;
using HZZH.Logic.SubLogicPrg.Belt;
using HZZH.Logic.SubLogicPrg.Stick;
using HZZH.Vision;
//using HZZH.Logic.SubLogicPrg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    /// <summary>
    /// 任务访问
    /// </summary>
    public class LT
    {
        public static StickMainLogic Task { get { return TaskMain.sticklogic; } }
    }
    class TaskMain
    {
        public static LogicMainDef LogicMain { get; set; }
        public static ResetLogicDef ResetLogic { get; set; }
        public static LogicLoopRun LogicLoop { get; set; }
        public static StickMainLogic sticklogic { get; set; }
        public static PreFeedBelt prefeed { get; set; }
        public static FeedBelt feed { get; set; }
        public static FeedOut feedout { get; set; }
        public static XYmove move { get; set; }


        public static VisionLogic UpCamLogc { get; set; } = new VisionLogic()
        {
            CameraID = 0
        };

        public static VisionLogic DownCamLogc { get; set; } = new VisionLogic()
        {
            CameraID = 1
        };

        static TaskMain()
        {
            LogicMain = new LogicMainDef();
            ResetLogic = new ResetLogicDef();
            LogicLoop = new LogicLoopRun();
            sticklogic = new StickMainLogic();
            prefeed = new PreFeedBelt();
            feed = new FeedBelt();
            feedout = new FeedOut();
            move = new XYmove();
        }
        public static void Init()
        {
            TaskManager.Default.FSM.ChangeState += FSM_ChangeState;

            TaskManager.Default.Add(LogicMain);
            TaskManager.Default.Add(ResetLogic);
            TaskManager.Default.Add(LogicLoop);


            TaskManager.Default.Add(sticklogic);
            TaskManager.Default.Add(sticklogic.markscan);
            TaskManager.Default.Add(sticklogic.takelabel);
            TaskManager.Default.Add(sticklogic.downCCD);
            TaskManager.Default.Add(sticklogic.stick);
            TaskManager.Default.Add(sticklogic.giveup);
            TaskManager.Default.Add(sticklogic.scancode);
            TaskManager.Default.Add(sticklogic.backCT);
            TaskManager.Default.Add(sticklogic.feeder);
            TaskManager.Default.Add(sticklogic.StandardMark);
            TaskManager.Default.Add(prefeed);
            TaskManager.Default.Add(feed);
            TaskManager.Default.Add(feedout);
            
            TaskManager.Default.Add(move);
        }
        private static void FSM_ChangeState(object sender, FSMChangeEventArgs e)
        {
            // 主逻辑运行
            if (e.State.ID == FSMStaDef.RUN)
            {
                LogicMain.Start();
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    if (item.LG.Step != 0)
                    {
                        item.Start();
                    }
                }
            }

            // 复位逻辑运行
            if (e.State.ID == FSMStaDef.RESET)
            {
                ResetLogic.Start();
            }

            // 点击停止，部分逻辑可能不能停止，需要继续运行
            if (e.State.ID == FSMStaDef.STOP)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                     item.Stop();
                }
            }

            if (e.State.ID == FSMStaDef.PAUSE)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    item.Stop();
                }
            }

            // 急停，所有的逻辑全部停止
            if (e.State.ID == FSMStaDef.SCRAM)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    item.Stop();
                }
            }
        }
    }
}
