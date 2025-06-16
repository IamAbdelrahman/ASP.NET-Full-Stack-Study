using System.ComponentModel.DataAnnotations;

namespace Task_Lec2.Models
{
    public class Department
    {
        private int id = 0;
        private string name = "";
        private string managerName = "";

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
        public string ManagerName
        {
            get { return managerName; }
            set { if (!string.IsNullOrEmpty(value)) managerName = value; }
        }
    }
}