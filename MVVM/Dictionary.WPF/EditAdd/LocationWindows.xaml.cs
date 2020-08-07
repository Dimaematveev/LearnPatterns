using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.Windows;

namespace Dictionary.WPF.EditAdd
{
    /// <summary>
    /// Interaction logic for LocationWindows.xaml
    /// </summary>
    public partial class LocationWindows : Window, IEditAddViewWindows
    {
        private readonly Dic_DeviceLocation dic_Device;
        public object GetDic_Device()
        {
            return dic_Device;
        }
        public LocationWindows(Dic_DeviceLocation deviceLocation)
        {
            InitializeComponent();
            dic_Device = deviceLocation;
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
