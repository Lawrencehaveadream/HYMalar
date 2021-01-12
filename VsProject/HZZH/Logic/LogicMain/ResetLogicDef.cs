using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    class ResetLogicDef : LogicTask
    {
        public ResetLogicDef() : base("整机复位")
        {
        }
        private void startNuzzleParaInit()
        {
            Product.Inst.ProcessData.NuzzlePara.Clear();
            int nuzzleForbitCount = 0;
            for (int i = 0; i < 2; i++)
            {
                Product.Inst.ProcessData.NuzzlePara.Add(new NuzzleParaDef());
                if (Product.Inst.Stickdata.NuzzleForbit[i] == true)
                {
                    nuzzleForbitCount++;
                }
            }

            if (nuzzleForbitCount >= 2)
            {
                Alarm.SetAlarm(AlarmLevelEnum.Level2, "吸嘴全部禁用，请启用吸嘴");
            }
        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    startNuzzleParaInit();
                    for (int i = 0; i < 30; i++)
                    {
                        DeviceRsDef.MotionCard.MotionFun.OutputOFF(i);
                    }
                    DeviceRsDef.MotionCard.MotionFun.OutputON(24);
                    for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                    {
                        DeviceRsDef.AxisList[i].MC_Stop();
                    }
                    Alarm.ClearAlarm();
                    if (DeviceRsDef.I_XFarLimit.Value)
                    {
                        DeviceRsDef.Axis_X.MC_Stop();
                        Alarm.SetAlarm(AlarmLevelEnum.Level3, "X正硬极限限位");
                    }
                    if (DeviceRsDef.I_YFarLimit.Value)
                    {
                        DeviceRsDef.Axis_Y.MC_Stop();
                        Alarm.SetAlarm(AlarmLevelEnum.Level3, "Y正硬极限限位");
                    }
                    Product.Inst.ProcessData.currWhichPoint = 0;
                    Product.Inst.ProcessData.currWhichProduct = 0;
                    LG.StepNext(2);
                    break;
                case 2:
                    if (LG.Delay(100))
                    {
                        for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                        {
                            DeviceRsDef.AxisList[i].MC_AlarmReset();
                        }
                        LG.StepNext(3);
                    }
                    break;
                case 3:
                    if (CTRCard.ZArrive)
                    {
                        DeviceRsDef.Axis_Z1.MC_Home();
                        DeviceRsDef.Axis_Z2.MC_Home();
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (CTRCard.ZArrive)
                    {
                        DeviceRsDef.Axis_R1.MC_Home();
                        DeviceRsDef.Axis_R2.MC_Home();
                        DeviceRsDef.Axis_X.MC_Home();
                        DeviceRsDef.Axis_Y.MC_Home();
                        LG.StepNext(5);
                    }
                    break;

                case 5:
                    if (CTRCard.XYArrive && CTRCard.RArrive)
                    {
                        LG.StepNext(0xef);
                    }
                    break;
                case 0xef:
                    LG.End();
                    FSM.Stop();
                    break;
            }
        }
    }
}
