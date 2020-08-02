using DataBase.BL;
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
    /// Interaction logic for LocationWindows.xaml
    /// </summary>
    public partial class GadgetWindows : Window
    {
        Dic_DeviceGadget DeviceGadget;
        public GadgetWindows(Dic_DeviceGadget deviceGadget)
        {
            InitializeComponent();
            DeviceGadget = deviceGadget;
            this.DataContext = DeviceGadget;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
