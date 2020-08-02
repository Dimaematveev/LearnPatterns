namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dic.Device_Gadget")]
    public partial class Dic_DeviceGadget : NotifyPropertyChanged_Default
    {
        private int _ID;
        private string _Name;
        private bool _IsDelete;
        private ICollection<Dic_DeviceType> _DeviceTypes;

        public int ID
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

        public bool IsDelete
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
    }
}
