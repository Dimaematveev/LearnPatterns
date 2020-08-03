namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dic.Device_Location")]
    public partial class Dic_DeviceLocation : BD_Default
    {
        private int _ID;
        private string _Name;
        private bool _IsDelete;
        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        [Required]
        [StringLength(255)]
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

        public override BD_Default Copy()
        {
            Dic_DeviceLocation newDevice = null;
           
            newDevice = new Dic_DeviceLocation()
            {
                Name = this.Name,
                IsDelete = this.IsDelete
            };

            
            return newDevice;
        }

        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceLocation device)
            {
                Name = device.Name;
                IsDelete = device.IsDelete;
            }
        }
    }
}
