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
using HZZH.Vision;
using HZZH.Logic.LogicMain;

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class StandardMark : LogicTask
    {
        public StandardMark() : base("标准mark点")
        {

        }
        /// <summary>
        /// 在扫描产品的哪一个mark点
        /// </summary>
        public int whichMark { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        private ProductDef stickPos { get; set; } = new ProductDef();
        private ProductDef MarkCaculate(ProductDef product)
        {
            ProductDef pp = product.Clone();
            pp.SiteList.Clear();
            for (int i = 0; i < product.SiteList.Count; i++)
            {
                SitePoint site = new SitePoint();
                site = product.SiteList[i].Clone();

                HalconDotNet.HTuple x;
                HalconDotNet.HTuple y;
                VisionProject.Instance.Tool.PointLocation.AffineTransPoint2d(
                    product.SiteList[i].X,
                    product.SiteList[i].Y,
                    out x, out y);
                site.X = x[0].F;
                site.Y = y[0].F;
                pp.SiteList.Add(site);
            }
            return pp;
        }
        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            switch (LG.Step)
            {
                case 1:
                    whichMark = 0;
                    Para.ProcessData.currWhichProduct = 0;//第一个产品
                    LG.StepNext(2);
                    break;
                case 2:
                    for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                    {
                        CTRCard.Axis_Z[i].MC_MoveAbs(Para.Stickdata.ZSafePos);//两个Z轴抬起到安全高度
                    }
                    LG.StepNext(3);
                    break;
                case 3:
                    if (CTRCard.ZArrive)//Z轴到达
                    {
                        stickPos = Product.Inst.Stickdata.TrayData.ProductList[0].Clone();//把产品树里的产品参数克隆过来
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    CTRCard.Axis_X.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[0].MarkPoint[whichMark].X);//XY到位
                    CTRCard.Axis_Y.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[0].MarkPoint[whichMark].Y);
                    DeviceRsDef.Q_UpLighSource.ON();//上光源打开
                    LG.StepNext(5);
                    break;
                case 5:
                    if (CTRCard.XYArrive && LG.Delay(Para.Stickdata.CTDelay))//XY到达
                    {
                        TaskMain.UpCamLogc.ModelID = whichMark;
                        TaskMain.UpCamLogc.Triger();
                        LG.StepNext(6);
                    }
                    break;
                case 6:
                    if (TaskMain.UpCamLogc.Finish)
                    {
                        if (TaskMain.UpCamLogc.Result.Count > 0)
                        {
                            LG.StepNext(7);
                        }
                        else
                        {
                            LG.StepNext(8);
                        }
                    }
                    break;
                case 7:
                    PointF3Vision mark = new PointF3Vision();
                    mark.X = Product.Inst.Stickdata.TrayData.ProductList[0].MarkPoint[whichMark].X + TaskMain.UpCamLogc.Result[0].X;
                    mark.Y = Product.Inst.Stickdata.TrayData.ProductList[0].MarkPoint[whichMark].Y + TaskMain.UpCamLogc.Result[0].Y;
                    mark.R = Product.Inst.Stickdata.TrayData.ProductList[0].MarkPoint[whichMark].R + TaskMain.UpCamLogc.Result[0].R;
                    VisionProject.Instance.Tool.PointLocation.SetBenchmark1(whichMark,mark.X,mark.Y);
                    VisionProject.Instance.Tool.PointLocation.SetBenchmark2(whichMark, mark.X, mark.Y);
                    
                    whichMark++;
                    if (whichMark >= 2)
                    {
                        VisionProject.Instance.Tool.PointLocation.Calculation();
                        Product.Inst.Stickdata.TrayData.ProductList[0] = MarkCaculate(Product.Inst.Stickdata.TrayData.ProductList[0]);
                        LG.StepNext(8);
                    }
                    else
                    {
                        LG.StepNext(4);
                    }
                    break;
                case 8:
                    LG.StepNext(0xef);
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
