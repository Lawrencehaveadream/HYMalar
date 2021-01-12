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
using HZZH.Logic.LogicMain;
using System.Diagnostics;

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class TakeLabel : LogicTask
    {
        public TakeLabel() : base("取标")
        {

        }
        /// <summary>
        /// 拍照次数
        /// </summary>
        public int CTCount { get; private set; }
        /// <summary>
        /// 取标的个数
        /// </summary>
        private int TakeCount { get; set; }
        /// <summary>
        /// 哪一个吸嘴
        /// </summary>
        private int whichNuzzle { get; set; }
        /// <summary>
        /// 视觉识别结果
        /// </summary>
        private PointF3Vision CCDresult { get; set; } = new PointF3Vision();
        public int TakeNum { get; private set; }
        private Stopwatch Ltime { get; set; } = new Stopwatch();
        private Stopwatch Rtime { get; set; } = new Stopwatch();
        public int Lsticktime { get; set; }
        public int Rsticktime { get; set; }
        private PointF4 TakePos(int Num)
        {
            PointF4 pos = Product.Inst.Stickdata.StickSysData.UpCCDToNuzzle(Num, Product.Inst.Stickdata.FeederPara.TakePos);
            return pos;
        }
        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            switch (LG.Step)
            {
                case 1:
                    if (TaskMain.sticklogic.feeder.GetBusy)
                    {
                        return;
                    }
                    TakeCount = 0;//取料个数
                    whichNuzzle = 0;//哪个吸嘴
                    LG.StepNext(2);
                    break;
                case 2: //Z轴抬起到安全高度
                    for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                    {
                        CTRCard.Axis_Z[i].MC_MoveAbs(Para.Stickdata.ZSafePos);//Z到安全位置
                        CTRCard.Axis_R[i].MC_MoveAbs(0);
                    }
                    LG.StepNext(3);
                    break;
                case 3:
                    if (CTRCard.ZArrive && CTRCard.RArrive)
                    {
                        bool isCanTake = false;
                        if (
                            Para.Stickdata.NuzzleForbit[whichNuzzle] == false &&
                            Para.ProcessData.NuzzlePara[whichNuzzle].isHave == false)//吸嘴没被禁用且没有料
                        {
                            isCanTake = true;
                        }
                        else
                        {
                            if (Para.Stickdata.NuzzleForbit[whichNuzzle] == true)//吸嘴禁用取料加1
                            {
                                TakeCount++;
                            }
                        }
                        if (isCanTake)
                        {
                            if (TakeCount == 1 && whichNuzzle == 1)
                            {
                                LG.StepNext(7);//如果左吸嘴取过一次且目前可以取料的是右吸嘴
                            }
                            else
                            {
                                LG.StepNext(4);//可以取料  去取料位置
                            }
                        }
                        else
                        {
                            LG.StepNext(14);//去 判断
                        }
                    }
                    break;
                case 4:
                    if (whichNuzzle == 0)
                    {
                        Ltime.Stop();
                        Lsticktime = (int)Ltime.ElapsedMilliseconds;
                        Ltime.Restart();
                    }
                    else
                    {
                        Rtime.Stop();
                        Rsticktime = (int)Rtime.ElapsedMilliseconds;
                        Rtime.Restart();
                    }
                    CTRCard.Axis_X.MC_MoveAbs(Para.Stickdata.FeederPara.TakePos.X);
                    CTRCard.Axis_Y.MC_MoveAbs(Para.Stickdata.FeederPara.TakePos.Y);//到拍照位置
                    DeviceRsDef.Q_UpLighSource.ON();//上光源打开
                    LG.StepNext(5);
                    break;
                case 5:
                    if (CTRCard.XYArrive)
                    {
                        //VisionProject.Instance.visionApi.TrigRun(0, 2);//触发拍照
                        LG.StepNext(6);
                    }
                    break;
                case 6:
                    if (Product.Inst.IsAging)
                    {
                        if (LG.Delay(200))
                        {
                            CCDresult.X = 0;
                            CCDresult.Y = 0;
                            CCDresult.R = 0;
                            LG.StepNext(7);
                        }
                    }
                    else
                    {
                        //if (VisionProject.Instance.visionApi.Trig == false)//相机触发的值
                        //{
                        //    if (VisionProject.Instance.visionApi.Error == 0)//相机接口错误码
                        //    {
                        //        LG.StepNext(7);//xy到取标位置
                        //        DeviceRsDef.Q_UpLighSource.OFF();//上相机光源关闭
                        //    }
                        //    else
                        //    {
                        //        LG.StepNext(101);//重新送料
                        //        CTCount++;//拍照识别次数
                        //        if (CTCount > 2)//大于2就视觉NG
                        //        {
                        //            CTCount = 0;//重新置零
                        //            Alarm.SetAlarm(AlarmLevelEnum.Level2, "Feeder视觉NG");//报警
                        //        }
                        //    }
                        //}

                    }
                    break;

                case 7:
                    CTRCard.Q_Blow[whichNuzzle].OFF();//吹气关闭
                    if (Product.Inst.IsAging)
                    {
                        if (LG.Delay(500))
                        {
                            CCDresult.X = 0;
                            CCDresult.Y = 0;
                            CCDresult.R = 0;
                        }
                    }
                    //else if (VisionProject.Instance.visionApi.Result.Length == 2)
                    //{
                    //    CCDresult.X = (float)VisionProject.Instance.visionApi.Result[TakeCount].X;//ccd的x值[改为链表形式]
                    //    CCDresult.Y = (float)VisionProject.Instance.visionApi.Result[TakeCount].Y;//ccd的y值
                    //    CCDresult.R = -(float)VisionProject.Instance.visionApi.Result[TakeCount].R;//ccd的r值
                    //}
                    //else
                    //{
                    //    CCDresult.X = (float)VisionProject.Instance.visionApi.Result[0].X;//ccd的x值[改为链表形式]
                    //    CCDresult.Y = (float)VisionProject.Instance.visionApi.Result[0].Y;//ccd的y值
                    //    CCDresult.R = -(float)VisionProject.Instance.visionApi.Result[0].R;//ccd的r值
                    //}
                    CTRCard.Axis_X.MC_MoveAbs(TakePos(whichNuzzle).X + (float)CCDresult.X);
                    CTRCard.Axis_Y.MC_MoveAbs(TakePos(whichNuzzle).Y + (float)CCDresult.Y);
                    CTRCard.Axis_R[whichNuzzle].MC_MoveAbs((float)CCDresult.R);
                    LG.StepNext(8);
                    break;
                case 8://XY到位后判断缓取，开始下压时打开吸嘴
                    if (CTRCard.RArrive && CTRCard.XYArrive)
                    {
                        if (whichNuzzle == 0)
                        {
                            CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.TakeLabelPara.LiftTakePos_Z);
                        }
                        else
                        {
                            CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.TakeLabelPara.RightTakePos_Z);
                        }
                        LG.StepNext(9);
                    }
                    break;
                case 9:
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Q_Nuzzle[whichNuzzle].ON();//真空打开
                        CTRCard.Q_Blow[whichNuzzle].OFF();//吹气关闭
                        LG.StepNext(10);
                    }
                    break;
                case 10:
                    if (whichNuzzle == 0)
                    {
                        Para.Stickdata.TakeLabelPara.TakeLableWholeLNum++;
                    }
                    else
                    {
                        Para.Stickdata.TakeLabelPara.TakeLableWholeRNum++;
                    }
                    LG.StepNext(11);
                    break;
                case 11://取标延时后Z轴抬起(缓抬)
                    if (whichNuzzle == 0 && LG.Delay(Para.Stickdata.TakeLabelPara.LiftTakeDelay))
                    {
                        LG.StepNext(201);
                    }
                    else if(whichNuzzle == 1 && LG.Delay(Para.Stickdata.TakeLabelPara.RightTakeDelay))
                    {
                        LG.StepNext(201);
                    }
                    break;
                case 201:
                    if (Para.Stickdata.FeederPara.FeederMode[1])
                    {
                        //剥标板回退
                        LG.StepNext(202);
                    }
                    else
                    {
                        LG.StepNext(12);
                    }
                    break;
                case 202:
                    if (Para.Stickdata.FeederPara.FeederMode[1])//拨标板回退停止
                    {
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.ZSafePos);//Z轴抬起
                        LG.StepNext(13);
                    }
                    break;
                case 12://取标延时后Z轴抬起
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Axis_Z[whichNuzzle].MC_MoveAbs(Para.Stickdata.ZSafePos);
                        LG.StepNext(13);
                    }
                    break;
                case 13://检测真空//add
                    if (CTRCard.ZArrive)//所有轴都到达
                    {
                        if (!Product.Inst.IsAging && CTRCard.I_Vacuum[whichNuzzle].Value == false)
                        {
                            TakeNum++;
                            if (TakeNum >= 2)
                            {
                                TakeNum = 0;
                                LG.StepNext(101);//运行状态下进入14 重新剥标
                                CTRCard.Q_Nuzzle[whichNuzzle].Value = false;//吸真空电磁阀
                                Alarm.SetAlarm(AlarmLevelEnum.Level2, "取料失败，请检查真空和真空感应");
                                Para.ProcessData.NuzzlePara[whichNuzzle].isHave = false;//是否有料
                            }
                            else
                            {
                                LG.StepNext(4);//到拍照位
                            }
                        }
                        else
                        {
                            if (whichNuzzle == 0)
                            {
                                Para.Stickdata.TakeLabelPara.TakeLableLNum++;
                            }
                            else
                            {
                                Para.Stickdata.TakeLabelPara.TakeLableRNum++;
                            }
                            LG.StepNext(14);//结束
                            Para.ProcessData.NuzzlePara[whichNuzzle].isHave = true;//有料
                        }
                    }
                    break;
                case 101:
                    if (CTRCard.ZArrive)
                    {
                        LG.StepNext(4);
                    }
                    break;
                case 14://结束
                    if (CTRCard.ZArrive)
                    {
                        whichNuzzle++;//吸嘴换成另一个吸嘴
                        TakeCount++;
                        if (whichNuzzle >= 2)
                        {
                            LG.StepNext(15);
                        }
                        else
                        {
                            LG.StepNext(2);
                        }
                    }
                    break;
                case 15:
                    if (TakeCount >= 2)
                    {
                        LG.StepNext(0xef);
                    }
                    //else if (VisionProject.Instance.visionApi.Result.Length == 1)
                    //{
                    //    TakeCount = 0;
                    //    LG.StepNext(0xef);
                    //}
                    else if (Para.ProcessData.NuzzlePara[0].isHave == true 
                        && Para.ProcessData.NuzzlePara[1].isHave == true)
                    {
                        TakeCount = 0;
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(2);
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
