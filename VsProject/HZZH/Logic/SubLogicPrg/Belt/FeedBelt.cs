using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;

namespace HZZH.Logic.SubLogicPrg.Belt
{
    public class Fun
    {
        private bool trigBuff { get; set; }
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
    }
    public class FeedBelt : LogicTask
    {
        public FeedBelt() : base("进料")
        {

        }
        private Fun fun = new Fun();
        protected override void LogicImpl()
        {
            var Para = Database.AllData.Data.Beltdata;
            switch (LG.Step)
            {
                case 1:
                    DeviceRsDef.Q_Rise.OFF();//顶升气缸不顶升
                    DeviceRsDef.Q_StopBlock.OFF();//阻挡气缸不下降
                    if (DeviceRsDef.I_StopBlockUp.Value && DeviceRsDef.I_RiseDown.Value)//顶升气缸下限和阻挡气缸上限感应到
                    {
                        LG.StepNext(2);
                    }
                    break;
                case 2:
                    DeviceRsDef.Axis_BeltFeed.MC_MoveSpd(10);//中间皮带运行
                    DeviceRsDef.Axis_BeltPreFeed.MC_MoveSpd(10);//左侧皮带运行
                    LG.StepNext(3);
                    break;
                case 3:
                    if (fun.F_Trig(DeviceRsDef.I_BeltPreFeedOut.Value))//载具已经脱离左侧皮带
                    {
                        DeviceRsDef.Axis_BeltPreFeed.MC_StopDec();//左侧皮带停止
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (DeviceRsDef.I_BeltFeedIn.Value && LG.Delay(Para.RiseOnDelay))//载具到位
                    {
                        DeviceRsDef.Axis_BeltFeed.MC_StopDec();//中间皮带停止
                        LG.StepNext(5);
                    }
                    break;
                case 5:
                    if (DeviceRsDef.Axis_BeltFeed.status == 0)
                    {
                        DeviceRsDef.Q_Rise.ON();//顶升气缸顶起固定
                        LG.StepNext(6);
                    }
                    break;
                case 6:
                    if (DeviceRsDef.I_RiseUp.Value)//顶升气缸上限位
                    {
                        DeviceRsDef.Q_StopBlock.ON();//阻挡气缸
                        LG.StepNext(7);
                    }
                    break;
                case 7:
                    if (DeviceRsDef.I_StopBlockDown.Value)//阻挡气缸下限到位
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
