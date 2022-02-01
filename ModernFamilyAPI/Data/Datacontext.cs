using Microsoft.EntityFrameworkCore;

namespace ModernFamilyAPI.Data
{
    public class Datacontext:DbContext
    {

        public Datacontext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=Modernfamily;Trusted_connection=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ModernFamily> ModernFamilies { get; set; }

     
    }
}
