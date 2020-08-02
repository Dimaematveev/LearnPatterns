using DataBase.BL;
using Dictionary.WPF.EditAdd;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace Dictionary.WPF
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly BalanceDictionary db;
        RelayCommand addCommand;
        private IEnumerable<Dic_DeviceModel>  modelDevices;

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      ModelWindows modelWindows = new ModelWindows(new Dic_DeviceModel());
                      if (modelWindows.ShowDialog() == true)
                      {
                          Dic_DeviceModel deviceModel = modelWindows.ModelDevice;
                         
                          db.DeviceModels.Add(deviceModel);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        
        public IEnumerable<Dic_DeviceModel> ModelDevices
        {
            get { return modelDevices; }
            set
            {
                modelDevices = value;
                OnPropertyChanged(nameof(ModelDevices));
            }
        }
        public ApplicationViewModel()
        {
            db = new BalanceDictionary();
            db.DeviceModels.Load();
            ModelDevices = db.DeviceModels.Local.ToBindingList();
           
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
