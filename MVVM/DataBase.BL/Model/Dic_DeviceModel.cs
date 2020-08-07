namespace DataBase.BL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dic.Device_Model")]
    public partial class Dic_DeviceModel : BD_Default
    {
        private int _ID;
        private string _Name;
        private int _DeviceTypeID;
        private bool _IsDelete;
        private Dic_DeviceType _DeviceType;
        public override int ID 
        { 
            get { return _ID; } 
            set { _ID = value; } 
        }

        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return _Name; }
            set {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int DeviceTypeID
        {
            get { return _DeviceTypeID; }
            set
            {
                _DeviceTypeID = value;
                OnPropertyChanged(nameof(DeviceTypeID));
            }
        }

        public override bool IsDelete
        {
            get { return _IsDelete; }
            set
            {
                _IsDelete = value;
                OnPropertyChanged(nameof(IsDelete));
            }
        }

        public virtual Dic_DeviceType DeviceType
        {
            get { return _DeviceType; }
            set
            {
                _DeviceType = value;
                OnPropertyChanged(nameof(DeviceType));
            }
        }


        public override BD_Default Copy()
        {
            Dic_DeviceModel newDevice = null;
          
            newDevice = new Dic_DeviceModel()
            {
                Name = this.Name,
                DeviceTypeID = this.DeviceTypeID,
                IsDelete = this.IsDelete
            };

            
            return newDevice;
        }

        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceModel device)
            {
                Name = device.Name;
                DeviceTypeID = device.DeviceTypeID;
                IsDelete = device.IsDelete;
            }
        }
    }
}
