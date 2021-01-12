using HzControl.Logic;
using HzVision.Device;
using HZZH.Communal.Control;
using HZZH.Communal.Tools;
using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
//using HZZH.Logic.LogicMain;
using HZZH.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.上料机
{
    public partial class MainRunForm : BaseSubForm
    {
        public MainRunForm()
        {
            InitializeComponent();
        }
        HomeStatusShow HomeStatusPage;
        private void MainRunForm_Load(object sender, EventArgs e)
        {
            Product.Inst.OperiterLevel = 0;
            userBingData1.SetBindingDataSource(Product.Inst);

           

        }

     

        //MainCamera camera1;
        //MainCamera camera2;
        //private void InitVisionControl()
        //{
        //    camera1 = new MainCamera();
        //    this.Disposed += (s, e) => camera1.Dispose();
        //    panel1.Controls.Add(camera1);
        //    camera1.Dock = DockStyle.Fill;
        //    camera1.ID = 0;

        //    camera2 = new MainCamera();
        //    this.Disposed += (s, e) => camera2.Dispose();
        //    panel2.Controls.Add(camera2);
        //    camera2.Dock = DockStyle.Fill;
        //    camera2.ID = 1;
        //}

        protected override void OnShown()
        {
            base.OnShown();
            //camera1.ID = 0;
            //camera2.ID = 1;
            //camera1.DisplayCross = true;
            //camera2.DisplayCross = true;
            //camera1.ContextMenuStrip = null;
            //camera2.ContextMenuStrip = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in TaskManager.Default.LogicTasks)
            {
                item.Reset();
            }
            HomeStatusPage = new HomeStatusShow();
            HomeStatusPage.FormBorderStyle = FormBorderStyle.None;
            HomeStatusPage.Show();
            FSM.Reset();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FSM.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FSM.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ProductName.Text = Product.Inst.Info.Name;
            Yield.Text = "产量：" + Product.Inst.ProductYield.Yield.ToString();
            UPH.Text ="UPH： " +  Product.Inst.ProductYield.UPH.ToString() + "/H";
            //level1.ComparetoWhichData(Product.Inst.OperiterLevel);//刷新用户等级权限
            label4.Text = "贴合周期：" + (TaskMain.sticklogic.takelabel.Lsticktime/1000.0 + TaskMain.sticklogic.takelabel.Rsticktime / 1000.0)/2.0 + " S";
            if (FSM.Status == FSMStaDef.STOP)
            {
                HomeStatusPage.Dispose();
            }
            switch (FSM.Status)
            {
                case FSMStaDef.INIT:
                    FsmSta.Text = "初始化";
                    FsmSta.ForeColor = Color.BlueViolet;
                    break;
                case FSMStaDef.STOP:
                    FsmSta.Text = "设备停止";
                    FsmSta.ForeColor = Color.Yellow;
                    break;
                case FSMStaDef.RESET:
                    FsmSta.Text = "复位中......";
                    FsmSta.ForeColor = Color.LightYellow;
                    break;
                case FSMStaDef.RUN:
                    FsmSta.Text = "设备运行";
                    FsmSta.ForeColor = Color.Green;
                    break;
                case FSMStaDef.SCRAM:
                    FsmSta.Text = "设备急停";
                    FsmSta.ForeColor = Color.Red;
                    break;
                case FSMStaDef.ALARM:
                    FsmSta.Text = "设备报警";
                    FsmSta.ForeColor = Color.YellowGreen;
                    break;
                case FSMStaDef.ERROR:
                    FsmSta.Text = "设备故障";
                    FsmSta.ForeColor = Color.Red;
                    break;
            }

        }
        private WarnList WarnListA = new WarnList();
        private void button9_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AllData.Data.ProductYield.ProductClear();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if( checkBox1.Checked)
            {
                Product.Inst.IsAging = true;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "启动将运行老化模式";
                mes.Show();
                checkBox1.ForeColor = Color.Blue;
            }
           else
            {
                Product.Inst.IsAging = false;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "启动将运行正常模式";
                mes.Show();
                checkBox1.ForeColor = Color.Black;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Product.Inst.Save(Product.Inst.Info.Name);
            HZZH.Logic.Commmon.DeviceRsDef.MotionCard.MotionFun.MotionData.AxisConfigPara.Save(Logic.Commmon.DeviceRsDef.MotionCard.port.ToString());
        }

        private void LNuuzleBan_CheckedChanged(object sender, EventArgs e)
        {
            if (LNuuzleBan.Checked)
            {
                Product.Inst.Stickdata.NuzzleForbit[0] = true;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "左侧吸嘴已禁用！";
                mes.Show();
                LNuuzleBan.ForeColor = Color.Red;
            }
            else
            {
                Product.Inst.Stickdata.NuzzleForbit[0] = false;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "左侧吸嘴已启用！";
                mes.Show();
                LNuuzleBan.ForeColor = Color.White;
            }
        }

        private void RNuuzleBan_CheckedChanged(object sender, EventArgs e)
        {
            if (RNuuzleBan.Checked)
            {
                Product.Inst.Stickdata.NuzzleForbit[1] = true;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "右侧吸嘴已禁用！";
                mes.Show();
                RNuuzleBan.ForeColor = Color.Red;
            }
            else
            {
                Product.Inst.Stickdata.NuzzleForbit[1] = false;
                MessageShowForm1 mes = new MessageShowForm1();
                mes.Word.Text = "右侧吸嘴已启用！";
                mes.Show();
                RNuuzleBan.ForeColor = Color.White;
            }
        }

     
    }
}
