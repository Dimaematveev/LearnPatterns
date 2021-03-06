﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SQLiteApp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        IEnumerable<Phone> phones;

        public IEnumerable<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged("Phones");
            }
        }

        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.Phones.Load();
            Phones = db.Phones.Local.ToBindingList();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      PhoneWindow phoneWindow = new PhoneWindow(new Phone());
                      if (phoneWindow.ShowDialog() == true)
                      {
                          Phone phone = phoneWindow.Phone;
                          db.Phones.Add(phone);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Phone phone = selectedItem as Phone;

                      Phone vm = new Phone()
                      {
                          Id = phone.Id,
                          Company = phone.Company,
                          Price = phone.Price,
                          Title = phone.Title
                      };
                      PhoneWindow phoneWindow = new PhoneWindow(vm);


                      if (phoneWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          phone = db.Phones.Find(phoneWindow.Phone.Id);
                          if (phone != null)
                          {
                              phone.Company = phoneWindow.Phone.Company;
                              phone.Title = phoneWindow.Phone.Title;
                              phone.Price = phoneWindow.Phone.Price;
                              db.Entry(phone).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem==null)
                      {
                          MessageBox.Show("NULL");
                      }
                      else
                      {
                          MessageBox.Show(selectedItem.ToString());
                      }
                      //if (selectedItem == null) return;
                      //// получаем выделенный объект
                      //Phone phone = selectedItem as Phone;
                      //db.Phones.Remove(phone);
                      //db.SaveChanges();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}