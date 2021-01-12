using MyControl;
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
namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class IOPart : CardMenu
    {
        public IOPart()
        {
            InitializeComponent();
        }

        private void IOPart_Load(object sender, EventArgs e)
        {
            InputOutput IOControl = new InputOutput(DeviceRsDef.InputList, DeviceRsDef.OutputList);
            IOControl.TopLevel = false; 
            IOControl.FormBorderStyle = FormBorderStyle.None;
            IOControl.Size = panelForIO.Size;
            IOControl.Parent = panelForIO;
            IOControl.Dock = DockStyle.Fill;
            IOControl.Show();
            IOControl.doubleBufferListview1.Columns[0].Width = panelForIO.Width / 2 / 5 * 1-15;
            IOControl.doubleBufferListview1.Columns[1].Width = panelForIO.Width / 2 / 5 * 3;
            IOControl.doubleBufferListview1.Columns[2].Width = panelForIO.Width / 2 / 5 * 1-10;
            IOControl.doubleBufferListview2.Columns[0].Width = panelForIO.Width / 2 / 5 * 1-15;
            IOControl.doubleBufferListview2.Columns[1].Width = panelForIO.Width / 2 / 5 * 3;
            IOControl.doubleBufferListview2.Columns[2].Width = panelForIO.Width / 2 / 5 * 1-10;
        }
    }
}
