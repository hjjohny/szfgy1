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
    /// Interaction logic for MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl
    {
        public delegate void ButtonClickEventHandler(string menuName_);

        public event ButtonClickEventHandler MainMenuButtonClickedEvent;

        public MainMenuControl()
        {
            InitializeComponent();
        }

        private void Button_ClickHandler(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            MainMenuButtonClickedEvent(clickedButton.Content.ToString());
        }
    }
}
