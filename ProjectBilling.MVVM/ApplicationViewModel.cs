using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public ObservableCollection<Phone> Phones { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    Phone phone = new Phone();
                    Phones.Insert(0, phone);
                    SelectedPhone = phone;
                }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                (removeCommand = new RelayCommand(obj =>
                {
                    Phone phone = obj as Phone;
                    if (phone != null)
                    {
                        Phones.Remove(phone);
                    }
                },
                (obj) => Phones.Count > 0));
            }
        }


        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (doubleCommand = new RelayCommand(obj =>
                    {
                        Phone phone = obj as Phone;
                        if (phone != null)
                        {
                            Phone phoneCopy = new Phone
                            {
                                Company = phone.Company,
                                Price = phone.Price,
                                Title = phone.Title
                            };
                            Phones.Insert(0, phoneCopy);
                        }
                    }));
            }
        }
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
{
new Phone { Title="iPhone 7", Company="Apple", Price=56000 },
new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
new Phone {Title="Elite x3", Company="HP", Price=56000 },
new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
};
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}