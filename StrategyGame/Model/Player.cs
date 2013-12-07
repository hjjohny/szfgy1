using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyGame.Model
{
    public class Player
    {
        public String _name { get; set; }
        public RaceType _race { get; set; }
        public Int32 _income { get; set; }
        public Int32 _money { get; set; }
        public List<Unit> _units { get; set; }
        public Int32 _points { get; set; }
        //private List<Town> _towns { get; set; }

        public Player(String name_,RaceType race_,
                      Int32 startMoney_,Int32 startIncome_) 
        {
            _name = name_;
            _race = race_;
            _money = startMoney_;
            _income = startIncome_;
            _points = 0;
            _units = new List<Unit>();
            //_towns = new List<Town>();
        }
    }
}
