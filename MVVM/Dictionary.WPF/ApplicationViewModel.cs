﻿using DataBase.BL;
using Dictionary.WPF.EditAdd;
using Dictionary.WPF.ViewDictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dictionary.WPF
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly BalanceDictionary db;
        private RelayCommand addCommand;
        private Relation selectRelation;
        public Relation SelectRelation
        {
            get { return selectRelation; }
            set
            {
                selectRelation = value;
                OnPropertyChanged(nameof(SelectRelation));
            }
        }

        ~ApplicationViewModel()
        {
            selectRelation = null;
            ListRelations.Clear();
        }
        public List<Relation> ListRelations { get; }
     #region Списки приватные Словарей
        private IEnumerable<Dic_DeviceModel>  deviceModels;
        private IEnumerable<Dic_DeviceType>  deviceTypes;
        private IEnumerable<Dic_DeviceGadget>  deviceGadgets;
        private IEnumerable<Dic_DeviceLocation> deviceLocations;
        private IEnumerable<Dic_DeviceSp_Si> deviceSp_Sis;
    #endregion
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      SelectRelation.AddEditWindow.DataContext = SelectRelation.NewObject;
                      if (SelectRelation.AddEditWindow.ShowDialog() == true)
                      {
                          var deviceModel = SelectRelation.AddEditWindow.DataContext;

                          SelectRelation.TableDb.Add(deviceModel);
                          db.SaveChanges();
                      }
                  }));
            }
        }

    #region Списки Словарей Геттеры и Сеттеры
        public IEnumerable<Dic_DeviceModel> DeviceModels
        {
            get { return deviceModels; }
            set
            {
                deviceModels = value;
                OnPropertyChanged(nameof(DeviceModels));
            }
        }
        public IEnumerable<Dic_DeviceType> DeviceTypes
        {
            get { return deviceTypes; }
            set
            {
                deviceTypes = value;
                OnPropertyChanged(nameof(DeviceTypes));
            }
        }
        public IEnumerable<Dic_DeviceGadget> DeviceGadgets
        {
            get { return deviceGadgets; }
            set
            {
                deviceGadgets = value;
                OnPropertyChanged(nameof(DeviceGadgets));
            }
        }
        public IEnumerable<Dic_DeviceLocation> DeviceLocations
        {
            get { return deviceLocations; }
            set
            {
                deviceLocations = value;
                OnPropertyChanged(nameof(DeviceLocations));
            }
        }
        public IEnumerable<Dic_DeviceSp_Si> DeviceSp_Sis
        {
            get { return deviceSp_Sis; }
            set
            {
                deviceSp_Sis = value;
                OnPropertyChanged(nameof(DeviceSp_Sis));
            }
        }
    #endregion


        public ApplicationViewModel()
        {
            db = new BalanceDictionary();
            DeviceGadgets = GetBdToList(db.DeviceGadgets);
            DeviceTypes = GetBdToList(db.DeviceTypes);
            DeviceModels = GetBdToList(db.DeviceModels);
            DeviceSp_Sis = GetBdToList(db.DeviceSp_Si);
            DeviceLocations = GetBdToList(db.DeviceLocations);
            ListRelations = new List<Relation>
            {
                new Relation("Название таблиц", new ViewDictionary.GadgetControl(), new EditAdd.GadgetWindows(null), db.DeviceGadgets, new Dic_DeviceGadget()),
                new Relation("Модели устройств", new ViewDictionary.ModelControl(), new EditAdd.ModelWindows(null,DeviceTypes), db.DeviceModels, new Dic_DeviceModel()),
                new Relation("Типы устройств", null, new EditAdd.TypeWindows(null,DeviceGadgets), db.DeviceTypes, new Dic_DeviceType()),
                new Relation("Местоположение", null, new EditAdd.LocationWindows(null), db.DeviceLocations, new Dic_DeviceLocation()),
                new Relation("СП и СИ", null, new EditAdd.Sp_SiWindows(null), db.DeviceSp_Si, new Dic_DeviceSp_Si())
            };
        }
        /// <summary>
        /// Получить данные из БД в список.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="dbTable"> DbSet Базы данных </param>
        /// <param name="list"> </param>
        /// <returns> Наш список куда копировались значения</returns>
        private IEnumerable<T1> GetBdToList<T1>(DbSet<T1> dbTable) where T1:class
        {
            dbTable.Load();
            return dbTable.Local.ToBindingList();
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
