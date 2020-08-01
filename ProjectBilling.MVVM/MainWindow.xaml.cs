﻿using System.Windows;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new SoapFileService());
        }
    }
}