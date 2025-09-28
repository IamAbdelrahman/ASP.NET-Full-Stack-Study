using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Demos.Models;

public partial class Student
{
    public int Id { get; set; }

    public string FullName { get; set; }
    [JsonIgnore]
    public int? Age { get; set; }
    public string? Address { get; set; } 
    [ForeignKey("DeptId")]
    public int? DepartmentId { get; set; }
    //[JsonIgnore]
    public virtual Department? Department { get; set; }
}

/// <summary>
/// We shouldnt use the [JsonIgnore] attribute on the Department navigation property
/// as it would prevent the serialization of the Department object 
/// when converting the Student object to JSON over the entire project, so we cannot
/// get the Department data when we query the Student data alawys.