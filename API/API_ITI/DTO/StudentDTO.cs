using System.Text.Json.Serialization;

namespace Demos.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        [JsonIgnore]
        public int Age { get; set; }
        public string? Address { get; set; }
        public string ? DepartmentName { get; set; } // For displaying the department name

    }
}
