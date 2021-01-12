using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ApiClass;
using System.Security.Cryptography;


namespace LicenseManagement
{
    public class LicenseMsg
    {
        private BackgroundWorker backworkerZ;       
        private DateTime MachineDateTime;
        private string cpuID;
        public Exception timeException = null;
        public DateTime DateIssuingDate;

        public DateTime DatePermitDate;


        public static bool RegisterSucceed { get; set; }
        public static DateTime timeState;


        public LicenseMsg(string id, DateTime dateTime)
        {
            this.cpuID = id;
            this.MachineDateTime = dateTime;

            backworkerZ = new BackgroundWorker();       
            //backworker.WorkerReportsProgress = true;
            backworkerZ.WorkerSupportsCancellation = true;
            backworkerZ.DoWork += dowork;
            //backworker.ProgressChanged += UpdateProgress;

            backworkerZ.RunWorkerAsync();
        }

        public LicenseMsg(string id, DateTime dateTime, DateTime str_IssuingDate,DateTime _PermitDate)
        {
            try
            {
                this.DateIssuingDate = str_IssuingDate;
                this.DatePermitDate = _PermitDate;

                this.cpuID = id;
                this.MachineDateTime = dateTime;
                int o1 = AESHelper.ConvertDateTimeInt(MachineDateTime);

                //int o3 = AESHelper.ConvertDateTimeInt(str_IssuingDate);
                //更新储存系统时间
                string savestr = cpuID + "H" + o1.ToString() + "S";
                var msg = AESHelper.Encrypt(savestr, "qwertyuiop");

                //string[] msg1 = { msg, o3.ToString() };

                Api.WriteDog(msg.ToString(), 128);
            }
            catch (Exception ex)
            {
                throw new Exception("licenseMsg操作错误:"+ex.Message);
            }
            backworkerZ = new BackgroundWorker();
            backworkerZ.WorkerReportsProgress = true;
            backworkerZ.WorkerSupportsCancellation = true;
            backworkerZ.DoWork += dowork;

            backworkerZ.ProgressChanged += UpdateProgress;

            backworkerZ.RunWorkerAsync();
        }

        bool bIsEnter = false;
        DateTime RealDateTime, integralDate;
        private void dowork(Object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (worker.CancellationPending == false)
            {
                Thread.Sleep(500);
                 RealDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                 integralDate = new DateTime(RealDateTime.Year, RealDateTime.Month, RealDateTime.Day, RealDateTime.Hour, 0, RealDateTime.Second);

                 RegisterSucceed = ((timeState - DateTime.Now).Days <= 5) ? true : false;

                 if (DateTime.Compare(RealDateTime, MachineDateTime) < 0)
                 {
                     #region 系统时间错误需重启软件
                     timeException = new Exception("系统时间错误：" + MachineDateTime.ToString() + "/" + RealDateTime.ToString());
                     backworkerZ.CancelAsync();
                     return;

                     #endregion


                     #region 系统时间错误不需要重启软件
                     //if (timeException == null)
                     //{
                     //    timeException = new Exception("系统时间错误：" + MachineDateTime.ToString() + "/" + RealDateTime.ToString());
                     //}
                     #endregion
                 }
                 else
                 {
                     if (timeException != null)
                     {
                         timeException = null;
                     }
                 }
                               
                if (DateTime.Compare(RealDateTime, integralDate) == 0 && !bIsEnter)
                {

                    bIsEnter = true;
                    //Thread.Sleep(2);

                     RealDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                    worker.ReportProgress(0, RealDateTime);
                }


                if (DateTime.Compare(RealDateTime, integralDate)>0)
                {
                    bIsEnter =false;
                }
            }
            //e.Result = numCount;
        }

        private void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            DateTime termDate = (DateTime)e.UserState;

            //int o1 = AESHelper.ConvertDateTimeInt(MachineDateTime);
            int o2 = AESHelper.ConvertDateTimeInt(termDate);
            //int o3 = AESHelper.ConvertDateTimeInt(DateIssuingDate);

            //if ((o2 >= o1))
            if (DateTime.Compare(termDate, MachineDateTime)>=0)
            {
              
                //更新储存系统时间
                string savestr = cpuID + "H" + o2 + "S";
                var msg = AESHelper.Encrypt(savestr, "qwertyuiop");
                //string[] msg1 = { msg, o3.ToString() };
                //string[] msg1 = { msg, o3.ToString() };

                Thread dfd = new Thread(new ParameterizedThreadStart(savefile));
                dfd.Start(msg);



                if (DateTime.Compare(termDate, new DateTime(DatePermitDate.Year, DatePermitDate.Month, DatePermitDate.Day, 12, 0, 0))>= 0)
                {
                    //if (termDate >= DatePermitDate)
                    {
                        // 系统时间错误
                        timeException = new Exception("注册时间到期：" + DatePermitDate.ToString() + "/" + termDate.ToString());
                        backworkerZ.CancelAsync();
                        return;
                    }
                }

                MachineDateTime = termDate;
            }
            else
            {
                // 系统时间错误
                timeException = new Exception("系统时间错误：" + MachineDateTime.ToString() + "/" + termDate.ToString());
                backworkerZ.CancelAsync();
                return;
            }

        }


        object ob = new object();
        private void savefile(object msg1)
        {
            lock (ob)
            {
                lock (ob)
                {
                    Api.WriteDog(msg1.ToString(), 128);
                }
            }
        }


        public static void Save(object obj, string filePath)
        {
            byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 91 };
            byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 95 };
            RijndaelManaged myRijndael = new RijndaelManaged();
            FileStream fsOut = File.Open(filePath, FileMode.Open, FileAccess.Write);
            CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(obj.ToString());
            csDecrypt.Write(byteArray, 0, byteArray.Length);
            csDecrypt.FlushFinalBlock();
            csDecrypt.Close();
            fsOut.Close();
        }


        public static string readMachineLicense(string filePath)
        {
            byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 91 };
            byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 95 };
            RijndaelManaged myRijndael = new RijndaelManaged();
            FileStream fsOut = File.Open(filePath, FileMode.Open, FileAccess.Read);
            CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateDecryptor(key, IV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(csDecrypt);//把文件读出来
            string str = sr.ReadToEnd();
            sr.Close();
            fsOut.Close();
            return str;
        }

        public void Dispose()
        {
            backworkerZ.CancelAsync();
        }
    }
}
