using DataBase.BL;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dictionary.BL
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Все приватные поля
        public BalanceDictionary Db { get; }
        private ApplicationCommand applicationCommand;
        private ApplicationListDevice applicationListDevice;
        /// <summary> Показать удаленные </summary>
        private bool? showIsDelete;
        #endregion
        public List<Relation> ListRelations { get; private set; }
        public bool? ShowIsDelete
        {
            get { return showIsDelete; }
            set 
            {
                showIsDelete = value;
                OnPropertyChanged(nameof(ShowIsDelete));
            }
        }
        public ApplicationCommand ApplicationCommand
        {
            get { return applicationCommand; }
            set
            {
                applicationCommand = value;
                OnPropertyChanged(nameof(ApplicationCommand));
            }
        }
        public ApplicationListDevice ApplicationListDevice
        {
            get { return applicationListDevice; }
            set
            {
                applicationListDevice = value;
                OnPropertyChanged(nameof(ApplicationListDevice));
            }
        }


        public ApplicationViewModel()
        {
            Db = new BalanceDictionary();
            ApplicationCommand = new ApplicationCommand(Db);
            ApplicationListDevice = new ApplicationListDevice(Db);
            ShowIsDelete =false;
        }


        public void SetListRelations(List<Relation> relations)
        {
            if (ListRelations != null && ListRelations.Count > 0) 
            {
                return;
            }
            ListRelations = relations;
        }
       


       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
