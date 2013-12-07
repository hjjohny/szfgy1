using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StrategyGame.Model
{
    public class GameManager
    {
        private const Int32 START_MONEY = 100;
        private const Int32 START_INCOME = 20;

		private Int32 _currentPlayerIndex;
		private Player[] _players;
        private Int32 _turn;

        private Random _randomGenerator;

        //private MapHandler _mapHandler;
		//private ResourceHandler _resourceHandler;

        //public interface

        public GameManager()
        {
            _randomGenerator = new Random();
        }

        public Player currentPlayer()
        {
            return _players[_currentPlayerIndex];
        }

        public void newGame(String p1Name_, int p1Race_, String p2Name_, int p2Race_ )
		{
			_players[0] = new Player(p1Name_,(RaceType)p1Race_,START_MONEY,START_INCOME);
            _players[1] = new Player(p2Name_,(RaceType)p2Race_,START_MONEY,START_INCOME);
            _currentPlayerIndex = 0;
			_turn = 1;
		}

        public void endTurn()
        {
            changePlayer();
            updateMoney();
            ++_turn;
        }

        public Boolean attack(Unit attacker_, Unit defender_) 
        {
            if (!isHit())
            {
                return false;
            }

            defender_._currentHealPoint -= attacker_._stats._damage;

            //xp kiszámítása

            Int32 xpEarnd=Convert.ToInt32((attacker_._stats._damage + defender_._stats._maxHealPoint) * (1 - 0.7));
            attacker_._xp+=xpEarnd;


            //ha megöli az egységet
            if(defender_._currentHealPoint <= 0) 
            {
                Int32 nextPalyerIndex = (_currentPlayerIndex + 1) % _players.Length;
                _players[nextPalyerIndex]._units.Remove(defender_);
                _players[nextPalyerIndex]._income = calculateIncome(_players[nextPalyerIndex]);
            }

            return true;
        }

        public void heal(Unit source_, Unit target_)
        {
            target_._currentHealPoint += source_._stats._healingPoint;
            if (target_._currentHealPoint > target_._stats._movementPoint)
            {
                target_._currentHealPoint = target_._stats._maxHealPoint;
            }
        }

        public void buyUnit(UnitType unitType_)
        {
            Unit newUnit = new Unit(unitType_, _players[_currentPlayerIndex]._race);
            //map.placeNewUnit(_players[currentPlayerIndex],newUnit); 
            _players[_currentPlayerIndex]._units.Add(newUnit);
            _players[_currentPlayerIndex]._money -= newUnit._stats._price;
        }

        public ObservableCollection<LadderObject> loadLadder()
        {

            return new ObservableCollection<LadderObject>();
            //TODO Implement loadLader() method
            //TODO A ranglistát hol tároljuk? fájlban
        }

        //private helper functions
        
        private Boolean isHit()
        {
            Int32 randomNum = _randomGenerator.Next(1,100);
            Int32 defPercentage = 0;//  lekérni a filedtől
            if (randomNum >= defPercentage)
            {
                return true;
            }
            return false;
        }

		private void updateLadder(Player winner)
		{
            
		}

        private void changePlayer()
        {
            _currentPlayerIndex = ++_currentPlayerIndex % _players.Length;
            foreach (var unit in _players[_currentPlayerIndex]._units)
            {
                unit._canMove = true;
            }
        }

        private void updateMoney()
        {
            _players[_currentPlayerIndex]._money += _players[_currentPlayerIndex]._income;
        }

        private Int32 calculateIncome(Player player_)
        {
            Int32 income = START_INCOME;

            /*foreach (var town in player_._towns)
            {
                income += town._income;
            }*/


            foreach (var unit in player_._units)
            {
                income -= unit._stats._resurveCost;
            }
            return income;
        }

        /* NINCS IDŐ!!!!!!!!!!!!!
         public void saveGame()
        {
            //TODO Implement saveGame() method
        }

		public void loadGame()
		{
			//TODO Implement loadGame() method
		}*/

    }
}
