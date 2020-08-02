using DataBase.BL;
using System.Windows;

namespace Dictionary.WPF.EditAdd
{
    /// <summary>
    /// Interaction logic for ModelWindows.xaml
    /// </summary>
    public partial class ModelWindows : Window
    {
        public readonly ModelDevice ModelDevice;
        public ModelWindows(ModelDevice modelDevice)
        {
            InitializeComponent();
            this.ModelDevice = modelDevice;
            this.DataContext = this.ModelDevice;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
