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
    /// Interaction logic for Sp_SiWindows.xaml
    /// </summary>
    public partial class Sp_SiWindows : Window
    {
        public readonly Dic_DeviceSp_Si DeviceSp_Si;
        private readonly Dictionary<bool, string> TypeCheck;
        public Sp_SiWindows(Dic_DeviceSp_Si deviceSp_Si)
        {
            InitializeComponent();
            DeviceSp_Si = deviceSp_Si;
            this.DataContext = DeviceSp_Si;
            TypeCheck = new Dictionary<bool, string>();
            TypeCheck.Add(true, "СП");
            TypeCheck.Add(false, "СИ");
            TypeCheckName.ItemsSource = TypeCheck;

        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
