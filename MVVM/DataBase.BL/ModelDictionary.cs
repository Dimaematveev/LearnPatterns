namespace DataBase.BL
{
    using System.Data.Entity;

    public partial class ModelDictionary : DbContext
    {
        public ModelDictionary()
            : base("name=ModelDictionary")
        {
        }

        public virtual DbSet<ModelDevice> ModelDevices { get; set; }
        public virtual DbSet<TypeDevice> TypeDevices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelDevice>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeDevice>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeDevice>()
                .HasMany(e => e.ModelDevices)
                .WithRequired(e => e.TypeDevice)
                .WillCascadeOnDelete(false);
        }
    }
}
