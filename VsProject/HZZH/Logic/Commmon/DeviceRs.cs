using CommonRs;
using Device;
using HZZH.Logic.Project;
using Paste.Vision.Tool.RotateCenter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    public enum InIndex : int   //输入口定义
    {
        X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25, X26, X27, X28, X29, X30,
        X31, X32, X33, X34, X35, X36, X37, X38, X39, X40, X41, X42, X43, X44, X45, X46, X47, X48, X49, X50, X51, X52, X53, X54, X55, X56, X57, X58, X59, X60,
    }
    public enum OutIndex : int	//输入口定义
    {
        Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8, Y9, Y10, Y11, Y12, Y13, Y14, Y15, Y16, Y17, Y18, Y19, Y20, Y21, Y22, Y23, Y24, Y25, Y26, Y27, Y28, Y29, Y30, Y31, Y32,
    }
    public static class DeviceRsDef
    {
        #region 自动生成板卡资源列表
        /// <summary>
        /// 轴列表
        /// </summary>
        public readonly static List<AxisClass> AxisList = new List<AxisClass>();
        /// <summary>
        /// 输入列表
        /// </summary>
        public readonly static List<InputClass> InputList = new List<InputClass>();
        /// <summary>
        /// 输出列表
        /// </summary>
        public readonly static List<OutputClass> OutputList = new List<OutputClass>();

        static DeviceRsDef()
        {
            foreach (var item in typeof(DeviceRsDef).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (item.FieldType == typeof(AxisClass))
                {
                    AxisList.Add((AxisClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(InputClass))
                {
                    InputList.Add((InputClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(OutputClass))
                {
                    OutputList.Add((OutputClass)item.GetValue(null));
                }
            }

        }
        #endregion

        public static MotionCardDef MotionCard = new MotionCardDef("192.168.1.30", 8089,"卡1");
        #region 轴定义
        public static AxisClass Axis_X = new AxisClass(MotionCard, 0, "X轴伺服");
        public static AxisClass Axis_Y = new AxisClass(MotionCard, 1, "Y轴伺服");
        public static AxisClass Axis_Z1 = new AxisClass(MotionCard, 2, "Z1轴伺服");
        public static AxisClass Axis_Z2 = new AxisClass(MotionCard, 3, "Z2轴伺服");
        public static AxisClass Axis_R1 = new AxisClass(MotionCard, 4, "R1轴步进");
        public static AxisClass Axis_R2 = new AxisClass(MotionCard, 5, "R2轴步进");
        /// <summary>
        /// 上流水线调宽
        /// </summary>
        public static AxisClass Axis_UpAdjust = new AxisClass(MotionCard, 6, "上流水线调宽");
        /// <summary>
        /// 下流水线调宽
        /// </summary>
        public static AxisClass Axis_DownAdjust = new AxisClass(MotionCard, 7, "下流水线调宽");
        /// <summary>
        /// 预进料皮带
        /// </summary>
        public static AxisClass Axis_BeltPreFeed = new AxisClass(MotionCard, 8, "预进料皮带");
        /// <summary>
        /// 进料皮带
        /// </summary>
        public static AxisClass Axis_BeltFeed = new AxisClass(MotionCard, 9, "进料皮带");
        /// <summary>
        /// 出料皮带
        /// </summary>
        public static AxisClass Axis_BeltUnfeed = new AxisClass(MotionCard, 10, "出料皮带");
        /// <summary>
        /// 下层皮带
        /// </summary>
        public static AxisClass Axis_BeltDown = new AxisClass(MotionCard, 11, "下层皮带");


        #endregion

        #region 输入定义
        public static InputClass I_XFarLimit = new InputClass(MotionCard, (int)InIndex.X1, "X正极限");
        public static InputClass I_YHome = new InputClass(MotionCard, (int)InIndex.X2, "Y轴原点");
        public static InputClass I_Z1Home = new InputClass(MotionCard, (int)InIndex.X3, "Z1轴原点");
        public static InputClass I_Z2Home = new InputClass(MotionCard, (int)InIndex.X4, "Z2轴原点");
        public static InputClass I_R1Home = new InputClass(MotionCard, (int)InIndex.X5, "R1轴原点");
        public static InputClass I_R2Home = new InputClass(MotionCard, (int)InIndex.X6, "R2轴原点");
        public static InputClass I_UpHome = new InputClass(MotionCard, (int)InIndex.X7, "上调宽轴原点");
        public static InputClass I_DownHome = new InputClass(MotionCard, (int)InIndex.X8, "下调宽轴原点");
        public static InputClass I_9 = new InputClass(MotionCard, (int)InIndex.X9, "NC");
        public static InputClass I_10 = new InputClass(MotionCard, (int)InIndex.X10, "NC");
        public static InputClass I_11 = new InputClass(MotionCard, (int)InIndex.X11, "NC");
        public static InputClass I_12 = new InputClass(MotionCard, (int)InIndex.X12, "NC");
        public static InputClass I_13 = new InputClass(MotionCard, (int)InIndex.X13, "NC");
        public static InputClass I_14 = new InputClass(MotionCard, (int)InIndex.X14, "NC");
        public static InputClass I_15 = new InputClass(MotionCard, (int)InIndex.X15, "NC");
        public static InputClass I_16 = new InputClass(MotionCard, (int)InIndex.X16, "NC");
        public static InputClass I_17 = new InputClass(MotionCard, (int)InIndex.X17, "X轴原点");
        public static InputClass I_YFarLimit = new InputClass(MotionCard, (int)InIndex.X18, "Y硬极限");
        public static InputClass I_19 = new InputClass(MotionCard, (int)InIndex.X19, "NC");
        public static InputClass I_20 = new InputClass(MotionCard, (int)InIndex.X20, "NC");
        public static InputClass I_21 = new InputClass(MotionCard, (int)InIndex.X21, "NC");
        public static InputClass I_22 = new InputClass(MotionCard, (int)InIndex.X22, "NC");
        public static InputClass I_23 = new InputClass(MotionCard, (int)InIndex.X23, "NC");
        public static InputClass I_24 = new InputClass(MotionCard, (int)InIndex.X24, "NC");
        public static InputClass I_25 = new InputClass(MotionCard, (int)InIndex.X25, "NC");
        public static InputClass I_26 = new InputClass(MotionCard, (int)InIndex.X26, "NC");
        public static InputClass I_27 = new InputClass(MotionCard, (int)InIndex.X27, "NC");
        public static InputClass I_28 = new InputClass(MotionCard, (int)InIndex.X28, "NC");
        public static InputClass I_Start = new InputClass(MotionCard, (int)InIndex.X29, "启动");
        public static InputClass I_Stop = new InputClass(MotionCard, (int)InIndex.X30, "停止");
        public static InputClass I_Reset = new InputClass(MotionCard, (int)InIndex.X31, "复位");
        public static InputClass I_Scam = new InputClass(MotionCard, (int)InIndex.X32, "急停按钮");
        public static InputClass I_33 = new InputClass(MotionCard, (int)InIndex.X33, "NC");
        
        public static InputClass I_34 = new InputClass(MotionCard, (int)InIndex.X34, "NC");
        
        public static InputClass I_35 = new InputClass(MotionCard, (int)InIndex.X35, "NC");
        /// <summary>
        /// 飞达麦拉已就绪
        /// </summary>
        public static InputClass I_FeederReady = new InputClass(MotionCard, (int)InIndex.X36, "飞达麦拉已就绪");
        /// <summary>
        /// 飞达麦拉剥料完成信号
        /// </summary>
        public static InputClass I_FeederDone = new InputClass(MotionCard, (int)InIndex.X37, "飞达麦拉剥料完成信号");
        /// <summary>
        /// 飞达报警信号
        /// </summary>
        public static InputClass I_FeederAlarm = new InputClass(MotionCard, (int)InIndex.X38, "飞达报警信号");
        /// <summary>
        /// 预进料载具流入感应
        /// </summary>
        public static InputClass I_BeltPreFeedIn = new InputClass(MotionCard, (int)InIndex.X39, "入料缓存流水线入料感应");
        /// <summary>
        /// 预进料到位感应
        /// </summary>
        public static InputClass I_BeltPreFeedOut = new InputClass(MotionCard, (int)InIndex.X40, "入料缓存流水线出料感应");
        /// <summary>
        /// 载具进料到位感应
        /// </summary>
        public static InputClass I_BeltFeedIn = new InputClass(MotionCard, (int)InIndex.X41, "贴麦拉流水线到位感应");
        /// <summary>
        /// 载具出料感应
        /// </summary>
        public static InputClass I_BeltFeedOut = new InputClass(MotionCard, (int)InIndex.X42, "贴麦拉流水线出料感应");
        /// <summary>
        /// 出料载具到位感应
        /// </summary>
        public static InputClass I_BeltUnfeedOut = new InputClass(MotionCard, (int)InIndex.X43, "出料流水线出料感应");
        /// <summary>
        /// 111111
        /// </summary>
        public static InputClass I_BlockDown = new InputClass(MotionCard, (int)InIndex.X44, "阻挡气缸下限备用");
        /// <summary>
        /// 1111
        /// </summary>
        public static InputClass I_BlockUp = new InputClass(MotionCard, (int)InIndex.X45, "阻挡气缸上限备用");
        /// <summary>
        /// 顶升气缸下限
        /// </summary>
        public static InputClass I_RiseDown = new InputClass(MotionCard, (int)InIndex.X46, "顶升气缸下限");
        /// <summary>
        /// 顶升气缸上限
        /// </summary>
        public static InputClass I_RiseUp = new InputClass(MotionCard, (int)InIndex.X47, "顶升气缸上限");
        /// <summary>
        /// 吸嘴1真空表
        /// </summary>
        public static InputClass I_Vacuum1 = new InputClass(MotionCard, (int)InIndex.X48, "左吸嘴真空表");
        /// <summary>
        /// 吸嘴2真空表
        /// </summary>
        public static InputClass I_Vacuum2 = new InputClass(MotionCard, (int)InIndex.X49, "右吸嘴真空表");
        /// <summary>
        /// 左升降伺服限位
        /// </summary>
        public static InputClass I_LeftRiseLmt = new InputClass(MotionCard, (int)InIndex.X50, "左升降伺服限位");
        /// <summary>
        /// 右升降伺服限位
        /// </summary>
        public static InputClass I_RightRiseLmt = new InputClass(MotionCard, (int)InIndex.X51, "右升降伺服限位");
        /// <summary>
        /// 出料流水线后段要料信号
        /// </summary>
        public static InputClass I_BeltUnfeedRequest = new InputClass(MotionCard, (int)InIndex.X52, "出料流水线后段要料信号");
        /// <summary>
        /// 下层流水线后段要料信号
        /// </summary>
        public static InputClass I_DownBeltRequest = new InputClass(MotionCard, (int)InIndex.X53, "下层流水线后段要料信号");
        /// <summary>
        /// 阻挡气缸下限
        /// </summary>
        public static InputClass I_StopBlockDown = new InputClass(MotionCard, (int)InIndex.X54, "阻挡气缸下限");
        /// <summary>
        /// 阻挡气缸上限
        /// </summary>
        public static InputClass I_StopBlockUp = new InputClass(MotionCard, (int)InIndex.X55, "阻挡气缸上限");
        /// <summary>
        /// 下层流水线出料感应
        /// </summary>
        public static InputClass I_DownBeltOut = new InputClass(MotionCard, (int)InIndex.X56, "下层流水线出料感应");
        /// <summary>
        /// 下层流水线进料感应
        /// </summary>
        public static InputClass I_DownBeltIn = new InputClass(MotionCard, (int)InIndex.X57, "下层流水线进料感应");
        /// <summary>
        /// 飞达1有无标签
        /// </summary>
        public static InputClass I_58 = new InputClass(MotionCard, (int)InIndex.X58, "NC");
        /// <summary>
        /// 飞达2有无标签
        /// </summary>
        public static InputClass I_59 = new InputClass(MotionCard, (int)InIndex.X59, "NC");



        #endregion

        #region 输出定义
        public static OutputClass Q_YellowLed = new OutputClass(MotionCard, (int)OutIndex.Y1, "黄灯");
        public static OutputClass Q_GreenLed = new OutputClass(MotionCard, (int)OutIndex.Y2, "绿灯");
        public static OutputClass Q_RedLed = new OutputClass(MotionCard, (int)OutIndex.Y3, "红灯");
        /// <summary>
        /// 蜂鸣器
        /// </summary>
        public static OutputClass Q_Buzzle = new OutputClass(MotionCard, (int)OutIndex.Y4, "蜂鸣");
        
        public static OutputClass Q_LabelFeeder1Request = new OutputClass(MotionCard, (int)OutIndex.Y5, "NC");
        
        public static OutputClass Q_LabelFeeder1Take = new OutputClass(MotionCard, (int)OutIndex.Y6, "NC");
        /// <summary>
        ///飞达请求送料信号
        /// </summary>
        public static OutputClass Q_FeederRequest = new OutputClass(MotionCard, (int)OutIndex.Y7, "飞达请求送料");
        /// <summary>
        /// 飞达麦拉已吸信号
        /// </summary>
        public static OutputClass Q_LabelFeeder2Take = new OutputClass(MotionCard, (int)OutIndex.Y8, "NC");
        /// <summary>
        /// 上相机光源控制
        /// </summary>
        public static OutputClass Q_UpLighSource = new OutputClass(MotionCard, (int)OutIndex.Y9, "上相机光源控制");
        /// <summary>
        /// 下相机光源控制
        /// </summary>
        public static OutputClass Q_DownLighSource = new OutputClass(MotionCard, (int)OutIndex.Y10, "下相机光源控制");
        
        public static OutputClass Q_11 = new OutputClass(MotionCard, (int)OutIndex.Y11, "NC");
        /// <summary>
        /// 顶升气缸
        /// </summary>
        public static OutputClass Q_Rise = new OutputClass(MotionCard, (int)OutIndex.Y12, "顶升气缸");
        /// <summary>
        /// 吸真空电磁阀
        /// </summary>
        public static OutputClass Q_Nuzzle1 = new OutputClass(MotionCard, (int)OutIndex.Y13, "吸真空电磁阀");
        /// <summary>
        /// 吸真空电磁阀
        /// </summary>
        public static OutputClass Q_Nuzzle2 = new OutputClass(MotionCard, (int)OutIndex.Y14, "吸真空电磁阀");
        /// <summary>
        /// 破真空电磁阀
        /// </summary>
        public static OutputClass Q_Blow1 = new OutputClass(MotionCard, (int)OutIndex.Y15, "破真空电磁阀");
        /// <summary>
        /// 破真空电磁阀
        /// </summary>
        public static OutputClass Q_Blow2 = new OutputClass(MotionCard, (int)OutIndex.Y16, "破真空电磁阀");
        /// <summary>
        /// 阻挡气缸
        /// </summary>
        public static OutputClass Q_StopBlock = new OutputClass(MotionCard, (int)OutIndex.Y17, "阻挡气缸");
        /// <summary>
        /// 入料流水线向前段要料信号
        /// </summary>
        public static OutputClass Q_PreFeedRequest = new OutputClass(MotionCard, (int)OutIndex.Y18, "入料流水线向前段要料信号");
        public static OutputClass Q_19 = new OutputClass(MotionCard, (int)OutIndex.Y19, "NC");
        /// <summary>
        /// 出料流水线给料信号
        /// </summary>
        public static OutputClass Q_UnfeedBeltGive = new OutputClass(MotionCard, (int)OutIndex.Y20, "出料流水线给料信号");
        public static OutputClass Q_21 = new OutputClass(MotionCard, (int)OutIndex.Y21, "NC");
        /// <summary>
        /// 下层流水线向前段要料信号
        /// </summary>
        public static OutputClass Q_DownBeltRequest = new OutputClass(MotionCard, (int)OutIndex.Y22, "下层流水线向前段要料信号");
        /// <summary>
        /// 下层流水线给料信号
        /// </summary>
        public static OutputClass Q_DownBeltGive = new OutputClass(MotionCard, (int)OutIndex.Y23, "下层流水线给料信号");
        public static OutputClass Q_24 = new OutputClass(MotionCard, (int)OutIndex.Y24, "NC");
        /// <summary>
        /// 照明灯
        /// </summary>
        public static OutputClass Q_Light = new OutputClass(MotionCard, (int)OutIndex.Y25, "照明灯");
        public static OutputClass Q_26 = new OutputClass(MotionCard, (int)OutIndex.Y26, "NC");
        public static OutputClass Q_27 = new OutputClass(MotionCard, (int)OutIndex.Y27, "NC");
        /// <summary>
        /// 光源控制器
        /// </summary>
        public static OutputClass Q_HoldLightCtrl = new OutputClass(MotionCard, (int)OutIndex.Y28, "光源控制器");
        public static OutputClass Q_29 = new OutputClass(MotionCard, (int)OutIndex.Y29, "NC");
        public static OutputClass Q_30 = new OutputClass(MotionCard, (int)OutIndex.Y30, "NC");
        #endregion
    }
    public class CTRCard
    {
        public static  AxisClass Axis_X { get { return DeviceRsDef.Axis_X; } }
        public static AxisClass Axis_Y { get { return DeviceRsDef.Axis_Y; } }
        public static List<AxisClass> Axis_Z = new List<AxisClass>();
        public static List<AxisClass> Axis_R = new List<AxisClass>();
        /// <summary>
        /// 真空压力表
        /// </summary>
        public static List<InputClass> I_Vacuum = new List<InputClass>();   //真空压力表
        /// <summary>
        /// 吸真空电磁阀
        /// </summary>
        public static List<OutputClass> Q_Nuzzle = new List<OutputClass>();  //吸真空电磁阀
        /// <summary>
        /// 破真空电磁阀
        /// </summary>
        public static List<OutputClass> Q_Blow = new List<OutputClass>();   //破真空电磁阀
        static CTRCard()
        {
            Axis_Z.Add(DeviceRsDef.Axis_Z1);
            Axis_Z.Add(DeviceRsDef.Axis_Z2);
            Axis_R.Add(DeviceRsDef.Axis_R1);
            Axis_R.Add(DeviceRsDef.Axis_R2);
            I_Vacuum.Add(DeviceRsDef.I_Vacuum1);
            I_Vacuum.Add(DeviceRsDef.I_Vacuum2);
            Q_Nuzzle.Add(DeviceRsDef.Q_Nuzzle1);
            Q_Nuzzle.Add(DeviceRsDef.Q_Nuzzle2);
            Q_Blow.Add(DeviceRsDef.Q_Blow1);
            Q_Blow.Add(DeviceRsDef.Q_Blow2);
        }
        /// <summary>
        /// XY轴到达
        /// </summary>
        public static bool XYArrive
        {
            get
            {
                if (Axis_X.status != 0 || Axis_Y.status != 0)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Z轴到达
        /// </summary>
        public static bool ZArrive
        {
            get
            {
                for (int i = 0; i < Axis_Z.Count; i++)
                {
                    if (Axis_Z[i].status != AxState.AXSTA_READY)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// R轴到达
        /// </summary>
        public static bool RArrive
        {
            get
            {
                for (int i = 0; i < Axis_R.Count; i++)
                {
                    if (Axis_R[i].status != AxState.AXSTA_READY)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static PointF3 Rotate(int Nuzzle , PointF3 BeforePoint , float Angle)
        {
            var para = Database.Product.Inst.Stickdata.StickSysData;
            PointF3 point = new PointF3();
            PointF3 AfterPoint = new PointF3();
            double angleHude = Angle * Math.PI / 180;/*角度变成弧度*/
            if (Nuzzle == 0)
            {
                double x1 = (para.Lift000CCDPos.X - para.Liftcirclepoint.X) * Math.Cos(angleHude) + (para.Lift000CCDPos.Y - para.Liftcirclepoint.Y) * Math.Sin(angleHude) + para.Liftcirclepoint.X;
                double y1 = -(para.Lift000CCDPos.X - para.Liftcirclepoint.X) * Math.Sin(angleHude) + (para.Lift000CCDPos.Y - para.Liftcirclepoint.Y) * Math.Cos(angleHude) + para.Liftcirclepoint.Y;
                AfterPoint.X = (float)x1;
                AfterPoint.Y = (float)y1;
                point.X = AfterPoint.X - (BeforePoint.X - para.Lift000CCDPos.X);
                point.Y = AfterPoint.Y - (BeforePoint.Y - para.Lift000CCDPos.Y);
            }
            else
            {
                double x1 = (para.Right000CCDPos.X - para.Rightcirclepoint.X) * Math.Cos(angleHude) + (para.Right000CCDPos.Y - para.Rightcirclepoint.Y) * Math.Sin(angleHude) + para.Rightcirclepoint.X;
                double y1 = -(para.Right000CCDPos.X - para.Rightcirclepoint.X) * Math.Sin(angleHude) + (para.Right000CCDPos.Y - para.Rightcirclepoint.Y) * Math.Cos(angleHude) + para.Rightcirclepoint.Y;
                AfterPoint.X = (float)x1;
                AfterPoint.Y = (float)y1;
                point.X = AfterPoint.X - (BeforePoint.X - para.Lift000CCDPos.X);
                point.Y = AfterPoint.Y - (BeforePoint.Y - para.Lift000CCDPos.Y);

            }
            return point;
        }
    }
}
