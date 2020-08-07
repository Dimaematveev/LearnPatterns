using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.Collections.Generic;
using System.Windows;

namespace Dictionary.WPF.EditAdd
{
    /// <summary>
    /// Interaction logic for Sp_SiWindows.xaml
    /// </summary>
    public partial class Sp_SiWindows : Window, IEditAddViewWindows
    {
        private readonly Dic_DeviceSp_Si dic_Device;
        public object GetDic_Device()
        {
            return dic_Device;
        }
        private readonly Dictionary<bool, string> TypeCheck;
        public Sp_SiWindows(Dic_DeviceSp_Si deviceSp_Si)
        {
            InitializeComponent();
            dic_Device = deviceSp_Si;
            this.DataContext = dic_Device;
            TypeCheck = new Dictionary<bool, string>
            {
                { true, "СП" },
                { false, "СИ" }
            };
            TypeCheckName.ItemsSource = TypeCheck;

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
