namespace DataBase.BL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dic.Device_Type")]
    public partial class Dic_DeviceType : BD_Default
    {
        private int _ID;
        private string _Name;
        private int _DeviceGadgetID;
        private bool _IsDelete;
        private Dic_DeviceGadget _DeviceGadget;
        private ICollection<Dic_DeviceModel> _DeviceModels;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dic_DeviceType()
        {
            DeviceModels = new HashSet<Dic_DeviceModel>();
        }

        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int DeviceGadgetID
        {
            get { return _DeviceGadgetID; }
            set
            {
                _DeviceGadgetID = value;
                OnPropertyChanged(nameof(DeviceGadgetID));
            }
        }

        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
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
        public virtual Dic_DeviceGadget DeviceGadget
        {
            get { return _DeviceGadget; }
            set
            {
                _DeviceGadget = value;
                OnPropertyChanged(nameof(DeviceGadget));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dic_DeviceModel> DeviceModels
        {
            get { return _DeviceModels; }
            set
            {
                _DeviceModels = value;
                OnPropertyChanged(nameof(DeviceModels));
            }
        }


        public override BD_Default Copy()
        {
            Dic_DeviceType newDevice = null;

            newDevice = new Dic_DeviceType()
            {
                Name = this.Name,
                DeviceGadgetID = this.DeviceGadgetID,
                IsDelete = this.IsDelete
            };

            
            return newDevice;
        }

        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceType device)
            {
                Name = device.Name;
                DeviceGadgetID = device.DeviceGadgetID;
                IsDelete = device.IsDelete;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
