using Balance.BL;
using DataBase.BL;
using Dictionary.BL.EditAdd;
using System.ComponentModel;

namespace Dictionary.BL
{
    /// <summary>
    /// Класс для команд в приложении.
    /// </summary>
    public class ApplicationCommand : INotifyPropertyChanged
    {
        /// <summary> База данных </summary>
        private readonly BalanceDictionary Db;
        /// <summary> Приватный выбранный словарь </summary>
        private Relation selectRelation;
        /// <summary>Приватное выбранное устройство</summary>
        private BD_Default selectedDic_Device;

        /// <summary> Приватная Команда добавление </summary>
        private RelayCommand addCommand;
        /// <summary> Приватная Команда изменения </summary>
        private RelayCommand editCommand;
        /// <summary> Приватная Команда удаления </summary>
        private RelayCommand deleteCommand;

        /// <summary>
        /// Конструктор с передачей нашей базы.
        /// </summary>
        /// <param name="db"> База. </param>
        public ApplicationCommand(BalanceDictionary db)
        {
            Db = db;
        }

        /// <summary> Выбранное устройство </summary>
        public BD_Default SelectedDic_Device
        {
            get { return selectedDic_Device; }
            set
            {
                selectedDic_Device = value;
                OnPropertyChanged(nameof(SelectedDic_Device));
            }
        }
        /// <summary> Выбранный словарь </summary>
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
        /// <summary> Команда добавления </summary>
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
        /// <summary> Команда Изменения </summary>
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
        /// <summary> Команда удаления </summary>
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

        //TODO: надо нормально расписать что делают они
        /// <summary> Событие изменения </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
