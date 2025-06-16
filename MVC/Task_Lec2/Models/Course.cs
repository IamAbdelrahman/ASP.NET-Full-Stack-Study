using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task_Lec2.Models
{
    public class Course
    {
        private int id = 0;
        private string name = "";
        private int degree = 0;
        private int minDegree = 0;


        private int hours = 0;
        private int departmentId = 0;

        [Key]
        public int ID
        {
            get { return id; }
            set { if (value > 0) id = value; }
        }
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }
        public int Degree { get; set; }

        public int? MinDegree { get; set; }
        public int Hours
        {
            get { return hours; }
            set { if (value > 0) hours = value; }
        }
        [ForeignKey("Department")]
        public int DepartmentId
        {
            get { return departmentId; }
            set { if (value > 0) departmentId = value; }
        }
        public ICollection<CourseResult> CoursesEnrolled { get; set; }
        public virtual Department? Department { get; set; }
    }
}
