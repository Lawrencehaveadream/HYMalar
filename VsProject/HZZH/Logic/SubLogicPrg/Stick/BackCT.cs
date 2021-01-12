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
    public class BackCT : LogicTask
    {
        public BackCT() : base("回拍")
        {

        }
        private Tray TrayData { get; set; }
        public int whichProduct { get; private set; }

        protected override void LogicImpl()
        {
            var Para = Product.Inst.Stickdata;
            LG.Start();
            switch (LG.Step)
            {
                case 1:
                    whichProduct = 0;
                    LG.StepNext(2);
                    break;
                case 2:
                    
                    for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                    {
                        CTRCard.Axis_Z[i].MC_MoveAbs(0);
                    }
                    LG.StepNext(3);
                    break;
                case 3:
                    
                    if (CTRCard.ZArrive)
                    {
                        if (Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
                        {
                            LG.StepNext(4);
                        }
                        else
                        {
                            LG.StepNext(0xef);
                        }
                    }
                    break;

                case 4:
                    if (Para.CanBackCT)
                    {

                        CTRCard.Axis_X.MC_MoveAbs(TrayData.ProductList[whichProduct].BackCT.X);
                        CTRCard.Axis_Y.MC_MoveAbs(TrayData.ProductList[whichProduct].BackCT.Y);
                        LG.StepNext(5);
                    }
                    else
                    {
                        LG.StepNext(0xef);
                    }
                    break;
                case 5:
                    if (CTRCard.XYArrive)
                    {
                        LG.StepNext(6);
                    }
                    break;
                case 6:
                    if (CTRCard.XYArrive)
                    {
                        
                        LG.StepNext(7);
                        DeviceRsDef.Q_HoldLightCtrl.ON();
                        DeviceRsDef.Q_Light.OFF();
                    }
                    break;
                case 7:
                    
                    if (LG.Delay(Para.CTDelay))
                    {
                        //VisionProject.Instance.visionApi.TrigRun(3, 0);
                        LG.StepNext(8);
                    }
                    break;
                case 8:
                    
                    if (Product.Inst.IsAging)
                    {
                        //老化模式下，不判断拍照结果
                        if (LG.TCnt(100))
                        {
                            LG.StepNext(0xA0);
                        }
                    }
                    else
                    {
                        //正常模式下
                        //if (VisionProject.Instance.visionApi.Trig == false)
                        //{
                        //    VisionProject.Instance.SaveBackCTFunImage();

                        //    if (VisionProject.Instance.visionApi.Error == 0)
                        //    {
                        //        LG.StepNext(0xA0);
                        //    }
                        //    else
                        //    {
                        //        LG.StepNext(9);
                        //    }
                        //}
                    }
                    break;
                case 0xA0:
                    if (Product.Inst.IsAging)
                    {
                        LG.StepNext(9);
                    }
                    else
                    {
                        //ShowMessge.SendStartMsg(string.Format("产品{0}上物料精度 X：{1}Y：{2}R：{3}", whichProduct, VisionProject.Instance.visionApi.CheckStick[0].X, VisionProject.Instance.visionApi.CheckStick[0].Y, VisionProject.Instance.visionApi.CheckStick[0].R));
                        //ShowMessge.SendStartMsg(string.Format("产品{0}上物料精度 X：{1}Y：{2}R：{3}", whichProduct, VisionProject.Instance.visionApi.CheckStick[1].X, VisionProject.Instance.visionApi.CheckStick[1].Y, VisionProject.Instance.visionApi.CheckStick[1].R));
                        //ShowMessge.SendStartMsg(string.Format("产品{0}上物料精度 X：{1}Y：{2}R：{3}", whichProduct, VisionProject.Instance.visionApi.CheckStick[2].X, VisionProject.Instance.visionApi.CheckStick[2].Y, VisionProject.Instance.visionApi.CheckStick[2].R));
                        //ShowMessge.SendStartMsg(string.Format("产品{0}上物料精度 X：{1}Y：{2}R：{3}", whichProduct, VisionProject.Instance.visionApi.CheckStick[3].X, VisionProject.Instance.visionApi.CheckStick[3].Y, VisionProject.Instance.visionApi.CheckStick[3].R));
                        LG.StepNext(9);
                    }
                    break;
                case 9:
                    
                    whichProduct++;
                    if (whichProduct >= TrayData.ProductList.Count)
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(3);
                    }
                    break;
                case 0xef:
                    LG.End();
                    
                    break;
            }
        }
    }
}
