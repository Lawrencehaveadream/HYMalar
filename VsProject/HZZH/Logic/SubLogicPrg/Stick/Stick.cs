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
    public class Stick : LogicTask
    {
        public Stick() : base("贴附")
        {

        }

        public int whichNuzzle { get; private set; }
        private PointF4 stickPos { get; set; } = new PointF4();
        private PointF4 StickPos(int Num)
        {
            PointF4 stickPosTerm = new PointF4();
            stickPosTerm.X = Product.Inst.ProcessData.NuzzlePara[Num].CCDPos.X + Product.Inst.ProcessData.CurrStickWhichPoint().X;
            stickPosTerm.Y = Product.Inst.ProcessData.NuzzlePara[Num].CCDPos.Y + Product.Inst.ProcessData.CurrStickWhichPoint().Y;
            stickPosTerm.Z = Product.Inst.ProcessData.CurrStickWhichPoint().Z;
            stickPosTerm.R = Product.Inst.ProcessData.CurrStickWhichPoint().R + Product.Inst.ProcessData.NuzzlePara[Num].CCDPos.R;
            stickPos = Product.Inst.Stickdata.StickSysData.UpCCDToNuzzle(Num, stickPosTerm);
            return stickPos;
        }
        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            switch (LG.Step)
            {
                case 1: //Z轴抬起到安全高度
                    if (Para.ProcessData.currWhichProduct >= Para.ProcessData.StickPosList.Count)
                    {
                        Para.ProcessData.currWhichProduct = 0;
                    }
                    else
                    {
                        if (Para.ProcessData.currWhichPoint >= Para.ProcessData.CurrStickWhichProduct().SiteList.Count)
                        {
                            Para.ProcessData.currWhichPoint = 0;
                        }
                    }
                    if (Para.ProcessData.StickPosList.Count == 0)
                    {
                        Alarm.SetAlarm(AlarmLevelEnum.Level2, "没扫Mark点，不允许贴附");
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        if (CTRCard.ZArrive)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                CTRCard.Axis_Z[i].MC_MoveAbs(Para.Stickdata.ZSafePos);
                            }
                            LG.StepNext(2);
                        }
                    }
                    break;
                case 2:
                    bool isCanStick = false;
                    for (int i = 0; i < 2; i++)//扫描吸嘴个数
                    {
                        if (Para.ProcessData.NuzzlePara[i].isOk == 1 && Para.ProcessData.NuzzlePara[i].isHave)
                        {
                            whichNuzzle = i;
                            isCanStick = true;
                            break;
                        }
                    }
                    if (isCanStick)
                    {
                        StickPos(whichNuzzle);
                        Para.ProcessData.NuzzlePara[whichNuzzle].isHave = false;
                        Para.ProcessData.NuzzlePara[whichNuzzle].isOk = 0;
                        LG.StepNext(3);
                    }
                    else
                    {
                        LG.StepNext(0xef);
                    }
                    break;
                case 3: //xy到贴标位置
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Axis_X.MC_MoveAbs(stickPos.X);
                        CTRCard.Axis_Y.MC_MoveAbs(stickPos.Y);
                        CTRCard.Axis_R[whichNuzzle].MC_MoveAbs(stickPos.R);
                        LG.StepNext(4);
                    }
                    break;
                case 4://系统稳定时间+第一段快速下降
                    if (CTRCard.XYArrive && CTRCard.RArrive && LG.TCnt(10))
                    {
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(stickPos.Z - 5);
                        LG.StepNext(5);
                    }
                    break;
                case 5://第二段慢速下降
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(30, stickPos.Z);
                        LG.StepNext(6);
                    }
                    break;
                case 6://到达贴标高度吸真空打开，吹气关闭
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Q_Nuzzle[whichNuzzle].ON();
                        CTRCard.Q_Blow[whichNuzzle].OFF();
                        LG.StepNext(7);
                    }
                    break;
                case 7://真空延时后，很空关闭，吹气打开
                    if (LG.Delay(Para.Stickdata.StickPara.SuckOffDelay))
                    {
                        CTRCard.Q_Nuzzle[whichNuzzle].OFF();
                        CTRCard.Q_Blow[whichNuzzle].ON();
                        LG.StepNext(8);
                    }
                    break;

                case 8://吹气延时后吹气关闭
                    if (LG.Delay(Para.Stickdata.StickPara.SuckBlowDelay))
                    {
                        CTRCard.Q_Blow[whichNuzzle].OFF();
                        Product.Inst.ProductYield.ProductCount();//产量+1用于计算UPH
                        LG.StepNext(9);
                    }
                    break;
                case 9://Z轴回到安全位
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.ZSafePos);
                        LG.StepNext(10);
                    }
                    break;
                case 10://Z轴到位后 
                    if (CTRCard.Axis_Z[whichNuzzle].status == AxState.AXSTA_READY)
                    {                   
                        CTRCard.Axis_R[whichNuzzle].MC_MoveAbs(0);
                        LG.StepNext(11);
                    }
                    break;

                case 11:
                    Para.ProcessData.currWhichPoint++;//点位++
                    if (Para.ProcessData.currWhichPoint >= Para.ProcessData.StickPosList[Para.ProcessData.currWhichProduct].SiteList.Count)
                    {
                        Para.ProcessData.currWhichPoint = 0;//点位置0
                        Para.ProcessData.currWhichProduct++;//产品加1
                        if (Para.ProcessData.currWhichProduct >= Para.ProcessData.StickPosList.Count)
                        {
                            //Para.ProcessData.currWhichPoint = 0;//点位置0
                            //Para.ProcessData.currWhichProduct = 0;//产品置0
                            LG.StepNext(0xef);
                            break;
                        }
                    }
                    LG.StepNext(2);
                    if (!Para.ProcessData.NuzzlePara[0].isHave && !Para.ProcessData.NuzzlePara[1].isHave)
                    {
                        LG.StepNext(0xef);//两个吸嘴都没有料就结束
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
