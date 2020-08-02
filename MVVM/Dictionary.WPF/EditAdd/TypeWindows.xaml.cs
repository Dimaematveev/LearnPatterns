﻿using DataBase.BL;
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
using System.Windows.Shapes;

namespace Dictionary.WPF.EditAdd
{
    /// <summary>
    /// Interaction logic for TypeWindows.xaml
    /// </summary>
    public partial class TypeWindows : Window
    {
        public readonly Dic_DeviceType DeviceType;
        private readonly IEnumerable<Dic_DeviceGadget> DeviceGadgets;
        public TypeWindows(Dic_DeviceType deviceType, IEnumerable<Dic_DeviceGadget> deviceGadgets)
        {
            InitializeComponent();
            DeviceType = deviceType;
            DeviceGadgets = deviceGadgets;
            GadgetCombox.ItemsSource = DeviceGadgets;
            this.DataContext = DeviceType;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
