using DataBase.BL;
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
        private RelayCommand editCommand;

        /// <summary>
        /// выбранное устройство
        /// </summary>
        private object selectedDic_Device;
        public object SelectedDic_Device
        {
            get { return selectedDic_Device; }
            set
            {
                selectedDic_Device = value;
                OnPropertyChanged(nameof(SelectedDic_Device));
            }
        }

        /// <summary>
        /// выбранный словарь
        /// </summary>
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
                      object newObj = SelectRelation.FuncNewObject();
                      IEditAddViewWindows editAddViewWindows = SelectRelation.FuncAddEditWindow(newObj);
                      if (editAddViewWindows.GetWindow().ShowDialog() == true)
                      {
                          var device = editAddViewWindows.GetDic_Device();

                          SelectRelation.TableDb.Add(device);
                          db.SaveChanges();
                      }
                  }));
            }
        }

        /// <summary>
        /// Команда Изменения
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((o) =>
                  {
                      ///MessageBox.Show(SelectedDic_Device.ToString());
                      if (SelectedDic_Device==null)
                      {
                          return;
                      }

                      var Dic_Device = SelectedDic_Device as NotifyPropertyChanged_Default;
                      var newDic_Device = Dic_Device.Copy() as NotifyPropertyChanged_Default;

                      IEditAddViewWindows editAddViewWindows = SelectRelation.FuncAddEditWindow(newDic_Device);
                      
                      if (editAddViewWindows.GetWindow().ShowDialog() == true)
                      {
                          Dic_Device.Fill(newDic_Device);
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
            #region Заполнение вывода словаря
            ListRelations = new List<Relation>
            {
                new Relation(
                                "Название таблиц", 
                                new ViewDictionary.GadgetControl(),
                                new Func<object, IEditAddViewWindows>((W) => (new EditAdd.GadgetWindows((Dic_DeviceGadget) W))), 
                                db.DeviceGadgets, 
                                new Func<object>(()=> new Dic_DeviceGadget())
                            ),
                new Relation(
                                "Модели устройств", 
                                new ViewDictionary.ModelControl(), 
                                new Func<object, IEditAddViewWindows>((W) =>  (new EditAdd.ModelWindows((Dic_DeviceModel)W, DeviceTypes))), 
                                db.DeviceModels,
                                new Func<object>(()=> new Dic_DeviceModel())
                            ),
                new Relation(
                                "Типы устройств",
                                new ViewDictionary.TypeControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.TypeWindows((Dic_DeviceType)W, DeviceGadgets)),
                                db.DeviceTypes,
                                new Func<object>(()=> new Dic_DeviceType())
                            ),
                new Relation(
                                "Местоположение",
                                new ViewDictionary.LocationControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.LocationWindows((Dic_DeviceLocation)W)),
                                db.DeviceLocations,
                                new Func<object>(()=> new Dic_DeviceLocation())
                            ),
                new Relation(
                                "СП и СИ",
                                new ViewDictionary.Sp_SiControl(),
                                new Func<object, IEditAddViewWindows>((W) => new EditAdd.Sp_SiWindows((Dic_DeviceSp_Si)W)),
                                db.DeviceSp_Si,
                                new Func<object>(()=> new Dic_DeviceSp_Si())
                            ),
            };
            
            #endregion

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
