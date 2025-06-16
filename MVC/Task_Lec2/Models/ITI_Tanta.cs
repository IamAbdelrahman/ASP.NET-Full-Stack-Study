using Microsoft.EntityFrameworkCore;
namespace Task_Lec2.Models
{
    public class ITI_Tanta : DbContext
    {
        public ITI_Tanta() : base() { }
        public ITI_Tanta(DbContextOptions options) : base(options) { }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=.;Initial Catalog=Tanta_ITI;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
