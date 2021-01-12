using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRs;
using HZZH.Communal.Control;
using System.Windows.Forms;

namespace HZZH.Common.Config
{
    public enum AlarmLevelEnum
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
    }
    public class Alarm
    {
        public class ErrorMsg : IComparable<ErrorMsg>
        {
            public AlarmLevelEnum Lever { get; set; }//报警等级
            public string DataTime { get; set; }   //时间
            public string Msg { get; set; }    //报警信息

            public ErrorMsg(string msg) : this("",0, msg)
            { }

            public ErrorMsg(string dataTime,AlarmLevelEnum lever, string msg)
            {
                this.DataTime = dataTime;
                this.Lever = lever;
                this.Msg = msg;
            }

            public override bool Equals(object obj)
            {
                ErrorMsg other = obj as ErrorMsg;
                if (other != null)
                {
                    return Lever == other.Lever && Msg.Equals(other.Msg);
                }

                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return string.Format("Lever={0},Msg={1}", Lever, Msg);
            }

            public int CompareTo(ErrorMsg other)
            {
                return this.Lever - other.Lever;
            }
        }

        public static List<ErrorMsg> ErrorMap = new List<ErrorMsg>();

        /// <summary>
        /// 触发的报警事件
        /// </summary>
        public static event EventHandler AlarmError;

        /// <summary>
        /// 是否有报警
        /// </summary>
        public static bool HasAlarm
        {
            get
            {
                return ErrorMap.Count > 0;
            }
        }
        public static bool Canshowmessage { get; set; }
        /// <summary>
        /// 存在报警的的等级
        /// </summary>
        public static AlarmLevelEnum AlarmLever
        {
            get
            {
                try
                {
                    AlarmLevelEnum levle = 0;
                    for (int i = 0; i < ErrorMap.Count; i++)
                    {
                        if (ErrorMap[i].Lever > levle)
                        {
                            levle = ErrorMap[i].Lever;
                        }
                    }
                    return levle;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }

        /// <summary>
        /// 存在报警的信息
        /// </summary>
        public static string[] AlarmMsg
        {
            get
            {
                return ErrorMap.ConvertAll(error => error.Msg).ToArray();
            }
        }

        public static bool ErrorMapIsChange;
        public static bool RefreshCurrAlamrMsgFlag;//更新当前报警信息
        /// <summary>
        /// 设置报警
        /// </summary>
        /// <param name="lever"></param>
        /// <param name="msg"></param>
        public static void SetAlarm(AlarmLevelEnum lever, string msg)
        {

            ErrorMsg error = new ErrorMsg(DateTime.Now.ToString(), lever, msg);
            if (ErrorMap.Contains(error) == false)
            {
                ErrorMap.Add(error);
                //ErrorMap.Sort(Comparer<ErrorMsg>.Default);
                ErrorMapIsChange = true;
                RefreshCurrAlamrMsgFlag = true;
                ShowMessge.SendStartMsg(msg);  //报警
                EventHandler handler = AlarmError;
                if (handler != null)
                {
                    handler(error, EventArgs.Empty);
                }
                AlarmLog.AddLog(msg);
            }
        }

        /// <summary>
        /// 清除报警
        /// </summary>
        public static void ClearAlarm()
        {
            ErrorMap.Clear();
        }
        /// <summary>
        /// 初始化报警窗体所用定时器
        /// </summary>
        public static void TinerInit(bool IsokWarn = true)
        {
            if (IsokWarn)
            {
                Timer timer1 = new Timer();
                timer1.Enabled = true;
                timer1.Interval = 200;
                timer1.Tick += new System.EventHandler(timer1_Tick);
            }

        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            if (Alarm.Canshowmessage)
            {
                ShowWarn();
            }
        }

        static WarnForm FrmWarn = null;
        static bool hasAlarm;
        public static void ShowWarn()
        {

            if (Common.Config.Alarm.HasAlarm)
            {
                if(!ErrorMapIsChange)
                {
                    return;
                }
                ErrorMapIsChange = false;

                if (FrmWarn == null)
                {
                    FrmWarn = new WarnForm();
                    FrmWarn.Show();
                }
                else
                {
                    if (FrmWarn.IsDisposed)
                    {
                        FrmWarn = new WarnForm();
                        FrmWarn.Show();
                    }
                    else
                    {
                        FrmWarn.Show();
                    }
                }
            }
            else
            {
                hasAlarm = Common.Config.Alarm.HasAlarm;
                if (FrmWarn != null)
                {
                    FrmWarn.Close();
                }
            }
        }
    }
}
