using HZZH.UI.DerivedControl;
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
    public partial class AxisClient : CardMenu
    {
        public AxisClient()
        {
            InitializeComponent();
        }
        private void AxisClient_Load(object sender, EventArgs e)
        {
            Motor IOControl = new Motor();
            IOControl.TopLevel = false; 
            IOControl.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            IOControl.Size = PanelForAxis.Size;
            IOControl.Parent = PanelForAxis;//指定子窗体显示的容器
            IOControl.Dock = DockStyle.Fill;
            IOControl.AutoScaleMode = AutoScaleMode.None;
            IOControl.Show();
        }
    }
}
