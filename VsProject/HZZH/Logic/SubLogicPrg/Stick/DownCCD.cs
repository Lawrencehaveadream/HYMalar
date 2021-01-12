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
    public class DownCCD : LogicTask
    {
        public DownCCD() : base("下相机拍照")
        {

        }
        /// <summary>
        /// 哪一个吸嘴 0：左边 1：右边
        /// </summary>
        private int whichNuzzle { get; set; }

        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            switch (LG.Step)
            {
                case 1:
                    whichNuzzle = 0;
                    LG.StepNext(2);
                    break;
                case 2:
                    if (Para.ProcessData.NuzzlePara[whichNuzzle].isHave)//吸嘴有料
                    {
                        if (CTRCard.ZArrive)
                        {
                            for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                            {
                                CTRCard.Axis_Z[i].MC_MoveAbs(Para.Stickdata.ZSafePos);//到安全位置拍照
                            }
                            LG.StepNext(3);
                        }
                    }
                    else
                    {
                        LG.StepNext(6);//没有料换另一个吸嘴
                    }
                    break;

                case 3:
                    if (CTRCard.ZArrive)//到相应的吸嘴拍照位置
                    {
                        if (Para.ProcessData.NuzzlePara[whichNuzzle].isHave && whichNuzzle == 0)
                        {
                            CTRCard.Axis_X.MC_MoveAbs(Para.Stickdata.StickSysData.LiftDownCCDPos.X);
                            CTRCard.Axis_Y.MC_MoveAbs(Para.Stickdata.StickSysData.LiftDownCCDPos.Y);
                            DeviceRsDef.Q_DownLighSource.ON();
                            LG.StepNext(4);
                        }
                        else if(Para.ProcessData.NuzzlePara[whichNuzzle].isHave && whichNuzzle == 1)
                        {
                            CTRCard.Axis_X.MC_MoveAbs(Para.Stickdata.StickSysData.RightDownCCDPos.X);
                            CTRCard.Axis_Y.MC_MoveAbs(Para.Stickdata.StickSysData.RightDownCCDPos.Y);
                            DeviceRsDef.Q_DownLighSource.ON();
                            LG.StepNext(4);
                        }
                        else
                        {
                            LG.StepNext(6);
                        }
                    }
                    break;
                case 4:
                    if (CTRCard.XYArrive && LG.Delay(Para.Stickdata.CTDelay))
                    {
                        //VisionProject.Instance.visionApi.TrigRun(1, whichNuzzle);//触发拍照
                        LG.StepNext(5);
                    }
                    break;
                case 5:
                    if (Product.Inst.IsAging)
                    {
                        if (LG.Delay(100))
                        {
                            Para.ProcessData.NuzzlePara[whichNuzzle].isOk = 1;
                            Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.X = 0;
                            Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.Y = 0;
                            Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.R = 0;
                            LG.StepNext(6);
                        }
                        DeviceRsDef.Q_DownLighSource.OFF();
                    }
                    else
                    {
                        //if (VisionProject.Instance.visionApi.TrigComplete() == true)
                        //{
                        //    var va = VisionProject.Instance.visionApi;
                        //    //判断拍照结果
                        //    if (VisionProject.Instance.visionApi.Error == 0)
                        //    {
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].isOk = 1;
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].isHave = true;
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.X = (float)VisionProject.Instance.visionApi.Result[0].X;
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.Y = (float)VisionProject.Instance.visionApi.Result[0].Y;
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].CCDPos.R = -(float)VisionProject.Instance.visionApi.Result[0].R;
                        //        DeviceRsDef.Q_DownLighSource.OFF();
                        //    }
                        //    else
                        //    {
                        //        Para.ProcessData.NuzzlePara[whichNuzzle].isOk = 2;
                        //    }
                        //    LG.StepNext(6);
                        //}
                    }
                    break;
                case 6:
                    if (CTRCard.RArrive)
                    {
                        whichNuzzle++;
                        if (whichNuzzle >= 2)
                        {
                            LG.StepNext(0xef);
                        }
                        else
                        {
                            LG.StepNext(2);
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
