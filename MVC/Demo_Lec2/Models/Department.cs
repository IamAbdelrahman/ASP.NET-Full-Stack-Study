using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo_Lec2.Models
{
    public class Department
    {
        private int id = 0;
        private string name = "";
        private string managerName = "";
        private List<Employee> employees = new List<Employee>();

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
        public virtual List<Employee> Employees 
        {
            get { return employees; }
            set 
            {
                if (value.Count > 0)
                {
                    employees = value ?? new List<Employee>();
                }
                
            } 
        }
    }
}
