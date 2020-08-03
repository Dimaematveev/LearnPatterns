namespace DataBase.BL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BalanceDictionary : DbContext
    {
        public BalanceDictionary()
            : base("name=BalanceDictionary")
        {
        }

        public virtual DbSet<Dic_DeviceLocation> DeviceLocations { get; set; }
        public virtual DbSet<Dic_DeviceModel> DeviceModels { get; set; }
        public virtual DbSet<Dic_DeviceSp_Si> DeviceSp_Si { get; set; }
        public virtual DbSet<Dic_DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Dic_DeviceGadget> DeviceGadgets { get; set; }

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
