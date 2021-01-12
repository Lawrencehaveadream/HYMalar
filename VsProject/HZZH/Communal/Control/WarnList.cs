using HZZH.Common.Config;
using HZZH.UI2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.Communal.Control
{
    public partial class WarnList : BaseSubForm
    {
        public WarnList()
        {
            InitializeComponent();
            InitializeListView_Log();
        }
        private void InitializeListView_Log()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("时间", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("内容", 800, HorizontalAlignment.Left);

            listView2.View = View.Details;
            listView2.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView2.Columns.Add("时间", 150, HorizontalAlignment.Center);
            listView2.Columns.Add("内容", 800, HorizontalAlignment.Left);
        }
        /// <summary>
        /// 显示当前报警信息
        /// </summary>
        private void ShowCurrAlarmMsg()
        {        
            if ( Alarm.ErrorMap.Count>0)
            {
                if(Alarm.RefreshCurrAlamrMsgFlag)
                {
                    Alarm.RefreshCurrAlamrMsgFlag = false;
                    listView2.Items.Clear();
                    for (int i = 0; i < Alarm.ErrorMap.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ForeColor = Color.Red;
                        item.Text = (i + 1).ToString();
                        item.SubItems.Add(Alarm.ErrorMap[i].DataTime);
                        item.SubItems.Add(Alarm.ErrorMap[i].Msg);
                        if ((i % 2) > 0)
                        {
                            item.BackColor = System.Drawing.Color.PaleTurquoise;
                        }
                        listView2.Items.Add(item);
        
                        item.EnsureVisible();
                    }
                    listView2.Refresh();
                }
            }
           else
            {
                listView2.Items.Clear();
            }
        }
        string DeteleFile = "";
        private void WarnList_Load(object sender, EventArgs e)
        {
            LoadLogData(AppDomain.CurrentDomain.BaseDirectory + "Logs\\", DateTime.Now.ToString("yyyy-MM-dd"));
            DeteleFile = AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + dateTimePicker1.Value.ToString("yyyy-MM-dd");
            ShowAll();
            ShowCurrAlarmMsg(); 
        }
        public void ShowAll() {
            listView1.Items.Clear();
            if (Data==null)
            {
                return;
            }
            for (int i = 0; i < Data.log.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (i + 1).ToString();
                item.SubItems.Add(Data.log[i].AddTime);
                item.SubItems.Add(Data.log[i].Msg);
                if ((i % 2) > 0)
                {
                    item.BackColor = System.Drawing.Color.PaleTurquoise;
                }
                listView1.Items.Add(item);
                item.EnsureVisible();
            }
        }
        static  Common.Config.AlarmLog.LogsData Data = null;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            Data.log.Clear();
            LoadLogData(AppDomain.CurrentDomain.BaseDirectory + "Logs\\", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DeteleFile= AppDomain.CurrentDomain.BaseDirectory + "Logs\\"+ dateTimePicker1.Value.ToString("yyyy-MM-dd");
            ShowAll();
        }
        public static void LoadLogData(string path, string fileName)
        {
          
            string order = path + fileName;
            FileInfo file = new FileInfo(order);
            if (file.Exists == false)
            {
                return;
                throw new FileNotFoundException();
            }
            Common.Config.AlarmLog.LogsData logData = null;
            using (Stream stream = file.OpenRead())
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Common.Config.AlarmLog.LogsData));
                logData = xs.Deserialize(stream) as Common.Config.AlarmLog.LogsData;
                Data = logData;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show("确定删除?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (Data == null)
                {
                    return;
                }
                if (File.Exists(DeteleFile))
                {
                    File.Delete(DeteleFile);
                    Data.log.Clear();
                    Common.Config.AlarmLog.data2.log.Clear();
                    ShowAll();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMgr.ShowBack();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                ShowCurrAlarmMsg();
        }
    }
}
