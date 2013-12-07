using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace StrategyGame.Model
{

    public enum RaceType { ELF, MAN, ORC }
    public enum UnitType { ATTACKER, DEFENDER, SUPPORTER, SCOUT }


        public Unit(RaceType rt, UnitType ut)
        {
            _Race = rt;
            _Type = ut;
            HealingPoint = 0;

            switch (_Type)
            {
                case UnitType.ATTACKER:
                    if (_Race == RaceType.MAN)
                    {
                        Name = "Kardos";
                        Damage = 7;
                        Reach = 1;
                        HealthPoint = 30;
                        _MaxHealthPoint = 30;
                        DefensePoint = 0.5;
                        Price = 18;
                        Cost = 1;
                        MovingPoint = 4;
                    }
                    if (_Race == RaceType.ELF)
                    {
                        Name = "Ranger";
                        Damage = 6;
                        Reach = 1;
                        HealthPoint = 27;
                        _MaxHealthPoint = 27;
                        DefensePoint = 0.5;
                        Price = 15;
                        Cost = 1;
                        MovingPoint = 5;
                    }
                    if (_Race == RaceType.ORC)
                    {
                        Name = "Bunkós";
                        Damage = 8;
                        Reach = 2;
                        HealthPoint = 38;
                        _MaxHealthPoint = 38;
                        DefensePoint = 0.5;
                        Price = 18;
                        Cost = 1;
                        MovingPoint = 4;
                    }
                    break;
                case UnitType.DEFENDER:
                    if (_Race == RaceType.MAN)
                    {
                        Name = "Számszeríjász";
                        Damage = 5;
                        Reach = 4;
                        HealthPoint = 20;
                        _MaxHealthPoint = 20;
                        DefensePoint = 0.5;
                        Price = 16;
                        Cost = 1;
                        MovingPoint = 5;
                    }
                    if (_Race == RaceType.ELF)
                    {
                        Name = "Íjász";
                        Damage = 7;
                        Reach = 5;
                        HealthPoint = 18;
                        _MaxHealthPoint = 18;
                        DefensePoint = 0.5;
                        Price = 15;
                        Cost = 1;
                        MovingPoint = 6;
                    }
                    if (_Race == RaceType.ORC)
                    {
                        Name = "Lándzsás goblin";
                        Damage = 3;
                        Reach = 3;
                        HealthPoint = 25;
                        _MaxHealthPoint = 18;
                        DefensePoint = 0.5;
                        Price = 16;
                        Cost = 1;
                        MovingPoint = 5;
                    }
                    break;
                case UnitType.SUPPORTER:
                    if (_Race == RaceType.MAN)
                    {
                        Name = "Pap";
                        Damage = 3;
                        HealingPoint = 5;
                        Reach = 0;
                        HealthPoint = 15;
                        _MaxHealthPoint = 15;
                        DefensePoint = 0.5;
                        Price = 12;
                        Cost = 1;
                        MovingPoint = 5;
                    }
                    if (_Race == RaceType.ELF)
                    {
                        Name = "Druida";
                        Damage = 2;
                        HealingPoint = 7;
                        Reach = 0;
                        HealthPoint = 15;
                        _MaxHealthPoint = 15;
                        DefensePoint = 0.5;
                        Price = 20;
                        Cost = 2;
                        MovingPoint = 6;
                    }
                    if (_Race == RaceType.ORC)
                    {
                        Name = "Pap";
                        Damage = 5;
                        HealingPoint = 4;
                        Reach = 0;
                        HealthPoint = 15;
                        _MaxHealthPoint = 15;
                        DefensePoint = 0.5;
                        Price = 12;
                        Cost = 1;
                        MovingPoint = 5;
                    }
                    break;
                case UnitType.SCOUT:
                    if (_Race == RaceType.MAN)
                    {
                        Name = "Huszár";
                        Damage = 5;
                        Reach = 2;
                        HealthPoint = 25;
                        _MaxHealthPoint = 15;
                        DefensePoint = 0.4;
                        Price = 17;
                        Cost = 1;
                        MovingPoint = 7;
                    }
                    if (_Race == RaceType.ELF)
                    {
                        Name = "Hírnök";
                        Damage = 4;
                        Reach = 3;
                        HealthPoint = 22;
                        _MaxHealthPoint = 22;
                        DefensePoint = 0.4;
                        Price = 25;
                        Cost = 2;
                        MovingPoint = 8;
                    }
                    if (_Race == RaceType.ORC)
                    {
                        Name = "Farkas lovas";
                        Damage = 7;
                        Reach = 1;
                        HealthPoint = 28;
                        _MaxHealthPoint = 28;
                        DefensePoint = 0.4;
                        Price = 17;
                        Cost = 1;
                        MovingPoint = 6;
                    }
                    break;
            }

        }
    */

    public class UnitLvlDependentStats 
    {
        public Int32 _damage { get; set; }
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
        public String _name { get; protected set; }
        public Int32 _hitRadius { get; set; }
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

        public Unit(UnitType type_,RaceType raceType_ ) 
        {
            InitUnit(type_, raceType_);
        }

        private void InitUnit(UnitType type_, RaceType raceType_)
        {
            _type = type_;
            _raceType = raceType_;
            _canMove = false;
            //....
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

        private void updateStats(int _currentLevel)
        {
            //kilvasni
            _currentHealPoint = _stats._maxHealPoint;
        }

    }
}
