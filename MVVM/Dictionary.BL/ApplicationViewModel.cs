using Balance.BL;
using DataBase.BL;
using Dictionary.BL.EditAdd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;

namespace Dictionary.BL
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Все приватные поля
        public BalanceDictionary Db { get; }

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;
        /// <summary> выбранное устройство</summary>
        private BD_Default selectedDic_Device;
        /// <summary> выбранный словарь </summary>
        private Relation selectRelation;
        /// <summary>
        /// Показать удаленные
        /// </summary>
        private bool? showIsDelete;
        
        #endregion
        #region Списки приватные Словарей
        private IEnumerable<Dic_DeviceModel> deviceModels;
        private IEnumerable<Dic_DeviceType> deviceTypes;
        private IEnumerable<Dic_DeviceGadget> deviceGadgets;
        private IEnumerable<Dic_DeviceLocation> deviceLocations;
        private IEnumerable<Dic_DeviceSp_Si> deviceSp_Sis;
        #endregion

        public bool? ShowIsDelete
        {
            get { return showIsDelete; }
            set 
            {
                showIsDelete = value;
                OnPropertyChanged(nameof(ShowIsDelete));
            }
        }
        public BD_Default SelectedDic_Device
        {
            get { return selectedDic_Device; }
            set
            {
                selectedDic_Device = value;
                OnPropertyChanged(nameof(SelectedDic_Device));
            }
        }

       
        public Relation SelectRelation
        {
            get { return selectRelation; }
            set
            {
                selectRelation = value;
                OnPropertyChanged(nameof(SelectRelation));
            }
        }

        public List<Relation> ListRelations { get; private set; }
        

        #region Команды добавление/изменение/удаление
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
                          Db.SaveChanges();
                      }
                  }));
            }
        }
        //TODO: Если выбрали устройство и перешли на другой словарь, то крах
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
                     
                      if (SelectedDic_Device==null)
                      {
                          return;
                      }

                      var newDic_Device = SelectedDic_Device.Copy();

                      IEditAddViewWindows editAddViewWindows = SelectRelation.FuncAddEditWindow(newDic_Device);
                      
                      if (editAddViewWindows.GetWindow().ShowDialog()== true)
                      {
                          SelectedDic_Device.Fill(newDic_Device);
                          Db.SaveChanges();
                      }

                  }));
            }
        }
        /// <summary>
        /// Команда удаления
        /// </summary>
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((o) =>
                  {

                      if (SelectedDic_Device == null)
                      {
                          return;
                      }
                      SelectedDic_Device.IsDelete = true;
                      Db.SaveChanges();
                  }));
            }
        }
        #endregion

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
            Db = new BalanceDictionary();
            DeviceGadgets = GetBdToList(Db.DeviceGadgets);
            DeviceTypes = GetBdToList(Db.DeviceTypes);
            DeviceModels = GetBdToList(Db.DeviceModels);
            DeviceSp_Sis = GetBdToList(Db.DeviceSp_Si);
            DeviceLocations = GetBdToList(Db.DeviceLocations);
            ShowIsDelete=false;
            #region Заполнение вывода словаря
            #endregion

        }

        public void SetListRelations(List<Relation> relations)
        {
            if (ListRelations != null && ListRelations.Count > 0) 
            {
                return;
            }
            ListRelations = relations;
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
