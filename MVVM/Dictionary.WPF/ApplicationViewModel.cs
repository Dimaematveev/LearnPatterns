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
        private readonly ModelDictionary db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        private IEnumerable<ModelDevice>  modelDevices;
        private IEnumerable<TypeDevice>  typeDevices;

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      ModelWindows modelWindows = new ModelWindows(new ModelDevice());
                      if (modelWindows.ShowDialog() == true)
                      {
                          ModelDevice modelView = modelWindows.ModelDevice;
                         
                          db.ModelDevices.Add(modelView);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      ModelDevice modelDevices = selectedItem as ModelDevice;

                      ModelDevice vm = new ModelDevice()
                      {
                          ID = modelDevices.ID,
                          TypeDeviceID = modelDevices.TypeDeviceID,
                          Name = modelDevices.Name
                      };
                      //ModelView temp = new ModelView(vm);
                      ModelWindows modelWindows = new ModelWindows(vm);


                      if (modelWindows.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          vm = db.ModelDevices.Find(modelWindows.ModelDevice.ID);
                          if (modelDevices != null)
                          {
                              modelDevices.TypeDeviceID = modelWindows.ModelDevice.TypeDeviceID;
                              modelDevices.Name = modelWindows.ModelDevice.Name;
                              db.Entry(modelDevices).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        public IEnumerable<ModelDevice> ModelDevices
        {
            get { return modelDevices; }
            set
            {
                modelDevices = value;
                OnPropertyChanged(nameof(ModelDevices));
            }
        }
        public IEnumerable<TypeDevice> TypeDevices
        {
            get { return typeDevices; }
            set
            {
                typeDevices = value;
                OnPropertyChanged(nameof(TypeDevices));
            }
        }
        public ApplicationViewModel()
        {
            db = new ModelDictionary();
            db.ModelDevices.Load();
            ModelDevices = db.ModelDevices.Local.ToBindingList();
            db.TypeDevices.Load();
            TypeDevices = db.TypeDevices.Local.ToBindingList();
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
