using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyGame.Model;


namespace StrategyGame.ViewModel
{
    
    //TODO: Implement ViewModel
    public class StrategyGameViewModel
    {
        private GameManager gm;
        public Player currentPlayer { get; set; }

        public ObservableCollection<LadderObject> ladder { get; protected set; }

        public ObservableCollection<Field> map { get;set; }

        public StrategyGameViewModel() 
        {
            gm = new GameManager();
            ladder = gm.getLadder();
            
            /*ladder = new ObservableCollection<LadderObject>();
            ladder.Add(new LadderObject("en",120)); */
        }

        public void setPlayerData(String p1Name_, int p1Race_, String p2Name_, int p2Race_) 
        {
            //gm.setPalyerData(p1Name_,p1Race_,p2Name_,p2Race_);
        }

        public void startNewGame() 
        {
            gm.newGame();
        }

        public void updateLadder()
        {
            ladder = gm.getLadder();
        }
        
    }
}
