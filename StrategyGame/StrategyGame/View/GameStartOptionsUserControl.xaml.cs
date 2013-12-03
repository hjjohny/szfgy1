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
using StrategyGame.Model;

namespace StrategyGame.View
{
    /// <summary>
    /// Interaction logic for gameStartOptionsControl.xaml
    /// </summary>
    public partial class GameStartOptionsUserControl : UserControl
    {
        public delegate void ButtonClickEventHandler(string buttonName_);

        public event ButtonClickEventHandler GameStartOptionsButtonClickedEvent;

        private StrategyGameViewModel vm;

        public GameStartOptionsUserControl(StrategyGameViewModel vm_)
        {
            InitializeComponent();
            vm = vm_;
            Player1Race.ItemsSource = Enum.GetValues(typeof(RaceType))
                                          .Cast<RaceType>()
                                          .Select(p => new { Value = p.ToString() })
                                          .ToList();
            Player1Race.DisplayMemberPath = "Value";
            Player1Race.SelectedIndex = 1;

            Player2Race.ItemsSource = Enum.GetValues(typeof(RaceType))
                                          .Cast<RaceType>()
                                          .Select(p => new {Value = p.ToString() })
                                          .ToList();
            Player2Race.DisplayMemberPath = "Value";
            Player2Race.SelectedIndex = 1;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Content.ToString() == "Launch Game") 
            {
                vm.newGame(player1Name.Text,Player1Race.SelectedIndex, player2Name.Text, Player2Race.SelectedIndex);
            }
            GameStartOptionsButtonClickedEvent(clickedButton.Content.ToString());
        }
    }
}
