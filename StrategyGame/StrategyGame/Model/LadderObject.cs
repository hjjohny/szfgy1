using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyGame.Model
{
    public class LadderObject
    {
        public String PlayerName {get; set;}
        public Int32 Score { get; set; }

        public LadderObject(String pn_, Int32 s_)
        {
            PlayerName = pn_;
            Score = s_;
        }
    }
}
