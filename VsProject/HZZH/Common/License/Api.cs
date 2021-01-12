using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ApiClass
{
    class Api
    {
        //声明要使用Rockey1 API接口
        //函数的返回值声明成int
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Find(byte[] pid, ref long dwCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Open(ref IntPtr handle, byte[] pid, int nIndex);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Close(IntPtr handle);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GetVersion(IntPtr handle, ref byte bVersionMajor, ref byte bVersionMinor);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GetHID(IntPtr handle, byte[] hid);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_VerifyUserPin(IntPtr handle, byte[] pin, ref byte tryCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_VerifySoPin(IntPtr handle, byte[] pin, ref byte tryCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GenRandom(IntPtr handle, byte[] buffer);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Read(IntPtr handle, short wOffset, short wLength, byte[] buf, ref short len, byte bType);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Write(IntPtr handle, short wOffset, short wLength, byte[] buf, ref short len, byte bType);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GenRSAKey(IntPtr handle, byte bFlag, byte id, string pubkey, string prikey);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_SetRSAKey(IntPtr handle, byte bFlag, byte id, string pubkey, string prikey);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_RSAEnc(IntPtr handle, byte bFlag, byte id, byte[] bBuf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_RSADec(IntPtr handle, byte bFlag, byte id, byte[] bBuf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_SetTDesKey(IntPtr handle, byte id, byte[] buf);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_TDesEnc(IntPtr handle, byte id, byte[] buf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_TDesDec(IntPtr handle, byte id, byte[] buf, int dwLen);
        //DWORD WINAPI R1_LEDControl(HANDLE handle,BYTE bFlag);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_LEDControl(IntPtr handle, byte bFlag);

        //*****************************************************************

        #region 公有存储
        public static int LoginSafeDog(ref IntPtr handle)
        {
            int retcode;
            byte tryCount = 0;
            long dwCount = 0;
            byte[] pin = new byte[8] { (byte)'H', (byte)'Z', (byte)'Z', (byte)'H', (byte)'1', (byte)'2', (byte)'3', (byte)'4' };

            retcode = Api.R1_Find(null, ref dwCount);                  //查找Rockey1
            if (retcode == 0)
            {
                retcode = Api.R1_Open(ref handle, null, 0);                //打开Rockey1
                if (retcode == 0)
                {
                    retcode = Api.R1_VerifyUserPin(handle, pin, ref tryCount);         //验证UserPin
                    return retcode;
                }
                else
                {
                    return retcode;
                }
            }
            else
            {
                return retcode;
            }
            //retcode = Api.R1_VerifySoPin(handle, pin, ref tryCount);//验证SoPin
        }


        public static string ReadDog(short a)  
        {
            try
            {
                IntPtr handle = IntPtr.Zero;
                if (LoginSafeDog(ref handle) != 0)
                {
                    throw new Exception("登录失败：请检测Dog是否存在");
                }

                short len = 0;
                string str = string.Empty;
                byte[] buffer = new byte[128];

                if (Api.R1_Read(handle, a, (short)buffer.Length, buffer, ref len, (byte)0) == 0)                //读Rockey1内存
                {
                    //for (int i = 0; i < 16; i++)
                    //{
                    //    str = str + "0x" + buffer[i].ToString("X") + " ";
                    //}
                    int arrsum = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        arrsum += buffer[i];
                    }
                    if (arrsum > 0)
                    {
                        str = (System.Text.Encoding.Default.GetString(buffer)).Substring(0, 20);
                    }
                }
                else
                {
                    throw new Exception("读取数据......失败");
                }


                if (Api.R1_Close(handle) != 0)      //关闭Rockey1
                {
                    throw new Exception("关闭加密狗......失败");
                }







                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void WriteDog(string msg, short a)
        {
            try
            {
                IntPtr handle = IntPtr.Zero;
                int code = LoginSafeDog(ref handle);
                if (code != 0)
                {
                    throw new Exception("登录失败：请检测Dog是否存在");
                }
      
                short len = 0;
                byte[] buffer = UTF8Encoding.Default.GetBytes(msg);

                if (Api.R1_Write(handle, a, (short)buffer.Length, buffer, ref len, (byte)0) != 0)                //写Rockey1内存
                {
                    throw new Exception("写入数据......失败");
                }

                if (Api.R1_Close(handle) != 0)      //关闭Rockey1
                {
                    throw new Exception("关闭加密狗......失败");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }



        public static string ReadDog(short a, IntPtr handle)
        {
            try
            {
                short len = 0;
                string str = string.Empty;
                byte[] buffer = new byte[128];

                if (Api.R1_Read(handle, a, (short)buffer.Length, buffer, ref len, (byte)0) == 0)                //读Rockey1内存
                {
                    //for (int i = 0; i < 16; i++)
                    //{
                    //    str = str + "0x" + buffer[i].ToString("X") + " ";
                    //}
                    int arrsum = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        arrsum += buffer[i];
                    }
                    if (arrsum > 0)
                    {
                        if (a == 64)
                        {
                            str = (System.Text.Encoding.Default.GetString(buffer)).Substring(0, 10);
                        }
                        else
                        {
                            str = (System.Text.Encoding.Default.GetString(buffer)).Substring(0, 20);
                        }
                    }
                }
                else
                {
                    throw new Exception("读取数据......失败");
                }

                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ReadHid(IntPtr handle)
        {
            try
            {
                string str = string.Empty;
                byte[] buffer = new byte[16];

                if (Api.R1_GetHID(handle, buffer) == 0)                //读Rockey1内存
                {
                    int arrsum = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        arrsum += buffer[i];
                    }
                    if (arrsum > 0)
                    {
                        str = System.Text.Encoding.Default.GetString(buffer);
                    }
                }
                else
                {
                    throw new Exception("读取数据......失败");
                }

                string strHid = str.Substring(0, 4) + str.Substring(str.Length - 4, 4);
                return strHid;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void WriteDog(string msg, short a, IntPtr handle)
        {
            try
            {
                short len = 0;
                byte[] buffer = UTF8Encoding.Default.GetBytes(msg);

                if (Api.R1_Write(handle, a, (short)buffer.Length, buffer, ref len, (byte)0) != 0)                //写Rockey1内存
                {
                    throw new Exception("写入数据......失败");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        #endregion


        #region 私有存储

        public static int LoginSafeDogs(ref IntPtr handle)
        {
            int retcode;
            byte tryCount = 0;
            long dwCount = 0;
            byte[] pin = new byte[8] { (byte)'H', (byte)'Z', (byte)'Z', (byte)'H', (byte)'1', (byte)'2', (byte)'3', (byte)'4' };

            retcode = Api.R1_Find(null, ref dwCount);                  //查找Rockey1
            if (retcode == 0)
            {
                retcode = Api.R1_Open(ref handle, null, 0);                //打开Rockey1
                if (retcode == 0)
                {
                    retcode = Api.R1_VerifyUserPin(handle, pin, ref tryCount);         //验证UserPin
                    return retcode;
                }
                else
                {
                    return retcode;
                }
            }
            else
            {
                return retcode;
            }
            //retcode = Api.R1_VerifySoPin(handle, pin, ref tryCount);//验证SoPin
        }


        public static string ReadDogs()
        {
            try
            {
                IntPtr handle = IntPtr.Zero;
                if (LoginSafeDogs(ref handle) != 0)
                {
                    throw new Exception("登录失败：请检测Dog是否存在");
                }

                short len = 0;
                string str = string.Empty;
                byte[] buffer = new byte[128];

                if (Api.R1_Read(handle, 0, (short)buffer.Length, buffer, ref len, (byte)1) == 0)                //读Rockey1内存
                {
                    //for (int i = 0; i < 16; i++)
                    //{
                    //    str = str + "0x" + buffer[i].ToString("X") + " ";
                    //}
                    int arrsum = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        arrsum += buffer[i];
                    }
                    if (arrsum > 0)
                    {
                        str = (System.Text.Encoding.Default.GetString(buffer)).Substring(0, 10);
                    }
                }
                else
                {
                    throw new Exception("读取数据......失败");
                }


                if (Api.R1_Close(handle) != 0)      //关闭Rockey1
                {
                    throw new Exception("关闭加密狗......失败");
                }

                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void WriteDogs(string msg)
        {
            try
            {
                IntPtr handle = IntPtr.Zero;
                int code = LoginSafeDogs(ref handle);
                if (code != 0)
                {
                    throw new Exception("登录失败：请检测Dog是否存在");
                }

                short len = 0;
                byte[] buffer = UTF8Encoding.Default.GetBytes(msg);

                if (Api.R1_Write(handle, 0, (short)buffer.Length, buffer, ref len, (byte)1) != 0)                //写Rockey1内存
                {
                    throw new Exception("写入数据......失败");
                }

                if (Api.R1_Close(handle) != 0)      //关闭Rockey1
                {
                    throw new Exception("关闭加密狗......失败");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static string ReadDogs(IntPtr handle)
        {
            try
            {
                short len = 0;
                string str = string.Empty;
                byte[] buffer = new byte[128];

                if (Api.R1_Read(handle, 0, (short)buffer.Length, buffer, ref len, (byte)1) == 0)                //读Rockey1内存
                {
                    //for (int i = 0; i < 16; i++)
                    //{
                    //    str = str + "0x" + buffer[i].ToString("X") + " ";
                    //}
                    int arrsum = 0;
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        arrsum += buffer[i];
                    }
                    if (arrsum > 0)
                    {
                        str = (System.Text.Encoding.Default.GetString(buffer)).Substring(0, 10);
                    }
                }
                else
                {
                    throw new Exception("读取数据......失败");
                }
                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void WriteDogs(string msg, IntPtr handle)
        {
            try
            {
                short len = 0;
                byte[] buffer = UTF8Encoding.Default.GetBytes(msg);

                if (Api.R1_Write(handle, 0, (short)buffer.Length, buffer, ref len, (byte)1) != 0)                //写Rockey1内存
                {
                    throw new Exception("写入数据......失败");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        #endregion
    }
}
