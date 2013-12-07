using System;
using System.Collections.Generic;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StrategyGame.Model;


namespace StrategyGame.ViewModel.test
{
    public class ModelStab
    {
        private Player currentPlayer { get; set; }

        public TextBlock statusBarTextBlock { get; set; }

        public ModelStab()
        {
        }

        public void buyUnit()
        {
            statusBarTextBlock.Text = "ModelStab.buyUnit()";
        }

        public void endTurn()
        {
            statusBarTextBlock.Text = "ModelStab.endTurn()";
        }

        public void gameOver()
        {
            statusBarTextBlock.Text = "ModelStab.gameOver()";
        }

        public void loadGame()
        {
            statusBarTextBlock.Text = "ModelStab.loadGame()";
        }

        public void moveUnit()
        {
            statusBarTextBlock.Text = "ModelStab.moveUnit()";
        }

        public void newGame(String p1Name_, int p1Race_, String p2Name_, int p2Race_)
        {
            statusBarTextBlock.Text = "ModelStab.newGame()";
        }

        public void saveGame()
        {
            statusBarTextBlock.Text = "ModelStab.saveGame()";
        }


        public ObservableCollection<LadderObject> loadLadder()
        {
            ObservableCollection<LadderObject>  ladder = new ObservableCollection<LadderObject>();
            ladder.Add(new LadderObject("Pista", 120));
            ladder.Add(new LadderObject("Peti", 500));
            ladder.Add(new LadderObject("Rekord", 3000));
            return ladder;
        }
    }
}
