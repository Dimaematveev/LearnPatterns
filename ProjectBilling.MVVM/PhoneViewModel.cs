using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        public Phone Phone { get; }
        public PhoneViewModel(Phone phone)
        {
            Phone = phone;
        }
        public string Title
        {
            get { return Phone.Title; }
            set
            {
                Phone.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Company
        {
            get { return Phone.Company; }
            set
            {
                Phone.Company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        public int Price
        {
            get { return Phone.Price; }
            set
            {
                Phone.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}