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

        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Type>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Models)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
