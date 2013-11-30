﻿using System;
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
    /// Interaction logic for LaderUserControl.xaml
    /// </summary>
    public partial class LaderUserControl : UserControl
    {
        public event EventHandler BackToMainMenuButtonClickedEvent;


        private StrategyGameViewModel vm;

        public LaderUserControl(StrategyGameViewModel vm_)
        {
            InitializeComponent();
            vm = vm_;
            vm.updateLadder();

            listView.DataContext = vm;
            listView.ItemsSource= vm.ladder; 
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            BackToMainMenuButtonClickedEvent(sender,e);
        }
    }
}
