using Microsoft.EntityFrameworkCore;

namespace Demo_Lec2.Models
{
    public class ITI_Entity: DbContext
    {
        public ITI_Entity() : base() { }
        public ITI_Entity(DbContextOptions options) : base(options){ }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.;Initial Catalog=ITI_Tanta;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }   
    }
}
