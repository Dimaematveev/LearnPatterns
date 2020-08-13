using MVVMSample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.ViewModel
{
    public class MainWindowViewModel :INotifyPropertyChanged
    {
        private Book[] books;
        public Book[] Books 
        {
            get { return books; }
            private set
            {
                books = value;
            }
        }

        public MainWindowViewModel()
        {
            Books = Book.GetBooks();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
