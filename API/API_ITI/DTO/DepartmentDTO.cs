namespace Demos.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int StudentCount { get; set; }
        public List<string> StudentNames { get; set; } = new List<string>();
    }
}
