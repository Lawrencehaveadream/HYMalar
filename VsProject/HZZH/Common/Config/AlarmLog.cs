using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Common.Config
{
    public class AlarmLog
    {
       static string Path = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";

        public static void SaveLogData(string fileName)
        {
            if (!Directory.Exists(@"Logs"))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(@"Logs"); //新建文件夹   
            }

            LogsData logData = new LogsData();
            logData.log = data2.log;
            FileInfo file = new FileInfo(Path+fileName);
            if (file.Directory.Exists == false)
            {
                file.Directory.Create();
            }
            using (Stream stream = file.Create())
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(logData.GetType());
                xs.Serialize(stream, logData);
            }

        }
        public static void LoadLogData(string path, string fileName)
        {
            if (!Directory.Exists(@"Logs"))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(@"Logs"); //新建文件夹   
            }
            string order = path + fileName;
            FileInfo file = new FileInfo(order);
            if (file.Exists == false)
            {
                return;
                throw new FileNotFoundException();
            }
            LogsData logData = null;
            using (Stream stream = file.OpenRead())
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(LogsData));
                logData = xs.Deserialize(stream) as LogsData;
                data2 = logData;
            }

        }
        /// <summary>
        /// 删除所有
        /// </summary>
        public void DeleteLog() {
            data.log.Clear();
        }
        /// <summary>
        /// 删除指定信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLog(int id)
        {
            data.log.RemoveAt(id);
        }
        public static LogsData data = new LogsData();//显示
        public static LogsData data2 = new LogsData();//内部保存使用数据
        static int index = 0;//记录添加日志数量，避免每次都保存占用CPU，这里设置10条保存一次
        /// <summary>
        /// 添加日志信息
        /// </summary>
        /// <param name="message"></param>
        public static void AddLog(string message) {
            Logs ls = new Logs(DateTime.Now.ToString(), message);
            data.log.Add(ls);
            data2.log.Add(ls);

            index = 0;
            string name = DateTime.Now.ToString("yyyy-MM-dd");
            SaveLogData(name);
        }

        [Serializable]
        public class LogsData
        {
            public List<Logs> log { get; set; }
            public LogsData() {
                log = new List<Logs>();
            }

        }
        [Serializable]
        public class Logs
        {
            public string AddTime { get; set; }
            public string Msg { get; set; }

            public Logs(string dt, string msg)
            {

                this.AddTime = dt;
                this.Msg = msg;
            }
            public Logs()
            {
                this.AddTime = DateTime.Now.ToString();
                this.Msg = "xx";
            }

        }
    }
}
