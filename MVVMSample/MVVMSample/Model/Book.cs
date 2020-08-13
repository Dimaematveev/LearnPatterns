using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Model
{
    public class Book : INotifyPropertyChanged
    {
        string autor;
        string title;
        public string Autor
        {
            get { return autor; }
            set
            {
                autor = value;
                OnPropertyChanged(nameof(Autor));
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public static Book[] GetBooks()
        {
            var result = new Book[]
            {
                new Book(){Autor = "Лев Толстой", Title="Война и мир"},
                new Book(){Autor = "Михаил Булгаков", Title="Мастер и Маргарита"},
                new Book(){Autor = "Стивен Кинг", Title="Оно"}
            };
            return result;  
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
