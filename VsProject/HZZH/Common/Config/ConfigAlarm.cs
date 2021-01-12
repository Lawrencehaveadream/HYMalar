using System;
using System.Collections.Generic;
using System.IO;
using CommonRs;

namespace ConfigSpace
{
    [Serializable]
    public class ConfigAlarm : Config
    {
        private static string _name = "ErrorCode_App.csv";
        //报警配置文件的相对路径
        private static string _configName = string.Format("{0}", ConfigDirectory + "\\"+ _name);

        public ConfigAlarm() 
        {
            try
            {
                if (!File.Exists(_configName))
                {
                    StartUpdate.SendStartMsg("报警配置文件加载失败");
                }
                else
                {
                    List<string[]> ErrorCodeArr = Functions.CsvToStringArray(_configName, 0);
                    for (int i = 1; i <= 32; i++)
                    {
                        str_InputMsg[0, i - 1] = ErrorCodeArr[i + 1][2];
                        str_InputMsg[1, i - 1] = ErrorCodeArr[i + 1][5];
                        str_InputMsg[2, i - 1] = ErrorCodeArr[i + 1][8];
                        str_InputMsg[3, i - 1] = ErrorCodeArr[i + 1][11];
                        str_InputMsg[4, i - 1] = ErrorCodeArr[i + 1][14];
                        str_InputMsg[5, i - 1] = ErrorCodeArr[i + 1][17];
                        str_InputMsg[6, i - 1] = ErrorCodeArr[i + 1][20];
                        str_InputMsg[7, i - 1] = ErrorCodeArr[i + 1][23];
                        str_InputMsg[8, i - 1] = ErrorCodeArr[i + 1][26];
                        str_InputMsg[9, i - 1] = ErrorCodeArr[i + 1][29];
                        str_InputMsg[10, i - 1] = ErrorCodeArr[i + 1][32];
                        str_InputMsg[11, i - 1] = ErrorCodeArr[i + 1][35];
                        str_InputMsg[12, i - 1] = ErrorCodeArr[i + 1][38];
                        str_InputMsg[13, i - 1] = ErrorCodeArr[i + 1][41];
                        str_InputMsg[14, i - 1] = ErrorCodeArr[i + 1][44];
                        str_InputMsg[15, i - 1] = ErrorCodeArr[i + 1][47];
                        str_InputMsg[16, i - 1] = ErrorCodeArr[i + 1][50];
                        str_InputMsg[17, i - 1] = ErrorCodeArr[i + 1][53];
                        str_InputMsg[18, i - 1] = ErrorCodeArr[i + 1][56];
                        str_InputMsg[19, i - 1] = ErrorCodeArr[i + 1][59];
                    }
                }
                StartUpdate.SendStartMsg("报警配置文件加载成功");
            }
            catch (Exception ex)
            {
                StartUpdate.SendStartMsg("报警配置文件加载失败");
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件[{0}]失败!\n异常描述:{1}\n时间：{2}", _name, ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }


        private string[,] str_InputMsg = new string[20, 32];

        /// <summary>
        /// 报警信息
        /// </summary>
        public string[,] ErrorString
        {
            get 
            {
                return str_InputMsg;
            }
        }

        /// <summary>
        /// 返回当前报警List
        /// </summary>
        /// <param name="ErrorCode">报警码</param>
        /// <param name="ErrorLevel">报警等级</param>
        /// <param name="b_statusError">报警信息是否已经显示</param>
        /// <returns></returns>
        public List<string> ErrorInformation(int[] ErrorCode, int ErrorLevel, bool[,] b_statusError)
        {
            List<string> message = new List<string>(); 
            if (ErrorLevel< 1)
            {
                for (int m = 0; m < 20; m++)
                {
                    for (int n = 0; n < 32; n++)
                    {
                        b_statusError[m, n] = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        if ((ErrorCode[i] & (1 << j)) > 0)
                        {
                            int level = (i / 4) + 1;
                            int word = i % 4;
                            string msg = (string)str_InputMsg[i, j].Clone();
                            string str = "";
                            if (!b_statusError[i, j])
                            {
                                b_statusError[i, j] = true;
                                str = "L" + level.ToString() + "." + word.ToString() + "." + j.ToString() + "" + msg;
                                message.Add(str);
                            }
                        }
                    }
                }
            }
            return message;
        }
        /// <summary>
        /// 清除报警信息
        /// </summary>
        /// <param name="b_statusError"></param>
        public void ClearAlarmMessage(bool[,] b_statusError)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    b_statusError[i, j] = false;
                }
            }
        }
    }
}
