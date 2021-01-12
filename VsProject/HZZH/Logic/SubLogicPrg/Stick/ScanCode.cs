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
    public class ScanCode : LogicTask
    {
        public ScanCode():base("扫描二维码")
        {

        }
        private Tray TrayData { get; set; }
        List<string> DataList { get; set; } = new List<string>();
        public int whichproduct { get; set; }
        protected override void LogicImpl()
        {
            var Para = Product.Inst.Stickdata;
            switch (LG.Step)
            {
                case 1:
                    whichproduct = Product.Inst.Stickdata.TrayData.ProductList.Count - 1;
                    DataList.Clear();
                    LG.StepNext(2);
                    break;
                case 2:
                    for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                    {
                        CTRCard.Axis_Z[i].MC_MoveAbs(Para.ZSafePos);
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
                    if (Para.CanscanCode)
                    {
                        CTRCard.Axis_X.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[whichproduct].CodePoint2.X);
                        CTRCard.Axis_Y.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[whichproduct].CodePoint2.Y);
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
                        DeviceRsDef.Q_Light.ON();
                        DeviceRsDef.Q_HoldLightCtrl.OFF();
                    }
                    break;
                case 7:
                    if (LG.Delay(10))
                    {
                        //VisionProject.Instance.visionApi.TrigRun(2, 0);
                        LG.StepNext(8);
                    }
                    break;
                case 8:
                    if (Product.Inst.IsAging)
                    {
                        //老化模式下，不判断拍照结果
                        if (LG.TCnt(500))
                        {
                            LG.StepNext(10);
                        }
                    }
                    else
                    {
                        //正常模式下
                        //if (VisionProject.Instance.visionApi.Trig == false)
                        //{
                        //    if (VisionProject.Instance.visionApi.Error == 0)
                        //    {
                        //        LG.StepNext(9);
                        //    }
                        //    else
                        //    {
                        //        LG.StepNext(10);
                        //    }
                        //}
                    }
                    break;
                case 9:
                    //DataList.Add(VisionProject.Instance.visionApi.CodeString);//将读取到的二维码信息加进list里面
                    //ShowMessge.SendStartMsg(string.Format("产品{0}二维码：{1}", whichproduct, VisionProject.Instance.visionApi.CodeString));
                    LG.StepNext(10);
                    break;
                case 10:
                    whichproduct--;
                    if (whichproduct <= -1)
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(3);
                    }
                    break;
                case 0xef:
                    DeviceRsDef.Q_HoldLightCtrl.ON();
                    DeviceRsDef.Q_Light.OFF();
                    LG.End();
                    break;
            }
        }
    }
}
