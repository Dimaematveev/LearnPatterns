namespace DataBase.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dic.Device_Sp_Si")]
    public partial class Dic_DeviceSp_Si : BD_Default
    {
        private int _ID;
        private string _RegisterNumber;
        private string _Deal;
        private string _Page;
        private bool? _IsSp;
        private bool _IsDelete;

        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        [Required]
        [StringLength(150)]
        public string RegisterNumber
        {
            get { return _RegisterNumber; }
            set
            {
                _RegisterNumber = value;
                OnPropertyChanged(nameof(RegisterNumber));
            }
        }

        [StringLength(50)]
        public string Deal
        {
            get { return _Deal; }
            set
            {
                _Deal = value;
                OnPropertyChanged(nameof(Deal));
            }
        }

        [StringLength(10)]
        public string Page
        {
            get { return _Page; }
            set
            {
                _Page = value;
                OnPropertyChanged(nameof(Page));
            }
        }

        public bool? IsSp
        {
            get { return _IsSp; }
            set
            {
                _IsSp = value;
                OnPropertyChanged(nameof(IsSp));
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
            Dic_DeviceSp_Si newDevice = null;
            
            newDevice = new Dic_DeviceSp_Si()
            {
                RegisterNumber = this.RegisterNumber,
                Deal = this.Deal,
                Page = this.Page,
                IsSp = this.IsSp,
                IsDelete = this.IsDelete
            };

            
            return newDevice;
        }
        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceSp_Si device)
            {
                RegisterNumber = device.RegisterNumber;
                Deal = device.Deal;
                Page = device.Page;
                IsSp = device.IsSp;
                IsDelete = device.IsDelete;
            }
        }
    }
}
