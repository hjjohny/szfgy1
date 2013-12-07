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
            //vm.gm.statusBarTextBlock = statesBarText;
            //gameTable.DataContext = vm;

            drawMap();

        }

        protected override void OnRender(DrawingContext e)
        {
            base.OnRender(e);
            refreshPlayerStatusLine();
        }



        private void refreshPlayerStatusLine() 
        {
            CurrentPlayerTB.Text = vm.currentPlayer._name;
            GoldTB.Text=vm.currentPlayer._money.ToString();
            IncomeTB.Text = vm.currentPlayer._income.ToString();
            TurnTB.Text = vm.turn.ToString();
        }

        private void drawMap() 
        {
            for (int i = 0; i < vm.mapSize; ++i)
            {
                Table.RowDefinitions.Add(new RowDefinition());
                Table.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < vm.mapSize; ++i)
            {
                for (int j = 0; j < vm.mapSize; ++j)
                {
                    Button tmp = new Button();
                    tmp.Content = "1";
                    //tmp.MouseUp += new MouseButtonEventHandler(tmp_MouseUp);
                    Grid.SetRow(tmp, i);
                    Grid.SetColumn(tmp, j);
                    Table.Children.Add(tmp);
                }
            }
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
                    refreshPlayerStatusLine();
                    break;
                }
                case "Buy Unit": 
                {
                    vm.buyUnit();
                    break;
                }
            }
        }


    }
}
