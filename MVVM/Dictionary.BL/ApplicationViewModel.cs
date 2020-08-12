using DataBase.BL;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dictionary.BL
{
    /// <summary>
    /// Основное представление Моделей БД во view
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Все приватные поля
        /// <summary> База данных </summary>
        public BalanceDictionary Db { get; }
        /// <summary> Приватное Команды для исполнения. </summary>
        private ApplicationCommand applicationCommand;
        /// <summary> Приватное Список Словарей. </summary>
        private ApplicationListDictionary applicationListDictionary;
        //TODO: может лучше в виде выпадающего списка.
        /// <summary> Приватное Показать удаленные </summary>
        private bool? showIsDelete;
        #endregion
        /// <summary>
        /// Список связей для изменения добавления
        /// </summary>
        public List<Relation> ListRelations { get; private set; }
        /// <summary> Показать удаленные </summary>
        public bool? ShowIsDelete
        {
            get { return showIsDelete; }
            set 
            {
                showIsDelete = value;
                OnPropertyChanged(nameof(ShowIsDelete));
            }
        }
        /// <summary> Команды для исполнения. </summary>
        public ApplicationCommand ApplicationCommand
        {
            get { return applicationCommand; }
            set
            {
                applicationCommand = value;
                OnPropertyChanged(nameof(ApplicationCommand));
            }
        }
        /// <summary> Список Словарей. </summary>
        public ApplicationListDictionary ApplicationListDictionary
        {
            get { return applicationListDictionary; }
            set
            {
                applicationListDictionary = value;
                OnPropertyChanged(nameof(ApplicationListDictionary));
            }
        }


        public ApplicationViewModel()
        {
            Db = new BalanceDictionary();
            ApplicationCommand = new ApplicationCommand(Db);
            ApplicationListDictionary = new ApplicationListDictionary(Db);
            ShowIsDelete =false;
        }

        /// <summary>
        /// Заполнение списка Связей для изменения добавления
        /// </summary>
        /// <param name="relations"></param>
        public void SetListRelations(List<Relation> relations)
        {
            if (ListRelations != null && ListRelations.Count > 0) 
            {
                return;
            }
            ListRelations = relations;
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
