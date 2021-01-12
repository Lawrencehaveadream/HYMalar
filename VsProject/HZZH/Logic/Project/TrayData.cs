using CommonRs;
using HZZH.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Vision.PointLayout;

namespace HZZH.Logic.Project
{
    public enum SitePointAttribute
    {
        Normal,//
        Working,//
        Finish//点完
    }
    /// <summary>
    /// 工作点参数
    /// </summary>
    [Serializable]
    public class SitePoint : ProductBase,ICloneable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }        
        public bool Forbid { get; set; }//禁用    
        public int Product_num { get; set; }//产品
        public int SitePoint_num { get; set; }//点
        public int LableType { get; set; }//飞达类型，选用哪个飞达的物料贴附
        public int Nozzle_num { get; set; }//吸嘴号
        public string LableName//飞达号
        {
            get
            {
                switch (LableType)
                {
                    case 0:
                        return "飞达1";

                    case 1:
                        return "飞达2";

                    case 2:
                        return "飞达3";

                    case 3:
                        return "飞达4";

                    default:
                        return "飞达1";
                }
            }
        }
        public bool Selected { get; set; }
        public SitePointAttribute PointAttribute { get; set; }
        public SitePoint()
        {
            X = 1;
            Y = 1;
            Z = 1;
            R = 1;
            LableType = 1;
        }


        #region Mark点转换
        public SitePoint DoubleMarkChang(PointF Mark1, PointF Mark2, PointF Mark1_new, PointF Mark2_new)
        {
            SitePoint sitePoint = this.Clone();

            PointFCCD p = new PointFCCD();
            p.X = sitePoint.X;
            p.Y = sitePoint.Y;


            //p = StickCammera.AffineTransMachinePoint(Mark1, Mark2, Mark1_new, Mark2_new, p);

            sitePoint.X = p.X;
            sitePoint.Y = p.Y;

            return sitePoint;
        }
        public SitePoint MarkChang()
        {
            SitePoint sitePoint = this.Clone();

            PointFCCD p = new PointFCCD();
            p.X = sitePoint.X;
            p.Y = sitePoint.Y;
            
            sitePoint.X = p.X;
            sitePoint.Y = p.Y;

            return sitePoint;
        }
        #endregion


        object ICloneable.Clone()
        {
            SitePoint site = new SitePoint();
            site.X = this.X;
            site.Y = this.Y;
            site.Z = this.Z;
            site.R = this.R;
            site.LableType = this.LableType;
            site.Forbid = this.Forbid;
            site.Product_num = this.Product_num;
            site.SitePoint_num = this.SitePoint_num;
            return site;
        }

        public SitePoint Clone()
        {
            return (SitePoint)((ICloneable)this).Clone();
        }
    }

    [Serializable]
    public struct Rectangle2 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Phi { get; set; }
        public double Length1 { get; set; }
        public double Length2 { get; set; }

        public double Deg
        {
            get
            {
                return Phi * 180 / Math.PI;
            }
            set
            {
                Phi = value * Math.PI / 180;

            }
        }


        public PointF GetDirectPoint()
        {
            double AngleCos = Math.Cos(-Phi);
            double AngleSin = Math.Sin(-Phi);

            double midx = ((X + Length1 + 20 - X) * AngleCos - (Y - Y) * AngleSin + X);
            double midy = ((X + Length1 + 20 - X) * AngleSin + (Y - Y) * AngleCos + Y);

            return new PointF((float)midx, (float)midy);
        }

        public bool IsEmpty
        {
            get
            {
                return Length1 == 0 || Length2 == 0;
            }
        }

    }

    /// <summary>
    /// 产品参数
    /// </summary>
    [Serializable]
    public class ProductDef : ProductBase, ICloneable
    {
        public List<SitePoint> SiteList = new List<SitePoint>();//工作点

        public PointF4[] MarkPoint = new PointF4[2] { new PointF4(),new PointF4()};//扫描Mark点拍照位置

        public PointF2 CodePoint2 = new PointF2 ();//二维码点

        public PointF2 BackCT = new PointF2();//回拍检测点


        public PointF MarkPos1 { get; set; }
        public PointF MarkPos2 { get; set; }

        object ICloneable.Clone()
        {
            ProductDef pro = new ProductDef();
            foreach (SitePoint vs in this.SiteList)
            {
                pro.SiteList.Add(vs.Clone());
            }
            pro.MarkPoint[0].X  = this.MarkPoint[0].X;
            pro.MarkPoint[0].Y = this.MarkPoint[0].Y;
            pro.MarkPoint[1].X = this.MarkPoint[1].X;
            pro.MarkPoint[1].Y = this.MarkPoint[1].Y;

            pro.CodePoint2.X = this.CodePoint2.X;
            pro.CodePoint2.Y = this.CodePoint2.Y;

            pro.BackCT.X = this.BackCT.X;
            pro.BackCT.Y = this.BackCT.Y;

            pro.MarkPos1 = this.MarkPos1;
            pro.MarkPos2 = this.MarkPos2;

            return pro;
        }

        public ProductDef Clone()
        {
            return (ProductDef)((ICloneable)this).Clone();
        }


 

        [OnDeserialized()]
        private void OnDeserializedMething(StreamingContext context)
        {
            
        }
    }

    /// <summary>
    /// trey盘参数
    /// </summary>
    [Serializable]
    public class Tray : ProductBase,ILayoutPoint, ICloneable
    {
        public List<ProductDef> ProductList { get; set; } = new List<ProductDef>();//工单列表

        /// <summary>
        /// 模式 0：单Mark点 1：双Mark点  2：无Mark点
        /// </summary>
        public int MarkMode;
        /// <summary>
        /// 模式：true：扫描 false：不扫描
        /// </summary>
        //public bool CodeScan;

        public Rectangle2[] rectangle2 = new Rectangle2[2] { new Rectangle2(), new Rectangle2() };

        object ICloneable.Clone()
        {
            Tray tray = new Tray();

            foreach (ProductDef product in this.ProductList)
            {
                tray.ProductList.Add(product.Clone());
            }
            //tray.CodePoint2 = new PointF2(this.CodePoint.X, this.CodePoint.Y);
            tray.MarkMode = this.MarkMode;
            //tray.CodeScan = this.CodeScan;
            return tray;
        }

        public Tray Clone()
        {
            return (Tray)((ICloneable)this).Clone();
        }


        #region 显示
        private class SiteLayoutPoint : LayoutPoint
        {
            public SitePointAttribute PointAttribute { get; set; }
            public bool Forbid { get; set; }//禁用
            public const int MarkRidus = 2;

            public SiteLayoutPoint(SitePoint obj) : base(obj)
            {

            }
            public override void Drawing(Graphics gc)
            {
                if (Forbid)
                    gc.FillEllipse(Brushes.Red, Point.X - MarkRidus, Point.Y - MarkRidus, 2 * MarkRidus, 2 * MarkRidus);
                else
                    gc.FillEllipse(Brushes.Green, Point.X - MarkRidus, Point.Y - MarkRidus, 2 * MarkRidus, 2 * MarkRidus);
            }
        }

        public List<LayoutPoint> GetLayoutPoints()
        {
            List<LayoutPoint> layouts = new List<LayoutPoint>();
            foreach (var p in ProductList)
            {
                for (int i = 0; i < p.SiteList.Count; i++)
                {
                    SiteLayoutPoint site = new SiteLayoutPoint(p.SiteList[i])
                    {
                        Point = new PointF(p.SiteList[i].X, p.SiteList[i].Y),
                        PointAttribute = p.SiteList[i].PointAttribute,
                        Forbid = p.SiteList[i].Forbid

                    };
                    layouts.Add(site);
                }
            }
            return layouts;
        }
        #endregion
    }
}
