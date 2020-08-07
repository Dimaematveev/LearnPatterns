namespace DataBase.BL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary> Имена таблиц для Устройств. В схеме dev </summary>
    [Table("dic.Device_Gadget")]
    
    public partial class Dic_DeviceGadget : BD_Default
    {
        /// <summary> Приватный ID </summary>
        private int _ID;
        /// <summary> Приватное имя таблицы </summary>
        private string _Name;
        /// <summary> Приватное поле Удален ли элемент. </summary>
        private bool _IsDelete;
        /// <summary> Приватная коллекция связанных с этой таблицей Типов устройств  </summary>
        private ICollection<Dic_DeviceType> _DeviceTypes;

        /// <summary>
        /// Пустой конструктор заполняет связанную коллекцию
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dic_DeviceGadget()
        {
            DeviceTypes = new HashSet<Dic_DeviceType>();
        }

        /// <summary> Публичный ID </summary>
        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary> Публичное имя таблицы. До 50 символов </summary>
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

        /// <summary> Публичная коллекция связанных с этой таблицей Типов устройств  </summary>
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


        /// <summary>
        /// Копирование всех Полей кроме ID в новую переменную.
        /// </summary>
        /// <returns> Новый класс </returns>
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

        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>
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
