using DataBase.BL;
using System;
using System.ComponentModel;

namespace ModelView.BL
{
    public class TypeView : INotifyPropertyChanged
    {
        private readonly TypeDevice typeDevice;
        public TypeDevice GetTypeDevice()
        {
            return typeDevice;
        }

        public string Name
        {
            get { return typeDevice.Name; }
            set 
            {
                typeDevice.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
