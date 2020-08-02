namespace DataBase.BL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDictionary : DbContext
    {
        public ModelDictionary()
            : base("name=ModelDictionary")
        {
        }

        public virtual DbSet<ModelDevice> ModelsDevises { get; set; }
        public virtual DbSet<TypeDevice> TypesDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelDevice>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeDevice>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeDevice>()
                .HasMany(e => e.ModelsDevices)
                .WithRequired(e => e.TypeDevice)
                .WillCascadeOnDelete(false);
        }
    }
}
