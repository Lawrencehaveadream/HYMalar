using HZZH.Common.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.Communal.Control
{
    public partial class WarnForm : Form
    {
        public WarnForm()
        {
            InitializeComponent();
            //this.ControlBox = false;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
            try
            {
                InitializeView();
            }
            catch
            { }
           
        }
        private void InitializeView()
        {
           
            try
            {
                if (!Alarm.HasAlarm ) return;
                for (int i = 1; i <= Alarm.ErrorMap.Count; i++)
                {
                    if (richTextBox1.Text.Contains(Alarm.AlarmMsg[i - 1]))
                    {

                    }
                    else
                    {
                        richTextBox1.AppendText(i.ToString() + "  " + Alarm.AlarmMsg[i - 1] + "\r\n");
                    }

                }
            }
            catch
            { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Alarm.ClearAlarm();
            this.Close();
            Alarm.Canshowmessage = false;
        }

        private static WarnForm instance;
        private static readonly object locker = new object();

        public static WarnForm Instance()
        {
            if (instance == null)
            {
                object locker = WarnForm.locker;
                lock (locker)
                {
                    if (instance == null || instance.Created == false)
                    {
                        instance = new WarnForm();
                    }
                }
            }
            return instance;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitializeView();
        }
    }
}
