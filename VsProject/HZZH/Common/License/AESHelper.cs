using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LicenseManagement
{
    class AESHelper
    {

        ///// <summary>
        ///// 获取密钥
        ///// </summary>
        //private static string Key
        //{
        //    get
        //    {
        //        return "abcdef1234567890";    ////必须是16位
        //    }
        //}
        ////默认密钥向量 
        //private static byte[] _key1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        ///// <summary>
        ///// AES加密算法
        ///// </summary>
        ///// <param name="plainText">明文字符串</param>
        ///// <returns>将加密后的密文转换为Base64编码，以便显示</returns>
        //public static string AESEncrypt(string plainText)
        //{
        //    //分组加密算法
        //    SymmetricAlgorithm des = Rijndael.Create();
        //    byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);//得到需要加密的字节数组 
        //                                                              //设置密钥及密钥向量
        //    des.Key = Encoding.UTF8.GetBytes(Key);
        //    des.IV = _key1;
        //    byte[] cipherBytes = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
        //        {
        //            cs.Write(inputByteArray, 0, inputByteArray.Length);
        //            cs.FlushFinalBlock();
        //            cipherBytes = ms.ToArray();//得到加密后的字节数组
        //            cs.Close();
        //            ms.Close();
        //        }
        //    }
        //    return Convert.ToBase64String(cipherBytes);
        //}
        ///// <summary>
        ///// AES解密
        ///// </summary>
        ///// <param name="cipherText">密文字符串</param>
        ///// <returns>返回解密后的明文字符串</returns>
        //public static string AESDecrypt(string showText)
        //{
        //    byte[] cipherText = Convert.FromBase64String(showText);
        //    SymmetricAlgorithm des = Rijndael.Create();
        //    des.Key = Encoding.UTF8.GetBytes(Key);
        //    des.IV = _key1;
        //    byte[] decryptBytes = new byte[cipherText.Length];
        //    using (MemoryStream ms = new MemoryStream(cipherText))
        //    {
        //        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read))
        //        {
        //            cs.Read(decryptBytes, 0, decryptBytes.Length);
        //            cs.Close();
        //            ms.Close();
        //        }
        //    }
        //    return Encoding.UTF8.GetString(decryptBytes).Replace("\0", "");   ///将字符串后尾的'\0'去掉
        //}

        //

        ////加密
        //public static string Encryption(string express)
        //{
        //    CspParameters param = new CspParameters();
        //    param.KeyContainerName = "oa_erp_dowork";//密匙容器的名称，保持加密解密一致才能解密成功
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
        //    {
        //        byte[] plaindata = Encoding.Default.GetBytes(express);//将要加密的字符串转换为字节数组
        //        byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
        //        return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
        //    }
        //}

        ////解密
        //public static string Decrypt(string ciphertext)
        //{
        //    CspParameters param = new CspParameters();
        //    param.KeyContainerName = "oa_erp_dowork";
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
        //    {
        //        byte[] encryptdata = Convert.FromBase64String(ciphertext);
        //        byte[] decryptdata = rsa.Decrypt(encryptdata, false);
        //        return Encoding.Default.GetString(decryptdata);
        //    }
        //}


        //public static string encode(string str)
        //{
        //    string htext = "";

        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        htext = htext + (char)(str[i] + 10 - 1 * 2);
        //    }
        //    return htext;
        //}

        //public static string decode(string str)
        //{
        //    string dtext = "";

        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        dtext = dtext + (char)(str[i] - 10 + 1 * 2);
        //    }
        //    return dtext;
        //}


        //////

        ////DES默认密钥向量
        //private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        ///// <summary>
        ///// DES加密字符串
        ///// </summary>
        ///// <param name="encryptString">待加密的字符串</param>
        ///// <param name="encryptKey">加密密钥,要求为8位</param>
        ///// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        //public static string EncryptDES(string encryptString, string encryptKey)
        //{
        //    try
        //    {
        //        byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
        //        byte[] rgbIV = Keys;
        //        byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
        //        DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        //        cStream.Write(inputByteArray, 0, inputByteArray.Length);
        //        cStream.FlushFinalBlock();
        //        return Convert.ToBase64String(mStream.ToArray());
        //    }
        //    catch
        //    {
        //        return encryptString;
        //    }
        //}

        ///// <summary>
        ///// DES解密字符串
        ///// </summary>
        ///// <param name="decryptString">待解密的字符串</param>
        ///// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        ///// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        //public static string DecryptDES(string decryptString, string decryptKey)
        //{
        //    try
        //    {
        //        byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
        //        byte[] rgbIV = Keys;
        //        byte[] inputByteArray = Convert.FromBase64String(decryptString);
        //        DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        //        cStream.Write(inputByteArray, 0, inputByteArray.Length);
        //        cStream.FlushFinalBlock();
        //        return Encoding.UTF8.GetString(mStream.ToArray());
        //    }
        //    catch
        //    {
        //        return decryptString;
        //    }
        //}

        /////////////////

        //private char[] TextEncrypt(string content, string secretKey)
        //{
        //    char[] data = content.ToCharArray();
        //    char[] key = secretKey.ToCharArray();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        data[i] ^= key[i % key.Length];
        //    }
        //    return data;
        //}
        //private string TextDecrypt(char[] data, string secretKey)
        //{
        //    char[] key = secretKey.ToCharArray();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        data[i] ^= key[i % key.Length];
        //    }
        //    return new string(data);
        //}


        ///////////////

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="word">被加密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>加密后字符串</returns>
        public static string Encrypt(string word, string key)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(key, "^[a-zA-Z]*$"))
            {
                throw new Exception("key 必须由字母组成");
            }
            key = key.ToLower();
            //逐个字符加密字符串
            char[] s = word.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char a = word[i];
                char b = key[i % key.Length];
                s[i] = EncryptChar(a, b);
            }
            return new string(s);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="word">被解密字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>解密后字符串</returns>
        public static string Decrypt(string word, string key)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(key, "^[a-zA-Z]*$"))
            {
                throw new Exception("key 必须由字母组成");
            }
            key = key.ToLower();
            //逐个字符解密字符串
            char[] s = word.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char a = word[i];
                char b = key[i % key.Length];
                s[i] = DecryptChar(a, b);
            }
            return new string(s);
        }

        /// <summary>
        /// 加密单个字符
        /// </summary>
        /// <param name="a">被加密字符</param>
        /// <param name="b">密钥</param>
        /// <returns>加密后字符</returns>
        private static char EncryptChar(char a, char b)
        {
            int c = a + b - 'a';
            if (a >= '0' && a <= '9') //字符0-9的转换
            {
                while (c > '9') c -= 10;
            }
            else if (a >= 'a' && a <= 'z') //字符a-z的转换
            {
                while (c > 'z') c -= 26;
            }
            else if (a >= 'A' && a <= 'Z') //字符A-Z的转换
            {
                while (c > 'Z') c -= 26;
            }
            else return a; //不再上面的范围内，不转换直接返回
            return (char)c; //返回转换后的字符
        }

        /// <summary>
        /// 解密单个字符
        /// </summary>
        /// <param name="a">被解密字符</param>
        /// <param name="b">密钥</param>
        /// <returns>解密后字符</returns>
        private static char DecryptChar(char a, char b)
        {
            int c = a - b + 'a';
            if (a >= '0' && a <= '9') //字符0-9的转换
            {
                while (c < '0') c += 10;
            }
            else if (a >= 'a' && a <= 'z') //字符a-z的转换
            {
                while (c < 'a') c += 26;
            }
            else if (a >= 'A' && a <= 'Z') //字符A-Z的转换
            {
                while (c < 'A') c += 26;
            }
            else return a; //不再上面的范围内，不转换直接返回
            return (char)c; //返回转换后的字符
        }



        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }


        #region 随机数的获取

        private static char[] constant =
        {
            '1','2','3','4','5','6','7','8','9',
            //'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            //'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(35);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(9)]);
            }
            return newRandom.ToString();
        }


        public static string GetRandomNumber(int a)
        {
            string strCpu = GenerateRandomNumber(20);
            string strcpu1 = strCpu.Substring(0, a);
            return strcpu1;
        }


        #endregion


        private static string randStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

        public static string EncryptStr(string str)
        {
            byte[] btData = Encoding.Default.GetBytes(str);
            int j, k, m;
            int len = randStr.Length;
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < btData.Length; i++)
            {
                j = (byte)rand.Next(6);
                btData[i] = (byte)((int)btData[i] ^ j);
                k = (int)btData[i] % len;
                m = (int)btData[i] / len;
                m = m * 8 + j;
                sb.Append(randStr.Substring(k, 1) + randStr.Substring(m, 1));
            }
            return sb.ToString();
        }

        public static string DecryptStr(string str)
        {
            try
            {
                int j, k, m, n = 0;
                int len = randStr.Length;
                byte[] btData = new byte[str.Length / 2];
                for (int i = 0; i < str.Length; i += 2)
                {
                    k = randStr.IndexOf(str[i]);
                    m = randStr.IndexOf(str[i + 1]);
                    j = m / 8;
                    m = m - j * 8;
                    btData[n] = (byte)(j * len + k);
                    btData[n] = (byte)((int)btData[n] ^ m);
                    n++;
                }
                return Encoding.Default.GetString(btData);
            }
            catch { return ""; }
        }

    }
}