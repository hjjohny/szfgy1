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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenuControl mainMenu;
        private LaderUserControl ladder;
        private GameUserControl game;
        private GameStartOptionsControl gameStartOptions;

        private StrategyGameViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new StrategyGameViewModel();

            mainMenu= new MainMenuControl();
            mainMenu.MainMenuButtonClickedEvent += new MainMenuControl.ButtonClickEventHandler(selectFromMainMenu);

            gameStartOptions = new GameStartOptionsControl(vm);
            gameStartOptions.GameStartOptionsButtonClickedEvent += new GameStartOptionsControl.ButtonClickEventHandler(selectGameStartOption);

            ladder = new LaderUserControl(vm);
            ladder.BackToMainMenuButtonClickedEvent += new EventHandler(backToMainMenu);

            game = new GameUserControl(vm);

            mainControlArea.Content = mainMenu;

        }

        void selectFromMainMenu(string menuName_) 
        {
            switch (menuName_) 
            {
                case "Start Game":
                {
                    mainControlArea.Content = gameStartOptions;
                    break;
                }
                case "Load Game":
                {
                    break;
                }
                case "Ladder":
                {
                    mainControlArea.Content = ladder;
                    break;
                }
                case "Quit":
                {
                    Close();
                    break;
                }
            }
        }

        void selectGameStartOption(string buttonName_)
        {
            switch (buttonName_)
            {
                case "Launch Game":
                {
                  vm.startNewGame();
                   mainControlArea.Content = game;
                   break;
                }
                case "Back to MainMenu":
                {
                   mainControlArea.Content = mainMenu;
                   break;
                }
            }
        }

        void backToMainMenu(object sender,EventArgs e) 
        {
            mainControlArea.Content = mainMenu;
        }
    }
}
