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
    /// Interaction logic for ModelWindows.xaml
    /// </summary>
    public partial class ModelWindows : Window, IEditAddViewWindows
    {
        private readonly Dic_DeviceModel dic_Device;
        public object GetDic_Device()
        {
            return dic_Device;
        }

        private readonly IEnumerable<Dic_DeviceType> DeviceTypes;
        public ModelWindows(Dic_DeviceModel deviceModel, IEnumerable<Dic_DeviceType> deviceTypes)
        {
            InitializeComponent();
            dic_Device = deviceModel;
            DeviceTypes = deviceTypes;
            TypeCombobox.ItemsSource = DeviceTypes;
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
