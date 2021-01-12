using System;
using CommonRs;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using HZZH.UI2.麦拉机.参数设置;
using HZZH.Logic.Project;
using HZZH.UI2;

namespace UI
{
    public partial class Frm_ThreePArray : Form
    {
        public ProductForm ftemp;
        public Frm_ThreePArray()
        {
            InitializeComponent();
        }

        private void Frm_DPArr_Load(object sender, EventArgs e)
        {
            ftemp = (ProductForm)this.Owner;
        }
        private void btn_readleftup_Click(object sender, EventArgs e)
        {
            OneX.Text = DeviceRsDef.Axis_X.currPos.ToString("F2");
            OneY.Text = DeviceRsDef.Axis_Y.currPos.ToString("F2");
        }

        private void btn_readrightup_Click(object sender, EventArgs e)
        {
            TwoX.Text = DeviceRsDef.Axis_X.currPos.ToString("F2");
            TwoY.Text = DeviceRsDef.Axis_Y.currPos.ToString("F2");
        }

        private void btn_readrightdwon_Click(object sender, EventArgs e)
        {
            ThreeX.Text = DeviceRsDef.Axis_X.currPos.ToString("F2");
            ThreeY.Text = DeviceRsDef.Axis_Y.currPos.ToString("F2");
        }
        PointF3 pLeftUp = new PointF3();
        PointF3 pRightUp = new PointF3();
        PointF3 pRightDwon = new PointF3();
        private void buttonArr_Click(object sender, EventArgs e)
        {
            if ((!radioButton1.Checked) && (!radioButton2.Checked))
            {
                MessageBox.Show("请选择方向并确认");
                return;
            }
            int RowNum = Convert.ToInt32(Row.Text);
            int ColumnNum = Convert.ToInt32(Colum.Text);

            pLeftUp.X = Convert.ToSingle(OneX.Text);
            pLeftUp.Y = Convert.ToSingle(OneY.Text);


            pRightUp.X = Convert.ToSingle(TwoX.Text);
            pRightUp.Y = Convert.ToSingle(TwoY.Text);

            pRightDwon.X = Convert.ToSingle(ThreeX.Text);
            pRightDwon.Y = Convert.ToSingle(ThreeY.Text);
           
            int dripDirection = radioButton1.Checked ? 0 : 1;
            if (!ProductForm.flag_Arry)
                MatrixArrayList(pLeftUp, pRightUp, pRightDwon, RowNum, ColumnNum, dripDirection);
            else
            {
                if (HZZH.Database.Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
                {
                    if (HZZH.Database.Product.Inst.Stickdata.TrayData.ProductList.Count > ProductForm.product_num)
                        MatrixArrayProduct(pLeftUp, pRightUp, pRightDwon, RowNum, ColumnNum, dripDirection, HZZH.Database.Product.Inst.Stickdata.TrayData.ProductList[ProductForm.product_num]);
                    else
                        MatrixArrayProduct(pLeftUp, pRightUp, pRightDwon, RowNum, ColumnNum, dripDirection, HZZH.Database.Product.Inst.Stickdata.TrayData.ProductList[0]);
                }
                else
                    return;
            }
        }
        private void SetPasteDirction(int mode)
        {
            if (mode < 2)
            {
                if (mode == 0)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

            }
        }
        
        public List<SitePoint> tempPoint = new List<SitePoint>();
        public List<ProductDef> tempProduct = new List<ProductDef>();
        
        public void MatrixArrayList(PointF3 p1, PointF3 p2, PointF3 p3, int row, int column, int DripDirection)
        {
            float deltaX1, deltaY1, deltaX2, deltaY2;
            
            if (row <= 0 || column <= 0 || (row == 1 && column == 1)) return;

            if (row > 1)
            {
                deltaX1 = (p1.X - p2.X) / (row - 1);
                deltaY1 = (p1.Y - p2.Y) / (row - 1);
            }
            else
            {
                deltaX1 = p1.X - p2.X;
                deltaY1 = p1.Y - p2.Y;
            }

            if (column > 1)
            {
                deltaX2 = (p3.X - p2.X) / (column - 1);
                deltaY2 = (p3.Y - p2.Y) / (column - 1);
            }
            else
            {
                deltaX2 = p3.X - p2.X;
                deltaY2 = p3.Y - p2.Y;
            }


            List<PointF> termlist = new List<PointF>();

            #region 无隔离
            if (DripDirection == 0) //横向优先
            {
                for (int i = 0; i < row; i++)  //行
                {
                    for (int j = 0; j < column; j++)  //列
                    {
                        PointF stickPoint = new PointF();
                        if (i % 2 == 0)
                        {
                            stickPoint.X = p2.X + deltaX1 * j + deltaX2 * i;
                            stickPoint.Y = p2.Y + deltaY1 * j + deltaY2 * i;
                        }
                        else
                        {
                            stickPoint.X = p2.X + deltaX1 * (column - 1 - j) + deltaX2 * i;
                            stickPoint.Y = p2.Y + deltaY1 * (column - 1 - j) + deltaY2 * i;
                        }

                        termlist.Add(stickPoint);
                    }
                }
            }
            else if (DripDirection == 1) //纵向优先
            {
                for (int i = 0; i < column; i++)  //列
                {
                    for (int j = 0; j < row; j++)  //行
                    {
                        PointF stickPoint = new PointF();
                        if (i % 2 == 0)
                        {
                            stickPoint.X = p2.X + deltaX2 * j + deltaX1 * i;
                            stickPoint.Y = p2.Y + deltaY2 * j + deltaY1 * i;
                        }
                        else
                        {
                            stickPoint.X = p2.X + deltaX2 * (row - 1 - j) + deltaX1 * i;
                            stickPoint.Y = p2.Y + deltaY2 * (row - 1 - j) + deltaY1 * i;

                        }
                        termlist.Add(stickPoint);

                    }
                }
            }
            #endregion


            tempPoint = new List<SitePoint>();

            for (int i = 0; i < termlist.Count; i++)
            {
                SitePoint site = new SitePoint();
                site.X = termlist[i].X;
                site.Y = termlist[i].Y;
                tempPoint.Add(site);
            }


        }

        public void MatrixArrayProduct(PointF3 p1, PointF3 p2, PointF3 p3, int row, int column, int DripDirection, ProductDef products)
        {
            float deltaX1, deltaY1, deltaX2, deltaY2;
            //p2 中间点 

            if (row <= 0 || column <= 0 || (row == 1 && column == 1)) return;

            if (row > 1)
            {
                deltaX1 = (p1.X - p2.X) / (row - 1);
                deltaY1 = (p1.Y - p2.Y) / (row - 1);
            }
            else
            {
                deltaX1 = p1.X - p2.X;
                deltaY1 = p1.Y - p2.Y;
            }

            if (column > 1)
            {
                deltaX2 = (p3.X - p2.X) / (column - 1);
                deltaY2 = (p3.Y - p2.Y) / (column - 1);
            }
            else
            {
                deltaX2 = p3.X - p2.X;
                deltaY2 = p3.Y - p2.Y;
            }

            tempProduct.Clear();

            #region 无隔离
            if (DripDirection == 0) //横向优先
            {
                for (int i = 0; i < row; i++)  //行
                {
                    for (int j = 0; j < column; j++)  //列
                    {
                        ProductDef p = new ProductDef();
                        p = products.Clone();

                        for (int k = 0; k < p.SiteList.Count; k++)
                        {
                            p.SiteList[k].X += (i * deltaX1 + j * deltaX2);
                            p.SiteList[k].Y += (i * deltaY1 + j * deltaY2);
                            p.SiteList[k].Product_num = i + j;
                        }
                        p.MarkPoint[0].X += (i * deltaX1 + j * deltaX2);
                        p.MarkPoint[0].Y += (i * deltaY1 + j * deltaY2);

                        p.MarkPoint[1].X += (i * deltaX1 + j * deltaX2);
                        p.MarkPoint[1].Y += (i * deltaY1 + j * deltaY2);

                        p.CodePoint2.X += (i * deltaX1 + j * deltaX2);
                        p.CodePoint2.Y += (i * deltaY1 + j * deltaY2);

                        p.BackCT.X += (i * deltaX1 + j * deltaX2);
                        p.BackCT.Y += (i * deltaY1 + j * deltaY2);

                        tempProduct.Add(p);
                    }
                }
            }
            else if (DripDirection == 1) //纵向优先
            {
                for (int i = 0; i < column; i++)  //列
                {
                    for (int j = 0; j < row; j++)  //行
                    {
                        ProductDef p = new ProductDef();
                        p = products.Clone();

                        for (int k = 0; k < p.SiteList.Count; k++)
                        {
                            p.SiteList[k].X += (i * deltaX1 + j * deltaX2);
                            p.SiteList[k].Y += (i * deltaY1 + j * deltaY2);
                            p.SiteList[k].Product_num = i + j;
                        }
                        p.MarkPoint[0].X += (i * deltaX1 + j * deltaX2);
                        p.MarkPoint[0].Y += (i * deltaY1 + j * deltaY2);

                        p.MarkPoint[1].X += (i * deltaX1 + j * deltaX2);
                        p.MarkPoint[1].Y += (i * deltaY1 + j * deltaY2);

                        p.CodePoint2.X += (i * deltaX1 + j * deltaX2);
                        p.CodePoint2.Y += (i * deltaY1 + j * deltaY2);

                        p.BackCT.X += (i * deltaX1 + j * deltaX2);
                        p.BackCT.Y += (i * deltaY1 + j * deltaY2);

                        tempProduct.Add(p);
                    }
                }
            }
            #endregion

        }



    }
}
