namespace DataBase.BL
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Таблица СП/СИ
    /// </summary>
    [Table("dic.Device_Sp_Si")]
    public partial class Dic_DeviceSp_Si : BD_Default
    {
        /// <summary> Приватный ID </summary>
        private int _ID;
        /// <summary> Приватный Рег.Номер </summary>
        private string _RegisterNumber;
        /// <summary> Приватное поле Дело </summary>
        private string _Deal;
        /// <summary> Приватное поле Страницы </summary>
        private string _Page;
        /// <summary> Приватное поле Является СП </summary>
        private bool? _IsSp;
        /// <summary> Приватное поле Удален ли элемент. </summary>
        private bool _IsDelete;
        /// <summary>  Публичный ID </summary>
        public override int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>  Публичный Рег.Номер, до 150 символов </summary>
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
        /// <summary>  Публичное поле Дело, до 50 символов </summary>
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
        /// <summary> Публичное поле Страницы, до 10 символов</summary>
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
        /// <summary>Публичное поле Является СП </summary>
        public bool? IsSp
        {
            get { return _IsSp; }
            set
            {
                _IsSp = value;
                OnPropertyChanged(nameof(IsSp));
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
        /// <summary>
        /// Заполнить все поля кроме ID, из данного 
        /// </summary>
        /// <param name="bd_Default"> Откуда копируются данные. </param>
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
