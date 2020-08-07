namespace DataBase.BL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Таблица Тип устройства
    /// </summary>
    [Table("dic.Device_Type")]
    public partial class Dic_DeviceType : BD_Default
    {
        /// <summary> Приватный ID </summary>
        private int _ID;
        /// <summary> Приватное Название типа устройства </summary>
        private string _Name;
        /// <summary> Приватное поле для связи с названием таблицы </summary>
        private int _DeviceGadgetID;
        /// <summary> Приватное поле Удален ли элемент. </summary>
        private bool _IsDelete;
        /// <summary> Приватное название таблицы связанных с данным типом </summary>
        private Dic_DeviceGadget _DeviceGadget;
        /// <summary> Приватная коллекция связанных с этой таблицей Моделей устройств  </summary>
        private ICollection<Dic_DeviceModel> _DeviceModels;

        /// <summary>
        /// Пустой конструктор заполняет связанную коллекцию
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dic_DeviceType()
        {
            DeviceModels = new HashSet<Dic_DeviceModel>();
        }

        /// <summary> Публичный ID </summary>
        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary> Публичное поле для связи с названием таблицы </summary>
        public int DeviceGadgetID
        {
            get { return _DeviceGadgetID; }
            set
            {
                _DeviceGadgetID = value;
                OnPropertyChanged(nameof(DeviceGadgetID));
            }
        }
        /// <summary> Публичное Название типа устройства, до 50 символов </summary>
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
        /// <summary> Публичное название таблицы связанных с данным типом </summary>
        public virtual Dic_DeviceGadget DeviceGadget
        {
            get { return _DeviceGadget; }
            set
            {
                _DeviceGadget = value;
                OnPropertyChanged(nameof(DeviceGadget));
            }
        }
        /// <summary> Публичная коллекция связанных с этой таблицей Моделей устройств  </summary>
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


        /// <summary>
        /// Копирование всех Полей кроме ID в новую переменную.
        /// </summary>
        /// <returns> Новый класс </returns>
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
        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>

        public override void Fill(BD_Default bd_Default)
        {
            if (bd_Default is Dic_DeviceType device)
            {
                Name = device.Name;
                DeviceGadgetID = device.DeviceGadgetID;
                IsDelete = device.IsDelete;
            }
        }

    }
}
