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

        public virtual DbSet<DeviceLocation> Locations { get; set; }
        public virtual DbSet<DeviceModel> Models { get; set; }
        public virtual DbSet<DeviceSp_Si> Sp_Si { get; set; }
        public virtual DbSet<DeviceType> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceType>()
                .HasMany(e => e.DeviceModels)
                .WithRequired(e => e.DeviceType)
                .WillCascadeOnDelete(false);
        }
    }
}
