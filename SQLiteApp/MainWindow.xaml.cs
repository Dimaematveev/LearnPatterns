using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SQLiteApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ListBox PhonesList 
        {
            get { return phonesList; }
            set
            {
                phonesList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhonesList)));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}