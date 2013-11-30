using System;
using System.Collections.Generic;
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
using StrategyGame.ViewModel;

namespace StrategyGame.View
{
    /// <summary>
    /// Interaction logic for GameUserControl.xaml
    /// </summary>
    public partial class GameUserControl : UserControl
    {
        public event EventHandler BackToMainMenuButtonClickedEvent;

        private StrategyGameViewModel vm;

        public GameUserControl(StrategyGameViewModel vm_)
        {
            InitializeComponent();
            vm=vm_;
            gameTable.DataContext = vm;
            DataLine.DataContext = vm.currentPlayer;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            switch(clickedButton.Content.ToString())
            {
                case "Exit": 
                {
                    BackToMainMenuButtonClickedEvent(sender, e);
                    break;
                }
                case "Load":
                {
                    vm.Load();
                    break;
                }
                case "Save":
                {
                    vm.Save();
                    break;
                }
                case "End Turn":
                {
                    vm.EndTurn();
                    break;
                }
            }
        }


    }
}
