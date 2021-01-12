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
using HZZH.Logic.LogicMain;
using HZZH.Vision;

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class MarkScan : LogicTask
    {
        public MarkScan() : base("扫描Mark点")
        {

        }
        /// <summary>
        /// 在扫描产品的哪一个mark点
        /// </summary>
        public int whichMark { get; set; }
        /// <summary>
        /// Mark点扫描结果
        /// </summary>
        public List<PointF3Vision> MarkResult { get; set; } = new List<PointF3Vision>();
        /// <summary>
        /// 产品的角度
        /// </summary>
        public List<float> whichProductAngle = new List<float>();
        /// <summary>
        /// 产品列表
        /// </summary>
        private Tray TrayData { get; set; }
        /// <summary>
        /// 扫描那个产品的mark点
        /// </summary>
        public int MarkscanProduct { get; set; }
        /// <summary>
        /// 扫描一个产品时数据中转
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
                    whichMark = 0;//第一个mark点
                    Para.ProcessData.StickPosList.Clear();//贴附过程列表清空
                    Para.ProcessData.currWhichPoint = 0;//第一个点
                    Para.ProcessData.currWhichProduct = 0;//第一个产品
                    MarkscanProduct = 0;
                    MarkResult.Clear();//mark点的拍照结果清空
                    whichProductAngle.Clear();//机械角度列表清空
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
                        if (Product.Inst.Stickdata.TrayData.ProductList.Count > 0)//产品树列表有产品
                        {
                            LG.StepNext(4);
                            stickPos = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].Clone();//把产品树里的产品参数克隆过来
                        }
                        else
                        {
                            LG.StepNext(0xef);
                        }
                    }
                    break;

                case 4:
                    CTRCard.Axis_X.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].X);//XY到位
                    CTRCard.Axis_Y.MC_MoveAbs(Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].Y);
                    DeviceRsDef.Q_UpLighSource.ON();//上光源打开
                    //VisionProject.Instance.SetBenchmark1
                    //    (
                    //    Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].X,
                    //    Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].Y,
                    //    Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].R,
                    //    whichMark,true
                    //    );//设置mark点识别位置
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
                    if (Product.Inst.IsAging)//老化模式
                    {
                        if (LG.TCnt(200))
                        {
                            LG.StepNext(7);
                        }
                    }
                    else
                    {
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
                    }
                    break;
                case 7:
                    PointF3Vision mark = new PointF3Vision();
                    if (Product.Inst.IsAging)
                    {
                        mark.X = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].X;
                        mark.Y = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].Y;
                        mark.R = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].R;
                    }
                    else
                    {
                        mark.X = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].X + TaskMain.UpCamLogc.Result[0].X;
                        mark.Y = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].Y + TaskMain.UpCamLogc.Result[0].Y;
                        mark.R = Product.Inst.Stickdata.TrayData.ProductList[MarkscanProduct].MarkPoint[whichMark].R + TaskMain.UpCamLogc.Result[0].R;
                    }
                    VisionProject.Instance.Tool.PointLocation.SetBenchmark2
                        (
                        whichMark,
                        mark.X,
                        mark.Y
                        );
                    MarkResult.Add(mark);
                    whichMark++;
                    if (whichMark >= 2)
                    {
                        VisionProject.Instance.Tool.PointLocation.Calculation();
                        if (Product.Inst.IsAging)
                        {
                            Para.ProcessData.StickPosList.Add(stickPos);
                        }
                        else
                        {
                            //计算Mark点，并暂存计算结果                         
                            Para.ProcessData.StickPosList.Add(MarkCaculate(stickPos));  //计算Mark点，并保存计算结果
                        }
                        LG.StepNext(8);
                    }
                    else
                    {
                        LG.StepNext(4);
                    }
                    break;
                case 8:
                    DeviceRsDef.Q_UpLighSource.OFF();
                    if (MarkscanProduct >= Product.Inst.Stickdata.TrayData.ProductList.Count - 1)
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        LG.StepNext(3);
                        whichMark = 0;
                        MarkscanProduct++;
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
