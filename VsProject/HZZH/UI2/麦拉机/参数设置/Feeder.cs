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
    public partial class Feeder : MenuForm
    {
        public Feeder()
        {
            InitializeComponent();
        }

        private void Feeder_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            FeederData.SetBindingDataSource(AllData.Data.Stickdata);
            var mm = AllData.Data.Stickdata.FeederPara.labelRow;
            InitVisionControl();
        }

        private void Obtain_Click(object sender, EventArgs e)
        {
            FeederPosX.Text = CTRCard.Axis_X.currPos.ToString("F2");
            FeederPosY.Text = CTRCard.Axis_Y.currPos.ToString("F2");
        }

        private void LocateFeederPos_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(FeederPosX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(FeederPosY.Text);
            TaskMain.move.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            XPos.Text = DeviceRsDef.Axis_X.currPos.ToString();
            YPos.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            Z1Pos.Text = DeviceRsDef.Axis_Z1.currPos.ToString();
            Z2Pos.Text = DeviceRsDef.Axis_Z2.currPos.ToString();
            //if (Database.Product.Inst.Stickdata.FeederPara.FeederMode[0] == true)
            //{
            //    FeederMode1.ForeColor = Color.Green;
            //    FeederMode2.ForeColor = Color.Black;
            //    FeederMode1.Checked = true;
            //    FeederMode2.Checked = false;
            //}
            //if (Database.Product.Inst.Stickdata.FeederPara.FeederMode[1] == true)
            //{
            //    FeederMode1.ForeColor = Color.Black;
            //    FeederMode2.ForeColor = Color.Green;
            //    FeederMode1.Checked = false; 
            //    FeederMode2.Checked = true;
            //}
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

        private void FeederMode1_CheckedChanged(object sender, EventArgs e)
        {
            if ((CheckBox)sender == FeederMode1) 
            {
                if (FeederMode1.Checked)
                {
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[0] = true;
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[1] = false;
                }
                else
                {
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[0] = false;
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[1] = true;
                }
            }
            else
            {
                if (FeederMode2.Checked)
                {
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[1] = true;
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[0] = false;
                }
                else
                {
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[1] = false;
                    Database.Product.Inst.Stickdata.FeederPara.FeederMode[0] = true; ;
                }
            }
        }


        HzVision.Device.MainCamera camera1;
        private void InitVisionControl()
        {
            camera1 = new  HzVision.Device.MainCamera();
            for (int i = 0; i < 6; i++)
            {
                camera1.ContextMenuStrip.Items[i].Visible = false;
            }
            camera1.Draw += Camera1_Draw;
            camera1.DisplayCross = true;
            this.Disposed += (s, e) => camera1.Dispose();
            panel1.Controls.Add(camera1);
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

            Product.Inst.TchRect.PrdRect.X = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Width / 2.0;
            Product.Inst.TchRect.PrdRect.Y = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Height / 2.0;

            double row = Product.Inst.TchRect.PrdRect.Y;
            double col = Product.Inst.TchRect.PrdRect.X;
            double phi = Product.Inst.TchRect.PrdRect.Angle * Math.PI / 180;
            double length1 = Math.Max(1, Product.Inst.TchRect.PrdRect.MajorAxis);
            double length2 = Math.Max(1, Product.Inst.TchRect.PrdRect.MinorAxis);
            e.HWindow.DispRectangle2(row, col, phi, length1, length2);
        }

    }
}
