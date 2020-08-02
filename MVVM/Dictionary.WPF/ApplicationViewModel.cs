using DataBase.BL;
using Dictionary.WPF.EditAdd;
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
        private UserControl selectUserControl;
        public UserControl SelectUserControl
        {
            get { return selectUserControl; }
            set
            {
                selectUserControl = value;
                OnPropertyChanged(nameof(SelectUserControl));
            }
        }
        public Dictionary<string, UserControl> ListDictionarys { get; }
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
                      ModelWindows modelWindows = new ModelWindows(new Dic_DeviceModel(), DiviceTypes);
                      if (modelWindows.ShowDialog() == true)
                      {
                          Dic_DeviceModel deviceModel = modelWindows.DeviceModel;
                         
                          db.DeviceModels.Add(deviceModel);
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
        public IEnumerable<Dic_DeviceType> DiviceTypes
        {
            get { return deviceTypes; }
            set
            {
                deviceTypes = value;
                OnPropertyChanged(nameof(DiviceTypes));
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
            deviceTypes = GetBdToList(db.DeviceTypes);
            DeviceModels = GetBdToList(db.DeviceModels);
            deviceSp_Sis = GetBdToList(db.DeviceSp_Si);
            deviceLocations = GetBdToList(db.DeviceLocations);
            ListDictionarys = new Dictionary<string, UserControl>();
            ListDictionarys.Add("Название таблиц",new ViewDictionary.GadgetControl());
            ListDictionarys.Add("Модели устройств",new ViewDictionary.ModelControl());
            ListDictionarys.Add("Типы устройств", null);
            ListDictionarys.Add("Местоположение", null);
            ListDictionarys.Add("СП и СИ", null);

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
