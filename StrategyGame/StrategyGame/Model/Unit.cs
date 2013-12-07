using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace StrategyGame.Model
{

    public enum RaceType { ELF, HUMAN, ORC }
    public enum UnitType { ATTACKER, DEFENDER, SUPPORT, SCOUT }

    public class UnitLvlDependentStats 
    {
        public UnitLvlDependentStats(String name_,
                                     Int32 damage_,
                                     Int32 hitRadius_,
                                     Int32 maxHealPoint_,
                                     Int32 resurveCost_,
                                     Int32 price_,
                                     Int32 movementPoint_,
                                     Int32 healingPoint_,
                                     Int32 requiredXp_)
        {
            //képet is
            _name = name_;
            _damage=damage_;
            _hitRadius=hitRadius_;
            _maxHealPoint=maxHealPoint_;
            _resurveCost=resurveCost_;
            _price=price_;
            _movementPoint=movementPoint_;
            _healingPoint=healingPoint_;
            _requiredXp=requiredXp_;
        }

        //public Picture _picture {get;set} maphoz nem tudom honna töltöd be a képeket, de inne rajzold ki
        public String _name { get; protected set; }
        public Int32 _damage { get; set; }
        public Int32 _hitRadius { get; set; }
        public Int32 _maxHealPoint { get; set; }
        public Int32 _resurveCost { get; set; }
        public Int32 _price { get; set; }
        public Int32 _movementPoint { get; set; }
        public Int32 _healingPoint { get; set; }
        public Int32 _requiredXp {get;set;}
    }

    public class Unit 
    {
        static private Int32 MAX_LVL = 3;

        public RaceType _raceType {get; protected set;}
        public UnitType _type { get; protected set; }
        public Int32 _currentLevel { get; protected set; }
        public Int32 _currentHealPoint { get; set; }
        public Point _position { get; set; }
        public Boolean _canMove { get;set; }
        public Int32 _xp
        {
            set
            {
                _xp += value;
                if (_xp >= _stats._requiredXp)
                {
                    levelUp();
                }
            }

            get 
            {
                return _xp;
            }
        }
        public UnitLvlDependentStats _stats { get; set; }

        public Unit(UnitType type_,RaceType raceType_) 
        {
            InitUnit(type_, raceType_);
        }

        private void InitUnit(UnitType type_, RaceType raceType_, Point pos_=new Point())
        {
            _stats=loadStats(type_,raceType_);

            _raceType = raceType_;
            _type = type_;
            _currentLevel = 1;
            _currentHealPoint=_stats._maxHealPoint;
            _position=pos_;
            _canMove = false;
            _xp=0;
        }

        private void levelUp() 
        {
            if (_currentLevel < MAX_LVL)
            {
                ++_currentLevel;
                _xp = 0;
                updateStats(_currentLevel);
            }
        }

        //nincs rá idő nincs lvup!!!!!!!!!!
        private void updateStats(int _currentLevel)
        {
            _currentHealPoint = _stats._maxHealPoint;
        }

        //idő hiányában ...
        private UnitLvlDependentStats loadStats(UnitType type_,RaceType raceType_)
        {
 	        UnitLvlDependentStats newUnit = null;
            switch(raceType_)
            {
                case RaceType.HUMAN:
                {
                    switch(type_)
                    {
                        case UnitType.ATTACKER:
                        {
                            newUnit= new UnitLvlDependentStats("Kardos",7,1,30,1,18,4,0,30);
                            break;
                        }
                        case UnitType.DEFENDER:
                        {
                             newUnit= new UnitLvlDependentStats("Számszeríjász",5,4,20,1,16,5,0,30);
                            break;
                        }
                        case UnitType.SUPPORT:
                        {
                             newUnit= new UnitLvlDependentStats("Pap",3,2,15,1,12,5,5,30);
                            break;
                        }
                        case UnitType.SCOUT:
                        {
                             newUnit= new UnitLvlDependentStats("Huszár",5,2,25,1,17,7,0,30);
                            break;
                        }
                    }
                    break;
                }
                case RaceType.ELF:
                {
                    switch (type_)
                    {
                        case UnitType.ATTACKER:
                            {
                                newUnit = new UnitLvlDependentStats("Ranger", 6, 1, 27, 1, 15, 5, 0, 30);
                                break;
                            }
                        case UnitType.DEFENDER:
                            {
                                newUnit = new UnitLvlDependentStats("LombIjasz", 7, 5, 18, 1, 15, 6, 0, 30);
                                break;
                            }
                        case UnitType.SUPPORT:
                            {
                                newUnit = new UnitLvlDependentStats("Druida", 2, 1, 15, 2, 20, 6, 7, 30);
                                break;
                            }
                        case UnitType.SCOUT:
                            {
                                newUnit = new UnitLvlDependentStats("Hirnok", 4, 3, 22, 2, 25, 8, 0, 30);
                                break;
                            }
                    }
                    break;
                }
                case RaceType.ORC:
                {
                    switch(type_)
                    {
                        case UnitType.ATTACKER:
                        {
                            newUnit= new UnitLvlDependentStats("Bunkós",8,2,38,1,18,4,0,30);
                            break;
                        }
                        case UnitType.DEFENDER:
                        {
                             newUnit= new UnitLvlDependentStats("Lándzsás Goblin",3,3,25,1,16,5,0,30);
                            break;
                        }
                        case UnitType.SUPPORT:
                        {
                             newUnit= new UnitLvlDependentStats("OrkPap",5,1,15,1,12,5,4,30);
                            break;
                        }
                        case UnitType.SCOUT:
                        {
                             newUnit= new UnitLvlDependentStats("Farkas Lovas",7,1,28,1,17,6,0,30);
                            break;
                        }
                    }
                    break;
                }
                default:
                    throw new Exception();
            }
            return newUnit;
        }
    }
}
