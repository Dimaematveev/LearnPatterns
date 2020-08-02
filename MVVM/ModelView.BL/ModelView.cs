using DataBase.BL;
using System.ComponentModel;

namespace ViewModel.BL
{
    public class ModelView : INotifyPropertyChanged
    {
        private readonly ModelDevice modelDevice;
        public ModelDevice GetModelDevice()
        {
            return modelDevice;
        }

        public ModelView(ModelDevice model)
        {
            this.modelDevice = model;
        }
        /// установка свойств 
        public int TypeDeviceID
        {
            get { return modelDevice.TypeDeviceID; }
            set 
            {
                modelDevice.TypeDeviceID = value;
                OnPropertyChanged(nameof(TypeDeviceID));
                OnPropertyChanged(nameof(TypeDeviceName));
            }    
        }
        public string Name
        {
            get { return modelDevice.Name; }
            set
            {
                modelDevice.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string TypeDeviceName
        {
            get { return modelDevice.TypeDevice.Name; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
