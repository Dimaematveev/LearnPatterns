using Dictionary.WPF.ViewDictionary;
using System.Windows;

namespace Dictionary.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
