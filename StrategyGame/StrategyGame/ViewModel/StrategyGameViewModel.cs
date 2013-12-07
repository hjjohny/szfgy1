using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model;
using StrategyGame.ViewModel.test;


namespace StrategyGame.ViewModel
{
    
    //TODO: Implement ViewModel
    public class StrategyGameViewModel: ViewModelBase
    {
        private GameManager gm;
        //public ModelStab gm;//for testing
        public Player currentPlayer { get; set; }
        public Int32 turn { get; set; }

        public ObservableCollection<LadderObject> ladder { get; set; }

        public Int32 mapSize;


        public StrategyGameViewModel() 
        {
            gm = new GameManager();

            //gm = new ModelStab();//for testing
            ladder = gm.loadLadder();
            currentPlayer = gm.currentPlayer();
            turn = gm._turn;
            
            mapSize = 0;
            
        }

        public void newGame(String p1Name_, int p1Race_, String p2Name_, int p2Race_) 
        {
            gm.newGame(p1Name_,p1Race_,p2Name_,p2Race_);
            currentPlayer=gm.currentPlayer();
        }

        public void updateLadder()
        {
            //ladder = gm.loadLadder();
        }

        public void Load() 
        {
            //gm.loadGame();
        }

        public void Save()
        {
            //gm.saveGame();
        }

        public void EndTurn()
        {
            gm.endTurn();
            currentPlayer = gm.currentPlayer();
            turn = gm._turn;
        }

        public void buyUnit()
        {
           // meg kell írni
           // gm.buyUnit();
        }
        
    }
}
