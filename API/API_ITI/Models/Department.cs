using System;
using System.Collections.Generic;

namespace Demos.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Location { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
