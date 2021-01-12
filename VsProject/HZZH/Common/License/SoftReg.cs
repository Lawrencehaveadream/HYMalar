using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using ApiClass;

namespace LicenseManagement
{
    public class SoftReg
    {
        public DateTime str_InitPermitDate { get; set; }//初始化许可时间 
        public DateTime str_IssuingDate { get; set; } //发行时间



        private static char[] constant =   
        {   
            '1','2','3','4','5','6','7','8','9',  
            //'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
        };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(35);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(35)]);
            }
            return newRandom.ToString();
        }


        public static string GenerateDogNumberr()
        {
            string strCpu = GenerateRandomNumber(20);
            string strcpu1 = strCpu.Substring(0, 4) + strCpu.Substring(strCpu.Length - 4, 4);
            return strcpu1;
        }


        ////<summary>
        //// 获取编号
        ////</summary>
        ////<returns></returns>
        public static string GetDogNumber(IntPtr handle)
        {
            string strdogmsg = Api.ReadDog(0, handle);
            string term0 = AESHelper.Decrypt(strdogmsg, "qwertyuiop");
            string dogcpu = term0.Substring(0, 8);
            return dogcpu;
        }


        public static string GetDogNumber1()
        {
            string strdogmsg = Api.ReadDog(0);
            string term0 = AESHelper.Decrypt(strdogmsg, "qwertyuiop");
            string dogcpu = term0.Substring(0, 8);
            return dogcpu;
        }

        public static string MachineID = "";


        ///<summary>
        /// 生成机器码
        ///</summary>
        ///<returns></returns>
        public string GetMNum()
        {
            string strANum = string.Empty;
            try
            {
                str_IssuingDate = DateTime.Now;


                long term0 = AESHelper.ConvertDateTimeInt(DateTime.Now);
                long term1 = 15 * 24 * 3600;
                long term2 = term0 + term1;
                DateTime str_Date = AESHelper.GetTime(term0.ToString());
                str_InitPermitDate = AESHelper.GetTime(term2.ToString());

                string strcpu1 = MachineID = GenerateDogNumberr();
                string strNum = strcpu1 + "H" + term2;
                //string strNum = strcpu1.Substring(0, 4) + strcpu1.Substring(strcpu1.Length - 4, 4)  +"H"+ term2+;         
                string strMNum = strNum.Substring(0, 19);

                byte[] buff = new byte[20];
                byte[] data = UTF8Encoding.Default.GetBytes(strMNum);
                if (data.Length !=19)
                {
                    throw new Exception("Failed to get machine id "+ data.Length);
                }
                data.CopyTo(buff, 0);


                byte sum = SumCheck(data);
                buff[19] = sum;

               string str = (System.Text.Encoding.Default.GetString(buff)).Substring(0, 20);

                strANum = AESHelper.Encrypt(str, "qwertyuiop");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return strANum;
        }

        /// <summary>
        /// 累加和校验
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        protected static byte SumCheck(byte[] bs)
        {
            int num = 0;
            //所有字节累加
            for (int i = 0; i < bs.Length; i++)
            {
                num = num ^ bs[i];
            }
            byte ret = (byte)(num & 0xff);//
            return ret;
        }



        public DateTime Register(string code)
        {
            DateTime getDateTime;
            if (code.Length != 20)
            {
                throw new Exception("机器ID长度不正确： " + code.Length + "非等20");
            }
            try
            {
                string term0 = AESHelper.Decrypt(code, "qwertyuiop");//qwertyuiop
                string cpu_term1 = term0.Substring(0, 8);
                string date_term1_ = term0.Substring(9, term0.Length - 9);
                string date_term1 = date_term1_.Remove(date_term1_.Length - 1, 1);

                getDateTime = AESHelper.GetTime((date_term1).ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("机器ID格式不正确： " +ex.Message);
            }
            return getDateTime;
            
        }


        public object UpdateRegister(string code ,out bool bIndefinite ,out DateTime dateTime,out string newmachineID)
        {
            newmachineID = string.Empty;
            dateTime = new DateTime();
            object returnMsg = "";
            bIndefinite = false;

            if (code.Length != 20)
            {
                throw new Exception("许可ID长度不正确： " + code.Length + "非等20");
            }
            try
            {
                string strcpu1 = AESHelper.DecryptStr(LicenseMsg.readMachineLicense(@"armcc01_intr")) ;
                string term0 = AESHelper.Decrypt(code, "SDFujujhgggvhXXVXhjgghFDFgvbhb");//qwertyuiop

                byte[] data = UTF8Encoding.Default.GetBytes(term0);
                if (data.Length != 20)
                {
                    throw new Exception("许可ID有误:" + data.Length);
                }

                byte sum = data[19];

                List<byte> lisdata = data.ToList();
                lisdata.RemoveAt(data.Length - 1);


                byte countsum = SumCheck(lisdata.ToArray());
                if (sum != countsum)
                {
                    throw new Exception("许可ID校验有误");
                }



                string cpu_term1 = term0.Substring(0, 8);
                if(strcpu1.CompareTo(cpu_term1)!=0)
                {
                    throw new Exception("");
                }

              

                string strend = term0.Substring(9, term0.Length -9);
                string strend1 = strend.Remove(strend.Length - 1, 1);
                string strANum = newmachineID = AESHelper.Encrypt(term0, "qwertyuiop");

                Api.WriteDog(strANum, 0);

                if (strend1.CompareTo( "9876543219") == 0)
                {
                    returnMsg = "无限期";
                    bIndefinite = true;
                }
                else
                {
                    string date_term1_ = term0.Substring(9, term0.Length - 9);
                    string date_term2 = date_term1_.Remove(date_term1_.Length - 1, 1);

                    dateTime = AESHelper.GetTime((date_term2).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("注册码格式不正确： " + ex.Message);
            }
            return returnMsg;

        }

    }
}
