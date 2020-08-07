using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.Windows;

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
