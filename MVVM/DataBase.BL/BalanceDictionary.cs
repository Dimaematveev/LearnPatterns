namespace DataBase.BL
{
    using System.Data.Entity;
    /// <summary>
    /// Класс с соединением к БД. Наследование от DbContext
    /// </summary>
    public partial class BalanceDictionary : DbContext
    {
        /// <summary>
        /// Пустой конструктор. По умолчанию передает "name=BalanceDictionary"
        /// </summary>
        public BalanceDictionary()
            : base("name=BalanceDictionaryWork")
        {
        }

        /// <summary> Местоположения устройств </summary>
        public virtual DbSet<Dic_DeviceLocation> DeviceLocations { get; set; }
        /// <summary> Модели устройств </summary>
        public virtual DbSet<Dic_DeviceModel> DeviceModels { get; set; }
        /// <summary> СП/СИ устройств </summary>
        public virtual DbSet<Dic_DeviceSp_Si> DeviceSp_Si { get; set; }
        /// <summary> Типы устройств </summary>
        public virtual DbSet<Dic_DeviceType> DeviceTypes { get; set; }
        /// <summary> Названия устройств  </summary>
        public virtual DbSet<Dic_DeviceGadget> DeviceGadgets { get; set; }

        //TODO: Надо уточнать??
        /// <summary> Не заню точно </summary>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dic_DeviceGadget>()
               .HasMany(e => e.DeviceTypes)
               .WithRequired(e => e.DeviceGadget)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dic_DeviceType>()
                .HasMany(e => e.DeviceModels)
                .WithRequired(e => e.DeviceType)
                .WillCascadeOnDelete(false);

           
        }
    }
}
