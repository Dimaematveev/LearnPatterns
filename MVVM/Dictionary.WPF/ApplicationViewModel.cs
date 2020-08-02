using DataBase.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using ViewModel.BL;

namespace Dictionary.WPF
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly ModelDictionary db;
        RelayCommand addCommand;
        private IEnumerable<ModelView> modelViews;
        private IEnumerable<TypeView> typeViews;

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      EditAdd.ModelWindows modelWindows = new EditAdd.ModelWindows(new ModelView(new ModelDevice()));
                      if (modelWindows.ShowDialog() == true)
                      {
                          ModelView modelView = modelWindows.ModelView;
                          db.ModelDevices.Add(modelView.GetModelDevice());
                          db.SaveChanges();
                      }
                  }));
            }
        }

        public IEnumerable<ModelView> ModelViews
        {
            get { return modelViews; }
            set
            {
                modelViews = value;
                OnPropertyChanged(nameof(ModelViews));
            }
        }
        public IEnumerable<TypeView> TypeViews
        {
            get { return typeViews; }
            set
            {
                typeViews = value;
                OnPropertyChanged(nameof(TypeViews));
            }
        }
        public ApplicationViewModel()
        {
            db = new ModelDictionary();
            db.ModelDevices.Load();
            ModelViews = db.ModelDevices.Local.Select(x => new ModelView(x)).ToList();
            db.TypeDevices.Load();
            TypeViews = db.TypeDevices.Local.Select(x => new TypeView(x)).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
