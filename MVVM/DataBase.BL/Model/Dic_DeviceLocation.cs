namespace DataBase.BL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Таблица Местоположение
    /// </summary>
    [Table("dic.Device_Location")]
    public partial class Dic_DeviceLocation : BD_Default
    {
        /// <summary> Приватный ID </summary>
        private int _ID;
        /// <summary> Приватное Местоположение </summary>
        private string _Name;
        /// <summary> Приватное поле Удален ли элемент. </summary>
        private bool _IsDelete;
        /// <summary> Публичный ID </summary>
        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary> Публичное Местоположение. До 50 символов </summary>
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
        /// <summary>
        /// Копирование всех Полей кроме ID в новую переменную.
        /// </summary>
        /// <returns> Новый класс </returns>
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
        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>
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
