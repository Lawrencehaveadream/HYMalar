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

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class GiveUp : LogicTask
    {

        public GiveUp() : base("弃料")
        {

        }

        public int whichNuzzle { get; private set; }

        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            LG.Start();
            switch (LG.Step)
            {
                case 1: //Z轴抬起到安全高度
                    if (CTRCard.ZArrive)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            CTRCard.Axis_Z[i].MC_MoveAbs(Para.Stickdata.GiveUpPara.SafePos_Z);
                        }
                        LG.StepNext(2);
                    }
                    whichNuzzle = 0;
                    break;
                case 2: //判断轴到达
                    if (CTRCard.ZArrive)
                    {
                        LG.StepNext(3);
                    }
                    break;

                case 3:
                    if (Para.ProcessData.NuzzlePara[whichNuzzle].isOk != 1 && Para.ProcessData.NuzzlePara[whichNuzzle].isHave == true)
                    {
                        LG.StepNext(4);
                    }
                    else
                    {
                        LG.StepNext(8);
                    }
                    break;
                case 4://XY到弃标位
                    if (CTRCard.ZArrive)
                    {
                        if (whichNuzzle == 0)
                        {
                            CTRCard.Axis_X.MC_MoveAbs(Para.Stickdata.GiveUpPara.LiftGiveUpPos.X);
                            CTRCard.Axis_Y.MC_MoveAbs(Para.Stickdata.GiveUpPara.LiftGiveUpPos.Y);
                            LG.StepNext(5);
                        }
                        else
                        {
                            CTRCard.Axis_X.MC_MoveAbs(Para.Stickdata.GiveUpPara.RightGiveUpPos.X);
                            CTRCard.Axis_Y.MC_MoveAbs(Para.Stickdata.GiveUpPara.RightGiveUpPos.Y);
                            LG.StepNext(5);
                        }
                    }
                    break;
                case 5://Z到弃标高度
                    if (CTRCard.XYArrive)
                    {
                        if (whichNuzzle == 0)
                        {
                            CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.GiveUpPara.LiftGiveUp_Z);
                            LG.StepNext(6);
                        }
                        else
                        {
                            CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.GiveUpPara.RightGiveUp_Z);
                            LG.StepNext(6);
                        }
                    }
                    break;
                case 6://破真空，吹气
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Q_Nuzzle[whichNuzzle].OFF();
                        CTRCard.Q_Blow[whichNuzzle].ON();
                        Para.Stickdata.GiveUpPara.giveUpNum++;
                        LG.StepNext(7);
                    }
                    break;

                case 7:
                    if (LG.Delay(Para.Stickdata.GiveUpPara.GiveUpDelay))
                    /*弃料延时*/
                    {
                        LG.StepNext(8);
                        Para.ProcessData.NuzzlePara[whichNuzzle].isHave = false;
                        CTRCard.Q_Blow[whichNuzzle].Value = false;
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.GiveUpPara.SafePos_Z);
                    }
                    break;
                case 8://Z轴回到安全位
                    if (CTRCard.ZArrive)
                    {
                        whichNuzzle++;
                        if (whichNuzzle < CTRCard.Axis_Z.Count)
                        {
                            LG.StepNext(2);
                        }
                        else
                        {
                            LG.StepNext(0xef);
                        }
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
