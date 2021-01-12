using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;
using HZZH.Database;
using CommonRs;
using HZZH.Logic.Project;
using HzVision;
using Device;
using HZZH.Common.Config;
using Paste.Vision.Tool.RotateCenter;
using HZZH.Logic.LogicMain;

namespace HZZH.Logic.SubLogicPrg.Stick
{
    public class StickMainLogic: LogicTask
    {
        public StandardMark StandardMark { get; set; }
        public MarkScan markscan { get; set; }
        public TakeLabel takelabel { get; set; }
        public DownCCD downCCD { get; set; }
        public Stick stick { get; set; }
        public GiveUp giveup { get; set; }
        public Feeder feeder { get; set; }
        public ScanCode scancode { get; set; }
        public BackCT backCT { get; set; }
        public StickMainLogic() : base("贴附主流程")
        {
            StandardMark = new StandardMark();
            markscan = new MarkScan();
            takelabel = new TakeLabel();
            downCCD = new DownCCD();
            stick = new Stick();
            giveup = new GiveUp();
            feeder = new Feeder();
            scancode = new ScanCode();
            backCT = new BackCT();
        }
        public bool CanMarkscan { get; set; }
        public void NuzzleParaInit()
        {
            int nuzzleForbitCount = 0;
            for (int i = 0; i < 2; i++)
            {
                if (Product.Inst.Stickdata.NuzzleForbit[i] == true)
                {
                    nuzzleForbitCount++;
                }
            }
            //判断吸嘴是否已经全部禁用
            if (nuzzleForbitCount >= 2)
            {
                Alarm.SetAlarm(AlarmLevelEnum.Level2, "吸嘴全部禁用，请启用吸嘴");
            }
        }
        protected override void LogicImpl()
        {
            var Para = Product.Inst;
            LG.Start();
            switch (LG.Step)
            {
                case 1:
                    NuzzleParaInit();
                    LG.StepNext(2);
                    CanMarkscan = true;
                    break;
                case 2:
                    feeder.Start();
                    if (Para.Stickdata.StickSysData.stright)
                    {
                        LG.StepNext(0xef);
                    }
                    else
                    {
                        Para.ProcessData.StickPosList.Clear();
                        Para.ProcessData.currWhichPoint = 0;
                        Para.ProcessData.currWhichProduct = 0;
                        for (int i = 0; i < Product.Inst.Stickdata.TrayData.ProductList.Count; i++)
                        {
                            Para.ProcessData.StickPosList.Add(Product.Inst.Stickdata.TrayData.ProductList[i].Clone());
                        }
                        LG.StepNext(3);
                    }
                    break;
                case 3:
                    if (feeder.GetDone)
                    {
                        takelabel.Start();//取料
                        LG.StepNext(4);
                    }
                    break;
                case 4:
                    if (takelabel.GetDone)
                    {
                        downCCD.Start();//下相机拍照
                        LG.StepNext(5);
                    }
                    break;
                case 5:
                    if (downCCD.GetDone)
                    {
                        bool isGiveUp = false;
                        for (int i = 0; i < 2; i++)
                        {
                            //根据吸嘴上是否有料，并且下相机拍照NG，则满足弃料条件
                            if (Para.ProcessData.NuzzlePara[i].isOk != 1 && Para.ProcessData.NuzzlePara[i].isHave)
                            {
                                isGiveUp = true;
                            }
                        }
                        if (isGiveUp)
                        {
                            giveup.Start();
                            feeder.Start();
                            LG.StepNext(101);
                            break;
                        }
                        else
                        {
                            LG.StepNext(6);
                        }
                        feeder.Start();
                    }
                    break;
                case 101:
                    if (giveup.GetDone && feeder.GetDone)
                    {
                        LG.StepNext(3);
                    }
                    break;
                case 6:
                    if (TaskMain.feed.GetDone//暂时替代皮带流程
                        && DeviceRsDef.I_BeltFeedIn.Value
                        && TaskManager.Default.FSM.Status.ID  == FSMStaDef.RUN 
                        || Product.Inst.IsAging
                        )
                    {
                        if (CanMarkscan)
                        {
                            markscan.Start();
                            LG.StepNext(7);
                            CanMarkscan = false;
                        }
                        else
                        {
                            LG.StepNext(7);
                        }
                    }
                    break;
                case 7:
                    if (markscan.GetDone)
                    {
                        stick.Start();
                        LG.StepNext(8);
                    }
                    break;
                case 8:
                    if (stick.GetDone)
                    {
                        if (Para.ProcessData.currWhichProduct >= Para.ProcessData.StickPosList.Count)
                        {
                            CanMarkscan = true;
                            LG.StepNext(9);
                        }
                        else
                        {
                            LG.StepNext(102);
                        }
                    }
                    break;
                case 102:
                    LG.StepNext(3);
                    break;
                case 9:
                    scancode.Start();
                    LG.StepNext(10);
                    break;
                case 10:
                    if (scancode.GetDone)
                    {
                        LG.StepNext(11);
                    }
                    break;
                case 11:
                    backCT.Start();
                    LG.StepNext(12);
                    break;
                case 12:
                    if (backCT.GetDone)
                    {
                        LG.StepNext(0xef);
                    }
                    break;
                case 0xef:
                    if (Product.Inst.IsAging)
                    {
                        LG.StepNext(1);
                    }
                    else
                    {
                        LG.End();
                    }
                    break;
            }
        }
    }
}
