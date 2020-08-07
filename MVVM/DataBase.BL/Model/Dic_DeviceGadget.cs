namespace DataBase.BL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dic.Device_Gadget")]
    public partial class Dic_DeviceGadget : BD_Default
    {
        private int _ID;
        private string _Name;
        private bool _IsDelete;
        private ICollection<Dic_DeviceType> _DeviceTypes;

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dic_DeviceType> DeviceTypes
        {
            get { return _DeviceTypes; }
            set
            {
                _DeviceTypes = value;
                OnPropertyChanged(nameof(DeviceTypes));
            }
        }

        public override BD_Default Copy()
        {
            Dic_DeviceGadget newDevice = null;
            newDevice = new Dic_DeviceGadget()
            {
                Name = this.Name,
                IsDelete = this.IsDelete
            };

            
            return newDevice;
        }

        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceGadget device)
            {
                Name = device.Name;
                IsDelete = device.IsDelete;
            }
        }
    }
}
