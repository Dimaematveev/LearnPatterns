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
    /// Interaction logic for TypeWindows.xaml
    /// </summary>
    public partial class TypeWindows : Window, IEditAddViewWindows
    {
        private readonly Dic_DeviceType dic_Device;
        public object GetDic_Device()
        {
            return dic_Device;
        }
        private readonly IEnumerable<Dic_DeviceGadget> DeviceGadgets;
        public TypeWindows(Dic_DeviceType deviceType, IEnumerable<Dic_DeviceGadget> deviceGadgets)
        {
            InitializeComponent();
            dic_Device = deviceType;
            DeviceGadgets = deviceGadgets;
            GadgetCombox.ItemsSource = DeviceGadgets;
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
