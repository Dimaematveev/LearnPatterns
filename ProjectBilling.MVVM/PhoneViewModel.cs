using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        private Phone Phone;

        public PhoneViewModel(Phone p)
        {
            Phone = p;
        }

        public string Title
        {
            get { return Phone.Title; }
            set
            {
                Phone.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return Phone.Company; }
            set
            {
                Phone.Company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return Phone.Price; }
            set
            {
                Phone.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}