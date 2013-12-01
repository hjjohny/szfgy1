using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StrategyGame.Model
{
    //TODO: Implement GameManager Class
    public class GameManager
    {
		private Player _currentPlayer;
		private MapHandler _mapHandler;
		private Player[] _players;
		private ResourceHandler _resourceHandler;
		private List<Unit> _newUnitsInTheCurrentTurn;
		private Int32 _turn;

		//TODO a játékosok hogy és hol keletkezzenek?
		/// <summary>
		/// Creates new game.
		/// </summary>
		/// <param name="player1">Object of first player.</param>
		/// <param name="player2">Object of second player.</param>
		public void newGame(Player player1, Player player2)
		{
			_mapHandler.generateMap();
			_players[0] = player1;
			_players[1] = player2;
			_currentPlayer = _players[0];
			_turn = 1;
		}

		/// <summary>
		/// Called when a player chooses to end his turn.
		/// If Player2 ends his turn, endTurn() is called.
		/// </summary>
		public void changePlayer()
		{
			if (_currentPlayer.Equals(_players[0])) {
				_currentPlayer = _players[1];
			} else {
				_currentPlayer = _players[0];
				endTurn();
			}
		}

		/// <summary>
		/// Called when Player2 ends his turn.
		/// Players get money, their units are feeded etc.
		/// </summary>
        private void endTurn()
        {
			for (short i = 0; i < 2; i++) {
				givePlayersMoney();
				_newUnitsInTheCurrentTurn.Clear();
				_players[i].feedUnits();
				//TODO ezeken kívül?
			}
			_turn++;
        }

		/// <summary>
		/// Called at the end of the game, returns the winner player.
		/// </summary>
		private Player decideWinner()
		{
			//TODO Implement decideWinner() method
			return _currentPlayer;
		}

		/// <summary>
		/// Called when the game has ended.
		/// </summary>
		public void gameOver()
        {
			Player winner = decideWinner();
			updateLader(winner);
			//TODO Nyilván meg kéne jeleníteni a képernyőn is.. hogyan?
			_mapHandler.destroyMap();
        }

		private void updateLader(Player winner)
		{
			//TODO Implement updateLader() method
			//TODO A ranglistát hol tároljuk?
		}

        public void loadLader()
        {
			//TODO Implement loadLader() method
			//TODO A ranglistát hol tároljuk?
        }
	
		/// <summary>
		/// Players get money based on their performance.
		/// </summary>
		private void givePlayersMoney()
		{
			//TODO Hogyan számoljuk a teljesítményt?
		}

		//TODO Talán a Unitnak is számon kéne tartania?
		/// <summary>
		/// New units can't move in the turn they were created in...
		/// </summary>
		private bool isUnitMoveDisabled(Unit unit)
		{
			return _newUnitsInTheCurrentTurn.Contains(unit);
		}

		private bool isMoveLegal(Unit unit, Position newPos)
		{
			return true;
			//TODO Implement isMoveLegal() method
		}

		private int calculateMoveCost(Position oldPos, Position newPos)
		{
			//Valami fasza útkereső algoritmus...
			//TODO hogyan számoljuk a cost-ot?
			//TODO Implement calculateMoveCost() method
			return 3;
		}

        public void moveUnit(Unit unit, Position newPos)
        {
			//safety check
			if (!unit.getPlayer().Equals(_currentPlayer))
				return;

			if (isUnitMoveDisabled(unit))
				return;

			if (!isMoveLegal(unit, newPos))
				return;

			bool moveOk = unit.MoveUnit(newPos, calculateMoveCost(unit.Position, newPos));

			if (!moveOk)
				return;

			//TODO harc szimulálás stb.
			//...
        }

		public void buyUnit(UnitType unitType)
		{
			Unit newUnit = new Unit(_currentPlayer._race, unitType);
			newUnit.Position = _currentPlayer.getStartingArea().getPosition();
			_currentPlayer._units.Add(newUnit);
			_currentPlayer._money -= newUnit.Price;
			_newUnitsInTheCurrentTurn.Add(newUnit);
		}

        public void saveGame()
        {
            //TODO Implement saveGame() method
        }

		public void loadGame()
		{
			//TODO Implement loadGame() method
		}

        public ObservableCollection<LadderObject> getLadder() 
        {
            return new ObservableCollection<LadderObject>();
        }
    }
}
