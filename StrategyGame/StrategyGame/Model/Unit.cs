using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace StrategyGame.Model
{
    /// <summary>
    /// Race can be of three types: ELF/HUMAN/ORC
    /// </summary>
    public enum RaceType { ELF, MAN, ORC }

    /// <summary>
    /// Unit can be of four types: ATTACKER/DEFENDER/SUPPORTER/SCOUT
    /// </summary>
    public enum UnitType { ATTACKER, DEFENDER, SUPPORTER, SCOUT }

    //TODO: Implement Unit methods and functions
    class Unit
    {
        /// <summary>
        /// Race of the Unit: ELF/MAN/ORC
        /// </summary>
        private RaceType _Race;
        /// <summary>
        /// Type of the Unit: ATTACKER/DEFENDER/SUPPORTER/SCOUT
        /// </summary>
        private UnitType _Type;

        /// <summary>
        /// Name of the unit. It varies on race and unit type
        /// </summary>
        public String Name { get; private set; }
        public Int32 HealthPoint { get; private set; }
        private Int32 _MaxHealthPoint;
        public Int32 Damage { get; private set; }
        public Int32 Reach { get; private set; }
        public Double DefensePoint { get; private set; }
        public Int32 Price { get; private set; }
        public Int32 Cost { get; private set; }
        public Int32 MovingPoint { get; private set; }
        //private Int32 _MaxMovingPoint;
        public Int32 HealingPoint { get; private set; }
        public Point Position { get; set; }
        public Int32 Level { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rt">The unit's race</param>
        /// <param name="ut">The unit's type</param>
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

        /// <summary>
        /// Moves the unit to the given position with the given cost.
        /// If the unit has less MovingPoints then the necessary, no moving is executed.
        /// The function returns true if the movement is executed successfully, false otherwise.
        /// </summary>
        /// <param name="position">The new position on the map where the unit moves</param>
        /// <param name="moveCost">The cost of the moving</param>
        /// <returns>Whether the move was successful or not</returns>
        public Boolean MoveUnit(Point position, Int32 moveCost)
        {
            if (moveCost > MovingPoint)
                return false;

            MovingPoint -= moveCost;
            Position = position;
            return true;
        }

        /// <summary>
        /// Increases the HealthPoint value with the given amount of points.
        /// Returns with the new HealthPoint value.
        /// </summary>
        /// <param name="healingPoint">Rate of the increase</param>
        /// <returns>Value of the Health point after the increase</returns>
        public Int32 HealUnit(Int32 healingPoint)
        {
            if (HealthPoint + healingPoint <= _MaxHealthPoint)
            {
                HealthPoint += healingPoint;
            }
            else
            {
                HealthPoint = _MaxHealthPoint;
            }
            return HealthPoint;
        }

        /// <summary>
        /// Increases the level of the unit, sets the properties to the appropriate values.
        /// Return the new level of the unit.
        /// </summary>
        /// <returns>Level of the unit.</returns>
        public Int32 LevelUp()
        {
            if (Level == 1)
            {
                Level++;
                return Level;
            }
            if (Level == 2)
            {
                Level++;
                return Level;
            }
            return Level;
        }
    }
}
