using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task_Lec2.Models
{
    public class CourseResult
    {
        private int id = 0;
        private int degree = 0;
        private int courseId = 0;
        private int traineeId = 0;
        [Key]
        public int ID
        {
            get { return id; }
            set { if (value > 0) id = value; }
        }
        public int Degree
        {
            get { return degree; }
            set 
            {
                if (Enum.IsDefined(typeof(DegreeState), value))
                    degree = value;
            }
        }
        [ForeignKey("Courses")]
        public int CourseId
        {
            get { return courseId; }
            set { if (value > 0) courseId = value; }
        }
        [ForeignKey("Trainees")]
        public int TraineeId
        {
            get { return traineeId; }
            set { if (value > 0) traineeId = value; }
        }
        public Course Courses { get; set; }

        public Trainee Trainees { get; set; }
    }
}
