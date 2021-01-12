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

namespace HZZH.Logic.SubLogicPrg
{
    public class XYmove : LogicTask
    {
        public XYmove():base("轴动")
        {

        }
        public PointF2 targetPos { get; set; } = new PointF2();
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    for (int i = 0; i < CTRCard.Axis_Z.Count; i++)
                    {
                        CTRCard.Axis_Z[i].MC_MoveAbs(Product.Inst.Stickdata.ZSafePos);
                    }
                    LG.StepNext(2);
                    break;
                case 2:
                    if (CTRCard.ZArrive)
                    {
                        CTRCard.Axis_X.MC_MoveAbs(targetPos.X);
                        CTRCard.Axis_Y.MC_MoveAbs(targetPos.Y);
                        LG.StepNext(3);
                    }
                    break;
                case 3:
                    if (CTRCard.XYArrive)
                    {
                        LG.End();
                    }
                    break;
            }
        }
    }
}
