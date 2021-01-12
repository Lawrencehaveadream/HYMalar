using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;
namespace HZZH.Logic.SubLogicPrg
{
    public  class PreFeedBelt : LogicTask
    {
        public PreFeedBelt() : base("预进料")
        {

        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    if (DeviceRsDef.I_BeltPreFeedOut.Value)//预进料感应到载具直接结束
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(2);
                    }
                    break;
                case 2:
                    DeviceRsDef.Q_PreFeedRequest.ON();//向上一台设备发送送料信号
                    DeviceRsDef.Axis_BeltPreFeed.MC_MoveSpd(10);//左侧皮带运行
                    LG.StepNext(3);
                    break;
                case 3:
                    if (DeviceRsDef.I_BeltPreFeedOut.Value)//载具到预备位置
                    {
                        DeviceRsDef.Q_PreFeedRequest.OFF();//停止左侧皮带
                        DeviceRsDef.Axis_BeltPreFeed.MC_Stop();//停止向前端发送要料信号
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (DeviceRsDef.Axis_BeltPreFeed.status == 0)//皮带停稳并结束流程
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
