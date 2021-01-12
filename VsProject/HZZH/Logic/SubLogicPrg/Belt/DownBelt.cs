using HzControl.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZZH.Logic.Commmon;
using HZZH.Common.Config;

namespace HZZH.Logic.SubLogicPrg.Belt
{
    public class DownBelt : LogicTask
    {
        public DownBelt() : base("下皮带")
        {

        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                 case 1:

                    break;
            }
        }
    }
}
