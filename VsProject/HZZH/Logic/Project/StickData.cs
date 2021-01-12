using CommonRs;
using HZZH.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HzControl.Communal.Tools;
using Serialization = HzControl.Communal.Tools.Serialization;

namespace HZZH.Logic.Project
{
    public enum NumE
    {
        FeedNuzzleNum = 4,   //上料吸嘴个数
        UnfeedNuzzleNum = 4, //下料吸嘴个数
        PlateNum = 2, //平台数量
    }
    /// <summary>
    /// 贴附参数
    /// </summary>
    [Serializable]
    public class StickParaDef : ProductBase  //贴附参数
    {   
        /// <summary>
        /// 吸嘴真空关闭延时
        /// </summary>
        public int SuckOffDelay { get; set; }	                
        /// <summary>
        /// 吸嘴吹气打开延时
        /// </summary>
        public int SuckBlowDelay { get; set; } 
        /// <summary>
        /// Z轴贴料高度
        /// </summary>
        public float StickPos_Z { get; set; }                     
        /// <summary>
        /// Z轴贴料安全高度
        /// </summary>
        public float SafePos_Z { get; set; }
        public StickParaDef()
        {
            
        }
    }
    /// <summary>
    /// 弃标参数
    /// </summary>
    [Serializable]
    public class GiveUpParaDef : ProductBase
    {
        /// <summary>
        /// 左吸嘴弃料位置
        /// </summary>
        public PointF2 LiftGiveUpPos { get; set; }
        /// <summary>
        /// 右吸嘴弃料位置
        /// </summary>
        public PointF2 RightGiveUpPos { get; set; }
        /// <summary>
        /// 弃料时间
        /// </summary>
        public int GiveUpDelay { get; set; }
        /// <summary>
        /// 弃料吹气时间
        /// </summary>
        public int GiveUpBlowDelay { get; set; }
        /// <summary>
        /// 安全高度
        /// </summary>
        public float SafePos_Z { get; set; }         
        /// <summary>
        /// 左吸嘴弃料高度
        /// </summary>
        public float LiftGiveUp_Z { get; set; }
        /// <summary>
        /// 右吸嘴弃料高度
        /// </summary>
        public float RightGiveUp_Z { get; set; }
        /// <summary>
        /// 弃料总数
        /// </summary>
        public int giveUpNum { get; set; }
        public GiveUpParaDef()
        {
            LiftGiveUpPos = new PointF2();
            RightGiveUpPos = new PointF2();
        }
    }
    /// <summary>
    /// 取标 运行参数
    /// </summary>
    [Serializable]
    public class TakeLabelParaDef : ProductBase   // 取标 运行参数
    {
        /// <summary>
        /// 取标前是否拍照
        /// </summary>
        public bool TakeLabelCT { get; set; }
        /// <summary>
        /// 左吸嘴取料成功个数
        /// </summary>
        public int TakeLableLNum { get; set; }
        /// <summary>
        /// 右吸嘴取料成功个数
        /// </summary>
        public int TakeLableRNum { get; set; }
        /// <summary>
        /// 左侧取料总次数
        /// </summary>
        public int TakeLableWholeLNum { get; set; }
        /// <summary>
        /// 右侧取料总次数
        /// </summary>
        public int TakeLableWholeRNum { get; set; }
        /// <summary>
        /// 左吸嘴吸料延时
        /// </summary>
        public int LiftTakeDelay { get; set; }
        /// <summary>
        /// 右吸嘴吸料延时
        /// </summary>
        public int RightTakeDelay { get; set; }
        /// <summary>
        /// Z1轴取料高度 
        /// </summary>
        public float  LiftTakePos_Z { get; set; }
        /// <summary>
        /// Z2轴取料高度 
        /// </summary>
        public float RightTakePos_Z { get; set; }
        /// <summary>
        /// Z1轴取料提起高度
        /// </summary>
        public float LiftSafePos_Z { get; set; }
        /// <summary>
        /// Z2轴取料提起高度
        /// </summary>
        public float RightSafePos_Z { get; set; }
        /// <summary>
        /// 取料坐标点    
        /// </summary>
        public PointF4 TakePos { get; set; }
        public TakeLabelParaDef()
        {
            TakePos = new PointF4();
        }
    }
    /// <summary>
    /// 飞达参数
    /// </summary>
    [Serializable]
    public class FeederParaDef : ProductBase //
    {
        /// <summary>
        /// 飞达出标模式[0]：拨标板 [1]：后撤式
        /// </summary>
        public List<bool> FeederMode { get; set; }
        /// <summary>
        /// 飞达物料排数
        /// </summary>
        public int labelRow { get; set; }
        /// <summary>
        /// 取料位置
        /// </summary>
        public PointF4 TakePos { get; set; }
        /// <summary>
        /// 取料末位置
        /// </summary>
        public PointF4 EndTakePos { get; set; }
        /// <summary>
        /// 取料真空时间
        /// </summary>
        public int vacuumDelay { get; set; }
        public FeederParaDef()
        {
            TakePos = new PointF4();
            EndTakePos = new PointF4();
            FeederMode = new List<bool>() { true,false };
        }
    }
    /// <summary>
    /// 吸嘴状态
    /// </summary>
    [Serializable]
    public class NuzzleParaDef : ProductBase
    {
        /// <summary>
        /// 吸嘴上是否有料
        /// <summary>
        /// </summary>
        public bool isHave { get; set; }        //
        /// <summary>
        /// 下相机结果OK:1，NG:2
        /// </summary>
        public int isOk { get; set; }   //
        /// <summary>
        /// 视觉定位结果
        /// </summary>
        public PointF4 CCDPos { get; set; }  //
        /// <summary>
        /// 定位角度
        /// </summary>
        public float Angle { get; set; }
        /// <summary>
        /// Z轴拍照高度
        /// </summary>
        public float ZSnapPos { get; set; }
        public NuzzleParaDef()
        {
            CCDPos = new PointF4();
        }
    }
    /// <summary>
    /// 贴附，系统参数
    /// </summary>
    [Serializable]
    public class StickSysDataDef : ProductBase
    {
        /// <summary>
        /// 左吸嘴对准下相机位置
        /// </summary>
        public PointF3 LiftDownCCDPos { get; set; }
        /// <summary>
        /// 右吸嘴对准下相机位置
        /// </summary>
        public PointF3 RightDownCCDPos { get; set; }
        /// <summary>
        /// 左吸嘴0度位置
        /// </summary>
        public PointF3 Lift000CCDPos { get; set; }
        /// <summary>
        /// 左吸嘴180度位置
        /// </summary>
        public PointF3 Lift180CCDPos { get; set; }
        /// <summary>
        /// 右吸嘴0度位置
        /// </summary>
        public PointF3 Right000CCDPos { get; set; }
        /// <summary>
        /// 右吸嘴180位置
        /// </summary>
        public PointF3 Right180CCDPos { get; set; }
        /// <summary>
        /// 左吸嘴圆心
        /// </summary>
        public PointF3 Liftcirclepoint { get; set; }
        /// <summary>
        /// 左吸嘴圆心
        /// </summary>
        public PointF3 Rightcirclepoint { get; set; }
        /// <summary>
        /// 左吸嘴旋转中心半径
        /// </summary>
        public float LiftRatateR { get; set; }
        /// <summary>
        /// 右吸嘴旋转中心半径
        /// </summary>
        public float RightRatateR { get; set; }
        
        /// <summary>
        /// 上相机对准校准位置（左）
        /// </summary>
        public PointF3 LiftCCDPos { get; set; }
        /// <summary>
        /// 左吸嘴对准校准位置
        /// </summary>
        public PointF3 LiftNuzzlePos { get; set; }
        /// <summary>
        /// 上相机对准校准位置（右）
        /// </summary>
        public PointF3 RightCCDPos { get; set; }
        /// <summary>
        /// 右吸嘴定位位置
        /// </summary>
        public PointF3 RightNuzzlePos { get; set; }
        /// <summary>
        /// 左旋转中心
        /// </summary>
        public PointF2 LiftNuzzleRotaCenter { get; set; }
        /// <summary>
        ///右旋转中心
        /// </summary>
        public PointF2 RightNuzzleRotaCenter { get; set; }
        /// <summary>
        /// 直接流出
        /// </summary>
        public bool stright { get; set; }
        public StickSysDataDef()
        {
            LiftCCDPos = new PointF3();
            LiftNuzzlePos = new PointF3();
            RightCCDPos = new PointF3();
            RightNuzzlePos = new PointF3();
            LiftNuzzleRotaCenter = new PointF2();
            RightNuzzleRotaCenter = new PointF2();

            Liftcirclepoint = new PointF3();
            Rightcirclepoint = new PointF3();
            LiftDownCCDPos = new PointF3();
            RightDownCCDPos = new PointF3();
            Lift000CCDPos = new PointF3();
            Lift180CCDPos = new PointF3();
            Right000CCDPos = new PointF3();
            Right180CCDPos = new PointF3();
        }
        /// <summary>
        /// 上相机坐标转换为吸嘴坐标
        /// </summary>
        /// <param name="whichNuzzle">哪个吸嘴</param>
        /// <param name="pos">相机中心位置</param>
        /// <returns></returns>
        public PointF4 UpCCDToNuzzle(int whichNuzzle, PointF4 pos)
        {
            if (whichNuzzle == 0)
            {
                PointF4 p = new PointF4();
                p.X = pos.X - (LiftCCDPos.X - LiftNuzzlePos.X);
                p.Y = pos.Y - (LiftCCDPos.Y - LiftNuzzlePos.Y);
                p.Z = pos.Z;
                p.R = pos.R;
                return p;
            }
            else
            {
                PointF4 p = new PointF4();
                p.X = pos.X - (RightCCDPos.X - RightNuzzlePos.X);
                p.Y = pos.Y - (RightCCDPos.Y - RightNuzzlePos.Y);
                p.R = pos.R;
                p.Z = pos.Z;
                return p;
            }
        }
    }
    /// <summary>
    /// 贴附数据，总类
    /// </summary>
    [Serializable]
    public class StickDataDef : ProductBase
    {
        public GiveUpParaDef GiveUpPara { get; set; }

        public StickParaDef StickPara { get; set; }

        public TakeLabelParaDef TakeLabelPara { get; set; }


        public FeederParaDef FeederPara { get; set; }

        public List<PointF4> StickPos { get; set; }
        /// <summary>
        /// 拍照前延时
        /// </summary>
        public int CTDelay { get; set; }
        public bool CanscanCode { get; set; }
        public bool CanBackCT { get; set; }
        /// <summary>
        /// 吸嘴启用和禁用
        /// </summary>
        public List<bool> NuzzleForbit { get; set; }
        /// <summary>
        /// Z轴安全高度
        /// </summary>
        public float ZSafePos { get; set; }
        /// <summary>
        /// Z轴 拍照高度
        /// </summary>
        public float Z_UnderCCDSnapPos { get; set; }
        /// <summary>
        /// 下相机拍照得到的结果 
        /// </summary>
        public List<PointF4> underCCDSanpPos { get; set; }
        /// <summary>
        /// Tray盘数据
        /// </summary>
        public Tray TrayData { get; set; }   
        /// <summary>
        /// 贴附系统数据
        /// </summary>
        public StickSysDataDef StickSysData { get; set; }
        public StickDataDef()
        {
            NuzzleForbit = new List<bool>() { false,false};
            GiveUpPara = new GiveUpParaDef();
            StickPara = new StickParaDef();
            TakeLabelPara = new TakeLabelParaDef();
            FeederPara = new FeederParaDef();
            underCCDSanpPos = new List<PointF4>();
            TrayData = new Tray();
            StickPos = new List<PointF4>();
            StickSysData = new StickSysDataDef();
            //for (int i = 0; i < 2; i++)
            //{
            //    NuzzleForbit.Add(false);
            //}
        }
        //[OnDeserialized()]
        //private void OnDeserializedMething(StreamingContext context)
        //{
        //    if (FeederPara.FeederMode == null)
        //    {
        //        NuzzleForbit = new List<bool>() { true,false };
                
        //    }
        //}
        public override void Load(string fileName)
        {
            object obj = Serialization.LoadFromFile(fileName);
            CopyValue(this, obj);
        }
        public override void Save(string fileName)
        {
            Serialization.SaveToFile(this, fileName);
        }
    }
}
