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
    public partial class GadgetWindows : Window, IEditAddViewWindows
    {
        
        private readonly Dic_DeviceGadget dic_Device;
        public object GetDic_Device()
        {
            return dic_Device;
        }
        public GadgetWindows(Dic_DeviceGadget deviceGadget)
        {
            InitializeComponent();
            dic_Device = deviceGadget;
            this.DataContext = dic_Device;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public Window GetWindow()
        {
            return this;
        }
    }
}
