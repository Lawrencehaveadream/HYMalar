using Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZZH.Logic.Commmon;

namespace HZZH.UI.DerivedControl
{
    public partial class Motor : Form
    {
        public Motor()
        {
            InitializeComponent();
            init();
            timer1.Enabled = true;
            timer1.Interval = 250;
        }
        AxisClass axis { get; set; }
        public void init()
        {
            Axisdata.Rows.Clear();
            Bangding();
            SpeedNum.Text = "50";
            label7.Text = "速度";
            Axisdata.ColumnCount = 7;
            Axisdata.Columns[0].Name = "轴编号";
            Axisdata.Columns[1].Name = "轴名称";
            Axisdata.Columns[2].Name = "运行速度";
            Axisdata.Columns[3].Name = "初速度";
            Axisdata.Columns[4].Name = "加速时间";
            Axisdata.Columns[5].Name = "末速度";
            Axisdata.Columns[6].Name = "减速时间";
            Axisdata.Columns[0].ReadOnly = true;
            Axisdata.Columns[1].ReadOnly = true;
            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                Axisdata.Rows.Add(new string[] { DeviceRsDef.AxisList[i].CardName +":"+ "轴" + (DeviceRsDef.AxisList[i].Index + 1),
                                                         DeviceRsDef.AxisList[i].AxisName,
                                                         DeviceRsDef.AxisList[i].AxisPara.RunSpeed.ToString(),
                                                         DeviceRsDef.AxisList[i].AxisPara.StartSpeed.ToString(),
                                                         DeviceRsDef.AxisList[i].AxisPara.Acctime.ToString(),
                                                         DeviceRsDef.AxisList[i].AxisPara.EndSpeed.ToString(),
                                                         DeviceRsDef.AxisList[i].AxisPara.Dectime.ToString(),
                });

            }
        }
        private void Bangding()
        {
            ConfigJog(control.Pos, button1);
            ConfigJog(control.Neg, button2);
            ConfigJog(control.Stop, button4);
        }

        #region 按键事件
        /// <summary>
        /// 移动距离
        /// </summary>
        public float _targetPos = 1;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float _speed = 5;

        public int _mode = 1;

        private void ConfigJog(control type, Button _b)
        {
            _b.MouseDown -= btn_JogAxisNeg_MouseDown;
            _b.MouseDown -= btn_JogAxisPos_MouseDown;
            _b.MouseUp -= btn_JogAxis_MouseUp;
            _b.Click -= btn_Home_Click;
            switch (type)
            {
                case control.Pos:
                    _b.MouseDown += btn_JogAxisPos_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case control.Neg:
                    _b.MouseDown += btn_JogAxisNeg_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case control.Hom:
                    _b.Click += btn_Home_Click;
                    break;
            }
        }
        private void btn_JogAxisPos_MouseDown(object sender, MouseEventArgs e)
        {
            _targetPos = Convert.ToInt32(StepNum.Text);
            _speed = Convert.ToInt32(SpeedNum.Text);

            if (e.Button == MouseButtons.Left)
            {
                _mode = 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                _mode = 0;
            }

            JogAxisPos(_mode, _speed, _targetPos);
        }

        private void btn_JogAxis_MouseUp(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);

            if (e.Button == MouseButtons.Left)
            {
                _mode = 1;
            }
            else
            {
                _mode = 0;
            }
            JogAxisStop((ushort)axis, _mode);
        }

        private void btn_JogAxisNeg_MouseDown(object sender, MouseEventArgs e)
        {
            _targetPos = Convert.ToInt32(StepNum.Text);
            _speed = Convert.ToInt32(SpeedNum.Text);
            if (e.Button == MouseButtons.Left)
            {
                _mode = 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                _mode = 0;
            }

            JogAxisNeg(_mode, _speed, _targetPos);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            Button _btn = sender as Button;
        }
        public void JogAxisNeg(int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
                axis.MC_MoveSpd(jogSpeed, -targetPos);
            }

            else
            {
                axis.MC_MoveRel(jogSpeed, -targetPos);
            }
        }

        public void JogAxisPos(int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
                axis.MC_MoveSpd(jogSpeed, targetPos);
            }
            else
            {
                axis.MC_MoveRel(jogSpeed, targetPos);
            }
        }
        public void JogAxisStop(ushort axisNum, int mode)
        {
            if (mode == 0)
            {
                axis.MC_StopDec();
            }
        }
        #endregion
        int Selectedindex = -1;
        private void Axisdata_SelectionChanged(object sender, EventArgs e)
        {
            Selectedindex = Axisdata.SelectedRows[0].Index;

            axis = DeviceRsDef.AxisList[Selectedindex];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axis != null)
            {
                label1.Text = "轴位置：" + axis.currPos.ToString();
                //string mm = axis.errMesg.Split(':');
                string mes = axis.errMesg.Replace("_" + axis.AxisName.ToString() + ":", " ");
                label2.Text = "轴信息：" + axis.errMesg;
                if (axis.errCode == 0)
                {
                    label2.ForeColor = Color.DarkBlue;
                    label2.Text = "轴信息：" + axis.errMesg.Substring(axis.errMesg.Length - 2);
                }
                else
                {
                    label2.ForeColor = Color.DarkRed;
                    label2.Text = "轴信息：" + axis.errMesg.Substring(axis.errMesg.Length - 2);
                }
                label11.Text = "轴名称：" + axis.AxisName;
            }
        }

        private void Axisdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DeviceRsDef.AxisList[Selectedindex].AxisPara.RunSpeed = Convert.ToInt32(Axisdata.Rows[Selectedindex].Cells[2].Value);
            DeviceRsDef.AxisList[Selectedindex].AxisPara.StartSpeed = Convert.ToInt32(Axisdata.Rows[Selectedindex].Cells[3].Value);
            DeviceRsDef.AxisList[Selectedindex].AxisPara.Acctime = Convert.ToInt32(Axisdata.Rows[Selectedindex].Cells[4].Value);
            DeviceRsDef.AxisList[Selectedindex].AxisPara.EndSpeed = Convert.ToInt32(Axisdata.Rows[Selectedindex].Cells[5].Value);
            DeviceRsDef.AxisList[Selectedindex].AxisPara.Dectime = Convert.ToInt32(Axisdata.Rows[Selectedindex].Cells[6].Value);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Selectedindex >=0)
                {
                    axis.MC_Home();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请选择轴");
            }
        }
    }
}
