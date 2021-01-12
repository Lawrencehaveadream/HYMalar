using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;
using HZZH.Common.Config;

namespace HZZH.Logic.SubLogicPrg.Belt
{
    public class FeedOut : LogicTask
    {
        public FeedOut() : base("出料")
        {

        }
        private Fun fun = new Fun();
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    DeviceRsDef.Q_Rise.OFF();//顶升气缸下降
                    if (DeviceRsDef.I_RiseDown.Value)//到低位感应到执行接下来的动作
                    {
                        if (!DeviceRsDef.I_BeltUnfeedOut.Value)
                        {
                            LG.StepNext(2);
                        }
                        else
                        {
                            Alarm.SetAlarm(AlarmLevelEnum.Level1, "出料位置有载具");
                        }
                    }
                    break;
                case 2:
                    DeviceRsDef.Axis_BeltFeed.MC_MoveSpd(10);//中间皮带运行
                    DeviceRsDef.Axis_BeltUnfeed.MC_MoveSpd(10);//右侧皮带运行
                    LG.StepNext(3);
                    break;
                case 3:
                    if (fun.F_Trig(DeviceRsDef.I_BeltFeedOut.Value))//载具完全脱离中间皮带
                    {
                        DeviceRsDef.Axis_BeltFeed.MC_StopDec();//中间皮带停止
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (DeviceRsDef.I_BeltUnfeedOut.Value)//载具到位
                    {
                        DeviceRsDef.Axis_BeltUnfeed.MC_StopDec();//右侧皮带停止
                        LG.StepNext(5);
                    }
                    break;
                case 5:
                    if (DeviceRsDef.Axis_BeltUnfeed.status == 0)
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
