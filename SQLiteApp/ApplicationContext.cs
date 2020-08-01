using System.Data.Entity;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Phone> Phones { get; set; }
    }
}