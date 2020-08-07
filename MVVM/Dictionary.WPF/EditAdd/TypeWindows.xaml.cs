using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.Collections.Generic;
using System.Windows;

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
