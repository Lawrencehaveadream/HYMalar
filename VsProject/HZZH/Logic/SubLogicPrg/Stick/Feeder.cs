using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;
using HZZH.Database;
using CommonRs;
using HZZH.Logic.Project;
using HzVision;
using Device;
using HZZH.Common.Config;
using Paste.Vision.Tool.RotateCenter;

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class Feeder : LogicTask
    {
        public Feeder() : base("飞达送料")
        {

        }

        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    if (Product.Inst.IsAging)
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(2);
                    }
                    break;
                case 2:
                    if (DeviceRsDef.I_FeederReady.Value)
                    {
                        DeviceRsDef.Q_FeederRequest.OFF();
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(3);
                    }
                    break;
                case 3:
                    if (!DeviceRsDef.I_FeederReady.Value)
                    {
                        DeviceRsDef.Q_FeederRequest.ON();
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (DeviceRsDef.I_FeederReady.Value)
                    {
                        DeviceRsDef.Q_FeederRequest.OFF();
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
