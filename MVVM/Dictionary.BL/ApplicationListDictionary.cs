using DataBase.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;

namespace Dictionary.BL
{
    /// <summary> Список всех словарей </summary>
    public class ApplicationListDictionary : INotifyPropertyChanged
    {
        /// <summary> Приватная база данных </summary>
        private readonly BalanceDictionary Db;
        #region Списки приватные Словарей
        /// <summary> Приватный словарь Моделей устройств </summary>
        private IEnumerable<Dic_DeviceModel> deviceModels;
        /// <summary> Приватный словарь Типов устройств </summary>
        private IEnumerable<Dic_DeviceType> deviceTypes;
        /// <summary> Приватный словарь Названий таблиц </summary>
        private IEnumerable<Dic_DeviceGadget> deviceGadgets;
        /// <summary> Приватный словарь Местоположений </summary>
        private IEnumerable<Dic_DeviceLocation> deviceLocations;
        /// <summary> Приватный словарь СП и СИ </summary>
        private IEnumerable<Dic_DeviceSp_Si> deviceSp_Sis;
        #endregion


        public ApplicationListDictionary(BalanceDictionary db)
        {
            Db = db;
            DeviceGadgets = GetBdToList(Db.DeviceGadgets);
            DeviceTypes = GetBdToList(Db.DeviceTypes);
            DeviceModels = GetBdToList(Db.DeviceModels);
            DeviceSp_Sis = GetBdToList(Db.DeviceSp_Si);
            DeviceLocations = GetBdToList(Db.DeviceLocations);
        }


        #region Списки Словарей Геттеры и Сеттеры
        /// <summary> Словарь Моделей устройств </summary>
        public IEnumerable<Dic_DeviceModel> DeviceModels
        {
            get { return deviceModels; }
            set
            {
                deviceModels = value;
                OnPropertyChanged(nameof(DeviceModels));
            }
        }
        /// <summary> Словарь Типов устройств </summary>
        public IEnumerable<Dic_DeviceType> DeviceTypes
        {
            get { return deviceTypes; }
            set
            {
                deviceTypes = value;
                OnPropertyChanged(nameof(DeviceTypes));
            }
        }
        /// <summary> Словарь Названий таблиц </summary>
        public IEnumerable<Dic_DeviceGadget> DeviceGadgets
        {
            get { return deviceGadgets; }
            set
            {
                deviceGadgets = value;
                OnPropertyChanged(nameof(DeviceGadgets));
            }
        }
        /// <summary> Словарь Местоположений </summary>
        public IEnumerable<Dic_DeviceLocation> DeviceLocations
        {
            get { return deviceLocations; }
            set
            {
                deviceLocations = value;
                OnPropertyChanged(nameof(DeviceLocations));
            }
        }
        /// <summary> Словарь СП и СИ </summary>
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
        /// <summary>
        /// Получить данные из БД в список.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="dbTable"> DbSet Базы данных </param>
        /// <param name="list"> </param>
        /// <returns> Наш список куда копировались значения</returns>
        private IEnumerable<T1> GetBdToList<T1>(DbSet<T1> dbTable) where T1 : class
        {
            dbTable.Load();
            return dbTable.Local.ToBindingList();
        }


        //TODO: надо нормально расписать что делают они
        /// <summary> Событие изменения </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
