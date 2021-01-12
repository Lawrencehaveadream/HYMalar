using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using HzVision.Device;
using Vision.Tool.Calibrate;
using Vision.Tool.Model;
using HzControl.Communal.Controls;
using HZZH.Logic.Commmon;
using HZZH.Database;
using HZZH.UI2.上料机;

namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class VisCalib : MenuForm
    {
        public VisCalib()
        {
            InitializeComponent();
        }

        private void VisCalib_Load(object sender, EventArgs e)
        {
            ProductForm form = FrmMgr.GetFormInst<ProductForm>(0);
            UserBingData.SetBinding(form.Lcheck, "Checked", this.checkBox6, "Checked");
            UserBingData.SetBinding(form.Step, "Text", this.myTextBox2, "Text");

            button15.MouseDown += (s, ev) => form.button2_MouseDown(form.button5, ev);
            button14.MouseDown += (s, ev) => form.button2_MouseDown(form.button2, ev);
            button7.MouseDown += (s, ev) => form.button2_MouseDown(form.button19, ev);
            button6.MouseDown += (s, ev) => form.button2_MouseDown(form.button7, ev);
            button2.MouseDown += (s, ev) => form.button2_MouseDown(form.button21, ev);
            button5.MouseDown += (s, ev) => form.button2_MouseDown(form.button20, ev);

            button15.MouseUp += (s, ev) => form.button17_MouseUp(form.button5, ev);
            button14.MouseUp += (s, ev) => form.button17_MouseUp(form.button2, ev);
            button7.MouseUp += (s, ev) => form.button17_MouseUp(form.button19, ev);
            button6.MouseUp += (s, ev) => form.button17_MouseUp(form.button7, ev);
            button2.MouseUp += (s, ev) => form.button17_MouseUp(form.button21, ev);
            button5.MouseUp += (s, ev) => form.button17_MouseUp(form.button20, ev);


        }



        private PointF p1, p2;
        private float step = 1;
        private float calibHeight = 0;
        private List<PointF> movePoints = new List<PointF>();

        private static ShapeModel shapeXLDModel = new ShapeModel();
        private bool IsCalibrationRun = false;

        public CalibSet CalibSetData { get; set; }


        private bool GenMovePoints()
        {
            int sx = (int)Math.Abs((p1.X - p2.X) / step);
            int sy = (int)Math.Abs((p1.Y - p2.Y) / step);
            if(sx<4||sy<4)
            {
                MessageBox.Show("减小移动间距");
                return false;
            }

            movePoints.Clear();
            for (int i = 0; i < sy; i++)
            {
                for (int j = 0; j < sx; j++)
                {
                    PointF p = new PointF();
                    if (i % 2 == 0)
                    {
                        if (p1.X < p2.X)
                        {
                            p.X = p1.X + j * step;
                        }
                        else
                        {
                            p.X = p1.X - j * step;
                        }
                        
                    }
                    else
                    {
                        if (p1.X < p2.X)
                        {
                            p.X = p2.X - j * step;
                        }
                        else
                        {
                            p.X = p2.X + j * step;
                        }
                       
                    }
                    if (p1.Y < p2.Y)
                    {
                        p.Y = p1.Y + i * step;
                    }
                    else
                    {
                        p.Y = p1.Y - i * step;
                    }
                    
                    movePoints.Add(p);
                }
            }

            return true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            p1.X = CalibSetData.PlatformMove.AxisPosition[0];
            p1.Y = CalibSetData.PlatformMove.AxisPosition[1];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            p2.X = CalibSetData.PlatformMove.AxisPosition[0];
            p2.Y = CalibSetData.PlatformMove.AxisPosition[1];
        }

        private void button10_Click(object sender, EventArgs e)
        {
            calibHeight = CalibSetData.PlatformMove.AxisPosition[2];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HImage himage = CalibSetData.GetImage.GetCurrentImage();
            shapeXLDModel.InputImg.Dispose();
            shapeXLDModel.InputImg = himage;
            shapeXLDModel.ShowSetting();
        }

        private void myTextBox1_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(myTextBox1.Text, out step);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.IsCalibrationRun)
            {
                if (MessageBox.Show("确定停止标定动作？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    IsCalibrationRun = false;
                }
            }
            else
            {
                IsCalibrationRun = true;
                new Action(() => { AutoMoveAxisCalibrate(); }).BeginInvoke(null, null);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ShapeMatchResult OutPutResults = FindShapeModel();
                int imgWidth, imgHeight;
                shapeXLDModel.InputImg.GetImageSize(out imgWidth, out imgHeight);

                float x = 0, y = 0;
                bool flag = false;
                if (OutPutResults.Count > 0)
                {
                    PointF matchPoint = new PointF((float)OutPutResults.Col[0].F, (float)OutPutResults.Row[0].F);
                    PointF machinePoint;
                    PointF imgReferPoint = new PointF(imgWidth / 2f, imgHeight / 2f);

                    PointF CurrentLocation = new PointF();
                    CurrentLocation.X = CalibSetData.PlatformMove.AxisPosition[0];
                    CurrentLocation.Y = CalibSetData.PlatformMove.AxisPosition[1];
                    CalibSetData.Calib.PixelPointToWorldPoint(matchPoint, out machinePoint, imgReferPoint, CurrentLocation);


                    x = machinePoint.X;
                    y = machinePoint.Y;
                    flag = true;
                }

                if (flag == false)
                {
                    MessageBox.Show("无匹配结果");
                }
                else
                {
                    {
                        string info = "分数：" + OutPutResults.Score[0].F.ToString("f2") + ",X偏移" + (x - CalibSetData.PlatformMove.AxisPosition[0]).ToString("f2") + 
                            "，Y偏移" + (y - CalibSetData.PlatformMove.AxisPosition[1]).ToString("f2") + ",是否移动到中心点？";
                        if (MessageBox.Show(info, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            new Action(() =>
                            {
                                CalibSetData.PlatformMove.AbsMoving((float)x, (float)y, calibHeight);
                                CalibSetData.PlatformMove.WaitOnCompleteMoving();
                                Thread.Sleep(300);
                                FindShapeModel();
                            }).BeginInvoke(null, null);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("定位失败:" + ex.Message);
            }
        }

        private ShapeMatchResult FindShapeModel()
        {
            HImage hImage = CalibSetData.GetImage.GetCurrentImage();
            shapeXLDModel.InputImg.Dispose();
            shapeXLDModel.InputImg = hImage;
            shapeXLDModel.FindModel();

            return shapeXLDModel.OutputResult;
        }

        private void mainCamera1_Draw(object sender, DrawEventArgs e)
        {
            if (CalibSetData != null)
            {
                HTuple row, col;
                CalibSetData.Calib.GetCalibrateDataPixelPoint(out row, out col);

                e.HWindow.SetColor("green");
                e.HWindow.DispCross(row, col, 96, 0);
                if (CalibSetData.Calib.IsBuiltted)
                {
                    CalibSetData.Calib.GetCalibrateDataTransWorldPoint(out row, out col);
                    e.HWindow.SetColor("yellow");
                    e.HWindow.DispCross(row, col, 66, 0);
                }
            }
        }

        private void AutoMoveAxisCalibrate()
        {
            if (!GenMovePoints())
            {
                IsCalibrationRun = false;
                return;
            }

            movePoints.Add(new PointF(CalibSetData.PlatformMove.AxisPosition[0], CalibSetData.PlatformMove.AxisPosition[1]));

            bool IsClearCalibrateData = false;

            for (int i = 0; i < movePoints.Count && IsCalibrationRun == true; )
            {
                CalibSetData.PlatformMove.AbsMoving(movePoints[i].X, movePoints[i].Y, calibHeight);
                if (!CalibSetData.PlatformMove.WaitOnCompleteMoving(5000))
                {
                    continue;
                }
                Thread.Sleep(1000);

                CalibSetData.GetImage.CameraSoft();
                if (!CalibSetData.GetImage.WaiteGetImage(2000))
                {
                    i++;
                    continue; ;
                }
                ShapeMatchResult OutPutResults = FindShapeModel();
                if (OutPutResults.Count == 0)
                {
                    i++;
                    continue;
                }

                if (OutPutResults.Count > 0)
                {
                    if (!IsClearCalibrateData)
                    {
                        CalibSetData.Calib.ClearCalibrationData();
                        IsClearCalibrateData = true;
                    }

                    CalibSetData.Calib.AddCalibratePoint(OutPutResults.Row[0].F, OutPutResults.Col[0].F, movePoints[i].X, movePoints[i].Y);
                }

                i++;

                Thread.Sleep(100);
            }

            if (IsCalibrationRun == true)
            {
                CalibSetData.Calib.BuildTransferMatrix();
                IsCalibrationRun = false;
                if (CalibSetData.Calib.IsBuiltted)
                {
                    MessageBox.Show("标定成功,像素误差" + CalibSetData.Calib.CalibrateError().ToString("f3"), "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    Product.Inst.Save();
                }
                else
                {
                    MessageBox.Show("标定失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }

            }
        }

        protected override void OnShown()
        {
            base.OnShown();
            this.mainCamera1.ID = ((CameraDevice)CalibSetData.GetImage).CameraConfig.Number;
            this.mainCamera1.ContextMenuStrip = null;
            this.mainCamera1.DisplayCross = true;
        }

        protected override void OnHide()
        {
            base.OnHide();

            this.IsCalibrationRun = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button10.Text = "设定高度:(" + calibHeight.ToString("f2")+"mm)";
            button12.BackColor = IsCalibrationRun ? Color.Green : SystemColors.Control;
            string str = "缩放sx：{0:f3}          缩放sy：{1:f3}\r\n角度r： {2:f3}          误差:   {3:f3}\r\n";
            if (CalibSetData != null && CalibSetData.Calib.IsBuiltted)
            {
                label2.Text=string.Format(str, CalibSetData.Calib.Sx, CalibSetData.Calib.Sy, CalibSetData.Calib.Phi, CalibSetData.Calib.CalibrateError());
            }
            else
            {
                label2.Text = string.Format(str, 0, 0, 0,0);
            }
            if (CalibSetData != null && CalibSetData.PlatformMove != null)
            {
                X_currPos.Text = "X:" + CalibSetData.PlatformMove.AxisPosition[0].ToString("00.00");
                Y_currPos.Text = "Y:" + CalibSetData.PlatformMove.AxisPosition[1].ToString("00.00");
                Z_currPos.Text = "Z:" + CalibSetData.PlatformMove.AxisPosition[2].ToString("00.00");

            }
        }

        
    }

    public class CalibSet
    {
        public IPlatformMove PlatformMove { get; set; }

        public IGrabHImage GetImage { get; set; }
        public CalibPointToPoint Calib { get; set; }
    }
}
