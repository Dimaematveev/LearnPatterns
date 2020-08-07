using Balance.BL;
using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.ComponentModel;

namespace Dictionary.BL
{
    public class ApplicationCommand : INotifyPropertyChanged
    {
        private readonly BalanceDictionary Db;
        /// <summary> выбранный словарь </summary>
        private Relation selectRelation;
        /// <summary> выбранное устройство</summary>
        private BD_Default selectedDic_Device;

        private RelayCommand addCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;

        public ApplicationCommand(BalanceDictionary db)
        {
            Db = db;
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

                      if (SelectedDic_Device == null)
                      {
                          return;
                      }

                      var newDic_Device = SelectedDic_Device.Copy();

                      IEditAddViewWindows editAddViewWindows = SelectRelation.FuncAddEditWindow(newDic_Device);

                      if (editAddViewWindows.GetWindow().ShowDialog() == true)
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
