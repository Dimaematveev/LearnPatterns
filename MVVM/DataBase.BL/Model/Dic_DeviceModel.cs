namespace DataBase.BL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Таблица модель устройства
    /// </summary>
    [Table("dic.Device_Model")]
    public partial class Dic_DeviceModel : BD_Default
    {
        /// <summary> Приватный ID </summary>
        private int _ID;
        /// <summary> Приватное название модели </summary>
        private string _Name;
        /// <summary> Приватное поле для связи с Типом устройства </summary>
        private int _DeviceTypeID;
        /// <summary> Приватное поле Удален ли элемент. </summary>
        private bool _IsDelete;
        /// <summary> Приватное Тип устройств связанных с данным типом </summary>
        private Dic_DeviceType _DeviceType;
        /// <summary> Публичный ID </summary>
        public override int ID 
        { 
            get { return _ID; } 
            set { _ID = value; } 
        }
        /// <summary> Публичное название модели, до 50 символов </summary>
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
        /// <summary> Публичное поле для связи с Типом устройства </summary>
        public int DeviceTypeID
        {
            get { return _DeviceTypeID; }
            set
            {
                _DeviceTypeID = value;
                OnPropertyChanged(nameof(DeviceTypeID));
            }
        }
        /// <summary> Публичное поле Удален ли элемент. </summary>
        public override bool IsDelete
        {
            get { return _IsDelete; }
            set
            {
                _IsDelete = value;
                OnPropertyChanged(nameof(IsDelete));
            }
        }
        /// <summary> Публичное Тип устройств связанных с данным типом </summary>
        public virtual Dic_DeviceType DeviceType
        {
            get { return _DeviceType; }
            set
            {
                _DeviceType = value;
                OnPropertyChanged(nameof(DeviceType));
            }
        }


        /// <summary>
        /// Копирование всех Полей кроме ID в новую переменную.
        /// </summary>
        /// <returns> Новый класс </returns>
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
        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>
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
