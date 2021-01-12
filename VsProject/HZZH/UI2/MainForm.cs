using CommonRs;
using HZZH.Common.Config;
using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using MyControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            var va = Product.Inst;

            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.UpdateStyles();
            Alarm.TinerInit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FrmMgr.RegisterContainer(this.panel2);
            FrmMgr.Show("MainRunForm");
            TaskMain.Init();
            LoginBtn.DoubleClick += LoginBtn_DoubleClick;
            ConfigSpace.ConfigHandle.Instance.Load();
            Alarm.Canshowmessage = true;
        }
        private void LoginBtn_DoubleClick(object sender, EventArgs e)
        {
            if (LoginBtn.Text != "登 录")
            {
                MessageShowForm2 messageShowForm = new MessageShowForm2();
                messageShowForm.Word.Text = "确认退出当前用户";
                if (messageShowForm.ShowDialog(this) == DialogResult.OK)
                {
                    CurrentUser = null;
                    LoginBtn.Text = "登 录";
                    LoginBtn.BackColor = Color.Red;
                    Product.Inst.OperiterLevel = 0;
                    FrmMgr.Show("MainRunForm");
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            if ((((m.Msg != 0xa1) || (m.WParam.ToInt32() != 2)) && (m.Msg != 0xa3)) && (m.Msg != 20))
            {
                base.WndProc(ref m);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.Inst.Save();
            MessageShowForm2 messageShowForm = new MessageShowForm2();
            messageShowForm.TopMost = true;
            messageShowForm.Word.Text = "确认安全，正常退出软件？";
            if (messageShowForm.ShowDialog(this) == DialogResult.OK)
            {
                this.Close();
                Process pp = Process.GetCurrentProcess();
                if (pp != null)
                {
                    pp.Kill();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Card1Sta.ForeColor = DeviceRsDef.MotionCard.netSucceed ? Color.Green : Color.Red;
            if (Alarm.ErrorMap.Count>0)
            {
                AlarmBtn.BackColor = Color.Red;
            }
            else
            {
                AlarmBtn.BackColor = Color.Green;
            }
            Upcamera.ForeColor = HzVision.Device.CameraMgr.Inst[0].Connected ? Color.Green : Color.Red;
            Downcamera.ForeColor = HzVision.Device.CameraMgr.Inst[1].Connected ? Color.Green : Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alarm.Canshowmessage = true;
            for(int i=0;i< DeviceRsDef.AxisList.Count;i++)
            {
                DeviceRsDef.AxisList[i].MC_AlarmReset();
            }
            Alarm.ClearAlarm();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LoginBtn.Text == "登 录")
            {
                UserLogin frm = new UserLogin();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    UserMgrLogos(frm.GetCurrentUser());
                }
            }
            else
            {
                return;
            }
        }
        public static User CurrentUser = new User();
        private void UserMgrLogos(User user1)
        {
            try
            {
                if (user1.Type != "")
                {
                    CurrentUser = user1;
                    switch (user1.Type)
                    {
                        case "0":
                            LoginBtn.Text = "操作员";
                            LoginBtn.BackColor = Color.Green;
                            Product.Inst.OperiterLevel = 1;
                            break;
                        case "1":
                            LoginBtn.Text = "工程师";
                            LoginBtn.BackColor = Color.Green;
                            Product.Inst.OperiterLevel = 2;
                            break;
                        case "2":
                            LoginBtn.Text = "服务商";
                            LoginBtn.BackColor = Color.Green;
                            Product.Inst.OperiterLevel = 3;
                            break;
                        case "3":
                            LoginBtn.Text = "技术支持";
                            LoginBtn.BackColor = Color.Green;
                            Product.Inst.OperiterLevel = 4;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Downcamera_Click(object sender, EventArgs e)
        {

        }

        private void PassWordBtn_Click(object sender, EventArgs e)
        {
            if (Product.Inst.OperiterLevel <= 0)
            {
                return;
            }
            ChangeUserPwd pwd = new ChangeUserPwd();
            pwd.SetUser(CurrentUser);
            pwd.Show();
        }
        //protected override System.Windows.Forms.CreateParams CreateParams
        //{
        //    get
        //    {
        //        System.Windows.Forms.CreateParams createParams = base.CreateParams;
        //        createParams.ExStyle |= 0x80000;
        //        return createParams;
        //    }
        //}
    }
}
