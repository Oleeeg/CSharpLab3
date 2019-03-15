using System;
using System.Collections.Generic;
using System.Windows;

namespace СSharpLab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonCheckInViewModel(this);
        }
    }
}
