namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dic.Device_Type")]
    public partial class Dic_DeviceType : NotifyPropertyChanged_Default
    {
        private int _ID;
        private string _Name;
        private string _GadgetName;
        private bool _IsDelete;
        private ICollection<Dic_DeviceModel> _DeviceModels;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dic_DeviceType()
        {
            DeviceModels = new HashSet<Dic_DeviceModel>();
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Required]
        [StringLength(50)]
        public string GadgetName
        {
            get { return _GadgetName; }
            set
            {
                _GadgetName = value;
                OnPropertyChanged(nameof(GadgetName));
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
        public virtual ICollection<Dic_DeviceModel> DeviceModels
        {
            get { return _DeviceModels; }
            set
            {
                _DeviceModels = value;
                OnPropertyChanged(nameof(DeviceModels));
            }
        }
    }
}
