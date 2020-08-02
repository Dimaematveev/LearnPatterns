namespace DataBase.BL
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ModelDevice")]
    public partial class ModelDevice : INotifyPropertyChanged
    {
        private int _ID;
        private int _TypeDeviceID;
        private string _Name;
        private TypeDevice _TypeDevice;
        public int ID { get => _ID; set => _ID = value; }

        public int TypeDeviceID
        {
            get { return _TypeDeviceID; }
            set
            {
                _TypeDeviceID = value;
                OnPropertyChanged(nameof(TypeDeviceID));
            }
        }

        [StringLength(10)]
        public string Name {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public virtual TypeDevice TypeDevice 
        {
            get { return _TypeDevice; }
            set
            {
                _TypeDevice = value;
                OnPropertyChanged(nameof(TypeDevice));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
