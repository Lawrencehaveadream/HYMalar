using CommonRs;
using HzControl.Logic;
using HZZH.Database;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    public class FSM 
    {
       static public FSMStaDef Status { get { return TaskManager.List[0].FSM.Status.ID; } }
        static public void Stop()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.STOP);
        }
        static public void Init()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.INIT);
        }
        static public void Start()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.RUN);
        }
        static public void Scram()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.SCRAM);
        }
        static public void Reset()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.RESET);
        }
        static public void Pause()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.PAUSE);
        }
        static public void ErrorStop()
        {
            TaskManager.List[0].FSM.Change(FSMStaDef.ERROR);
        }
    }
    public class LogicMainDef : LogicTask
    {
        public LogicMainDef() : base("Main")
		{

        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    TaskMain.prefeed.Start();
                    TaskMain.sticklogic.Start();
                    LG.StepNext(2);
                    break;
                case 2:
                    if (TaskMain.prefeed.GetDone
                        && TaskMain.feedout.GetDone 
                        && TaskManager.Default.FSM.Status.ID == FSMStaDef.RUN
                        )
                    {
                        LG.StepNext(3);
                    }
                    break;

                case 3:
                    TaskMain.feed.Start();
                    LG.StepNext(4);
                    break;
                case 4:
                    if (TaskMain.feed.GetDone && TaskManager.Default.FSM.Status.ID == FSMStaDef.RUN)
                    {
                        LG.StepNext(5);
                    }
                    break;

                case 5:
                    TaskMain.prefeed.Start();
                    LG.StepNext(6);
                    break;

                case 6:
                    if (TaskMain.sticklogic.GetDone)
                    {
                        LG.StepNext(7);
                    }
                    break;
                case 7:
                    if (TaskMain.feedout.GetDone)
                    {
                        TaskMain.feedout.Start();
                        LG.StepNext(8);
                    }
                    break;

                case 8:
                    if (DeviceRsDef.I_BeltFeedIn.Value == false
                        && DeviceRsDef.I_BeltFeedOut.Value == false
                        && TaskManager.Default.FSM.Status.ID == FSMStaDef.RUN)
                    {
                        LG.StepNext(1);
                    }
                    else
                    {
                        LG.StepNext(0xef);
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
