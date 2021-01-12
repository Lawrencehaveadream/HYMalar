using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using HZZH.UI2.上料机;
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
    public partial class MachinePara : Machine
    {
        public MachinePara()
        {
            InitializeComponent();
        }

        private void MachinePara_Load(object sender, EventArgs e)
        {
            Machine.SetBindingDataSource(Database.Product.Inst);
            timer1.Enabled = true;
            var mm = Database.Product.Inst.Stickdata.GiveUpPara.GiveUpBlowDelay;
            InitVisionControl();
        }

        private void myTextBox10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Xpos.Text = DeviceRsDef.Axis_X.currPos.ToString();
            Ypos.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            posX.Text = DeviceRsDef.Axis_X.currPos.ToString();
            posY.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            Z1pos.Text = DeviceRsDef.Axis_Z1.currPos.ToString();
            Z2pos.Text = DeviceRsDef.Axis_Z2.currPos.ToString();
        }

        private void Obtain1L_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.StickSysData.LiftCCDPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.StickSysData.LiftCCDPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void Obtain2L_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.StickSysData.LiftDownCCDPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.StickSysData.LiftDownCCDPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void Obtain3L_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.GiveUpPara.LiftGiveUpPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.GiveUpPara.LiftGiveUpPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void Obtain1R_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.StickSysData.RightCCDPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.StickSysData.RightCCDPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void Obtain2R_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.StickSysData.RightDownCCDPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.StickSysData.RightDownCCDPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void Obtain3R_Click(object sender, EventArgs e)
        {
            Database.Product.Inst.Stickdata.GiveUpPara.RightGiveUpPos.X = DeviceRsDef.Axis_X.currPos;
            Database.Product.Inst.Stickdata.GiveUpPara.RightGiveUpPos.Y = DeviceRsDef.Axis_Y.currPos;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(UptocaLX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(UptocaLY.Text);
            TaskMain.move.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(LNuzzlecaX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(LNuzzlecaX.Text);
            TaskMain.move.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(LgiveupX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(LgiveupY.Text);
            TaskMain.move.Start();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(UptocaRX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(UptocaRY.Text);
            TaskMain.move.Start();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(RNuzzlecaX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(RNuzzlecaX.Text);
            TaskMain.move.Start();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(RgiveupX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(RgiveupY.Text);
            TaskMain.move.Start();
        }

        private void button15_MouseUp(object sender, MouseEventArgs e)
        {

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
                        CTRCard.Axis_Z[0].MC_Stop();
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_Stop();
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_Stop();
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_Stop();
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_Stop();
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_Stop();
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
                        CTRCard.Axis_Z[0].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
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
                        CTRCard.Axis_Z[0].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                }
            }
        }
        #endregion

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
            camera1.ID = 0;
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

            Product.Inst.TchRect.MchnTeachRect.X = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Width / 2.0;
            Product.Inst.TchRect.MchnTeachRect.Y = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Height / 2.0;

            double row = Product.Inst.TchRect.MchnTeachRect.Y;
            double col = Product.Inst.TchRect.MchnTeachRect.X;
            double phi = Product.Inst.TchRect.MchnTeachRect.Angle * Math.PI / 180;
            double length1 = Math.Max(1, Product.Inst.TchRect.MchnTeachRect.MajorAxis);
            double length2 = Math.Max(1, Product.Inst.TchRect.MchnTeachRect.MinorAxis);
            e.HWindow.DispRectangle2(row, col, phi, length1, length2);
        }

      

    }
}
