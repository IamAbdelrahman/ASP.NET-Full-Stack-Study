using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Lec2.Models
{
    public class Employee
    {
        private int id = 0;
        private string name;
        private string? email;
        private string departmentName;
        private string? address;
        private int departmentID;
        private string imageUrl;
        private decimal salary = 0.0m;

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
        public string? Email
        {
            get { return email; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains("@") && value.Contains("."))
                {
                    email = value;

                }
            }
        }
        public string DepartmentName
        {
            get { return departmentName; }
            set { if (!string.IsNullOrEmpty(value)) departmentName = value; }
        }
        public string? Address
        {
            get { return address; }
            set { if (!string.IsNullOrEmpty(value)) address = value; }
        }
        [ForeignKey("Department")]
        public int DepartmentID
        {
            get { return departmentID; }
            set { if (value > 0) departmentID = value; }
        }
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (!string.IsNullOrEmpty(value) && (value.EndsWith(".jpg") || value.EndsWith(".png")))
                {
                    imageUrl = value;
                }
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set { if (value >= 0) salary = value; }
        }
        public virtual Department? Department { get; set; }
    }
}
