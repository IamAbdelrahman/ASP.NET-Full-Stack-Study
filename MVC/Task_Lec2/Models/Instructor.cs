using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Lec2.Models
{
    public class Instructor
    {
        private int id = 0;
        private string name = "";
        private string? imageUrl;
        private string? address;
        private int departmentId = 0;
        private int courseId = 0;

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
        public string? ImageUrl
        {
            get { return imageUrl; }
            set { if (!string.IsNullOrEmpty(value)) imageUrl = value; }
        }
        public string? Address
        {
            get { return address; }
            set { if (!string.IsNullOrEmpty(value)) address = value; }
        }

        [ForeignKey("Department")]
        public int DepartmentId
        {
            get { return departmentId; }
            set { if (value > 0) departmentId = value; }
        }
        [ForeignKey("Course")]
        public int CourseId
        {
            get { return courseId; }
            set { if (value > 0) courseId = value; }
        }
        public virtual Department? Department { get; set; }
        public virtual Course? Course { get; set; }
    }
}
