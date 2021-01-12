using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    class LogicLoopRun : LogicLoop
    {
        public LogicLoopRun() : base("报警等循环扫描")
        {

        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        private void BtEvent()
        {
            //运行按钮
            if (DeviceRsDef.I_Start.Value)
            {
                FSM.Start();
            }
            //停止按钮
            if (DeviceRsDef.I_Stop.Value)
            {
                if (FSM.Status != HzControl.Logic.FSMStaDef.RUN)
                {
                    Alarm.ClearAlarm();
                }
                FSM.Stop();
            }

            //停止按钮
            if (DeviceRsDef.I_Reset.Value)
            {
                FSM.Reset();
            }

            //急停
            if (DeviceRsDef.I_Scam.Value)
            {
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    if (DeviceRsDef.AxisList[i].status != Device.AxState.AXSTA_READY)
                    {
                        DeviceRsDef.AxisList[i].MC_Stop();
                    }
                    DeviceRsDef.AxisList[i].MC_PowerOn();
                }

                FSM.Scram();
            }
            else
            {
                //当松开急停后，状态机恢复到初始态
                if (FSM.Status == HzControl.Logic.FSMStaDef.SCRAM)
                {
                    FSM.Init();
                }
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_PowerOff();
                }
            }

            if (FSM.Status == HzControl.Logic.FSMStaDef.SCRAM)
            {
                //Alarm.SetAlarm(AlarmLevelEnum.Level3, "急停按下");
            }
        }
        /// <summary>
        /// 报警后处理
        /// </summary>
        private void AlarmEvent()
        {
            if (Alarm.AlarmLever == AlarmLevelEnum.Level2)
            {
                FSM.Stop();
            }
            else if (Alarm.AlarmLever > AlarmLevelEnum.Level2)
            {
                
                if (FSM.Status == FSMStaDef.RUN)
                {
                    for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                    {
                        DeviceRsDef.AxisList[i].MC_Stop();
                    }
                }
                FSM.ErrorStop();
                //先复位把其他流程
                //foreach (var item in this.Manager.LogicTasks)
                //{                    
                //   item.Reset();
                //}
            }
            if (!DeviceRsDef.MotionCard.netSucceed)
            {
                if(!DeviceRsDef.MotionCard.netSucceed)
                {
                    Alarm.SetAlarm(AlarmLevelEnum.Level3, "控制卡掉线");
                }
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_Stop();
                }
            }

            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                if (DeviceRsDef.AxisList[i].status == Device.AxState.AXSTA_ERRSTOP)
                {
                    string alarmMessage = DeviceRsDef.AxisList[i].errMesg;
                    Alarm.SetAlarm(AlarmLevelEnum.Level3, alarmMessage);
                }
            }
        }
        protected override void LogicImpl()
        {
            BtEvent();
            AlarmEvent();
        }
    }
}
