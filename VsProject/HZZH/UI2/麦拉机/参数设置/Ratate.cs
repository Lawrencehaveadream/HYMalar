using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class Ratate : Machine
    {
        public Ratate()
        {
            InitializeComponent();
        }

        private void Ratate_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Rotate.SetBindingDataSource(HZZH.Database.Product.Inst);
            var mm = Database.Product.Inst.Stickdata.StickSysData.Right000CCDPos.X; ;
            InitVisionControl();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Xpos.Text = DeviceRsDef.Axis_X.currPos.ToString();
            Ypos.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            posX.Text = DeviceRsDef.Axis_X.currPos.ToString();
            posY.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            R1pos.Text = DeviceRsDef.Axis_R1.currPos.ToString();
            R2pos.Text = DeviceRsDef.Axis_R2.currPos.ToString();
        }
        #region 轴动
        private void button17_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_Stop();
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_Stop();
                        break;
                    case 3:
                        CTRCard.Axis_R[0].MC_Stop();
                        break;
                    case 4:
                        CTRCard.Axis_R[1].MC_Stop();
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_Stop();
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_Stop();
                        break;
                    case -3:
                        CTRCard.Axis_R[0].MC_Stop();
                        break;
                    case -4:
                        CTRCard.Axis_R[1].MC_Stop();
                        break;
                }
            }
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 3:
                        CTRCard.Axis_R[0].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 4:
                        CTRCard.Axis_R[1].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -3:
                        CTRCard.Axis_R[0].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -4:
                        CTRCard.Axis_R[1].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                }
            }
            if (Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 3:
                        CTRCard.Axis_R[0].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 4:
                        CTRCard.Axis_R[1].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -3:
                        CTRCard.Axis_R[0].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -4:
                        CTRCard.Axis_R[1].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                }
            }
        }
        #endregion

        private void Obtain1_Click(object sender, EventArgs e)
        {
            LDownCCDX.Text = CTRCard.Axis_X.currPos.ToString("F2");
            LDownCCDY.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Obtain2_Click(object sender, EventArgs e)
        {
            L000X.Text = CTRCard.Axis_X.currPos.ToString("F2");
            L000Y.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Obtain3_Click(object sender, EventArgs e)
        {
            L180X.Text = CTRCard.Axis_X.currPos.ToString("F2");
            L180Y.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Obtain4_Click(object sender, EventArgs e)
        {
            RDownCCDX.Text = CTRCard.Axis_X.currPos.ToString("F2");
            RDownCCDY.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Obtain5_Click(object sender, EventArgs e)
        {
            R000X.Text = CTRCard.Axis_X.currPos.ToString("F2");
            R000Y.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Obtain6_Click(object sender, EventArgs e)
        {
            R180X.Text = CTRCard.Axis_X.currPos.ToString("F2");
            R180Y.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void Locate1_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(LDownCCDX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(LDownCCDY.Text);
            TaskMain.move.Start();
        }

        private void Locate2_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(L000X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(L000Y.Text);
            TaskMain.move.Start();
        }

        private void Locate3_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(L180X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(L180Y.Text);
            TaskMain.move.Start();
        }

        private void Locate4_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(RDownCCDX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(RDownCCDY.Text);
            TaskMain.move.Start();
        }

        private void Locate5_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(R000X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(R000Y.Text);
            TaskMain.move.Start();
        }

        private void Locate6_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(R180X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(R180Y.Text);
            TaskMain.move.Start();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var para = Database.Product.Inst.Stickdata.StickSysData;
            para.LiftRatateR = System.Math.Abs(para.Lift000CCDPos.X - para.Lift180CCDPos.X)/2;
            para.Liftcirclepoint.X = (para.Lift000CCDPos.X + para.Lift180CCDPos.X) / 2;
            para.Liftcirclepoint.Y = (para.Lift000CCDPos.Y + para.Lift180CCDPos.Y) / 2;
        }
        private void button27_Click(object sender, EventArgs e)
        {
            var para = Database.Product.Inst.Stickdata.StickSysData;
            para.RightRatateR =  System.Math.Abs(para.Right000CCDPos.X - para.Right180CCDPos.X) / 2;
            para.Rightcirclepoint.X = (para.Right000CCDPos.X + para.Right180CCDPos.X) / 2;
            para.Rightcirclepoint.Y = (para.Right000CCDPos.Y + para.Right180CCDPos.Y) / 2;
        }


        HzVision.Device.MainCamera camera1;
        private void InitVisionControl()
        {
            camera1 = new HzVision.Device.MainCamera();
            for (int i = 0; i < 6; i++)
            {
                camera1.ContextMenuStrip.Items[i].Visible = false;
            }
            camera1.Draw += Camera1_Draw;
            camera1.DisplayCross = true;
            this.Disposed += (s, e) => camera1.Dispose();
            panel2.Controls.Add(camera1);
            camera1.Dock = DockStyle.Fill;
            camera1.ID = 1;
        }

        protected override void OnShown()
        {
            base.OnShown();
            camera1.ID = 0;
        }

        private void Camera1_Draw(object sender, HzVision.Device.DrawEventArgs e)
        {
            e.HWindow.SetDraw("margin");
            e.HWindow.SetColor("blue");
            e.HWindow.SetLineWidth(1);

            Product.Inst.TchRect.DownCamTeachRect.X = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Width / 2.0;
            Product.Inst.TchRect.DownCamTeachRect.Y = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Height / 2.0;

            double row = Product.Inst.TchRect.DownCamTeachRect.Y;
            double col = Product.Inst.TchRect.DownCamTeachRect.X;
            double phi = Product.Inst.TchRect.DownCamTeachRect.Angle * Math.PI / 180;
            double length1 = Math.Max(1, Product.Inst.TchRect.DownCamTeachRect.MajorAxis);
            double length2 = Math.Max(1, Product.Inst.TchRect.DownCamTeachRect.MinorAxis);
            e.HWindow.DispRectangle2(row, col, phi, length1, length2);
        }

    }
}
