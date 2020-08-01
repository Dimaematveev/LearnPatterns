using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        PhoneViewModel selectedPhone;

        IFileService fileService;
        IDialogService dialogService;

        public ObservableCollection<PhoneViewModel> Phones { get; set; }

        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                (saveCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogService.SaveFileDialog() == true)
                        {
                            fileService.Save(dialogService.FilePath, Phones.ToList());
                            dialogService.ShowMessage("Файл сохранен");
                        }
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                }));
            }
        }

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                (openCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogService.OpenFileDialog() == true)
                        {
                            var phones = fileService.Open(dialogService.FilePath);
                            Phones.Clear();
                            foreach (var p in phones)
                                Phones.Add(p);
                            dialogService.ShowMessage("Файл открыт");
                        }
                    }
                    catch (Exception ex)
                    {
                        dialogService.ShowMessage(ex.Message);
                    }
                }));
            }
        }

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
                    PhoneViewModel phoneViewModel = new PhoneViewModel(phone);
                    Phones.Insert(0, phoneViewModel);
                    SelectedPhone = phoneViewModel;
                }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                (removeCommand = new RelayCommand(obj =>
                {
                    PhoneViewModel phone = obj as PhoneViewModel;
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
                    PhoneViewModel phoneViewModel = obj as PhoneViewModel;
                    if (phoneViewModel != null)
                    {
                        Phone phone = new Phone
                        {
                            Company = phoneViewModel.Company,
                            Price = phoneViewModel.Price,
                            Title = phoneViewModel.Title
                        };
                        PhoneViewModel phoneViewModelCopy = new PhoneViewModel(phone);
                        Phones.Insert(0, phoneViewModelCopy);
                    }
                }));
            }
        }

        public PhoneViewModel SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            // данные по умлолчанию
            Phones = new ObservableCollection<PhoneViewModel>
            {
                new PhoneViewModel(new Phone() {Title="iPhone 7", Company="Apple", Price=56000 }),
                new PhoneViewModel(new Phone()  {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 }),
                new PhoneViewModel(new Phone()  {Title="Elite x3", Company="HP", Price=56000 }),
                new PhoneViewModel (new Phone() {Title="Mi5S", Company="Xiaomi", Price=35000 })
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