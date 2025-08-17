using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public class Father
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child> Kids { get; set; } = new List<Child>();
        public override string ToString()
        {
            return $"{Id} - {Name} - Children: {string.Join(", ", Kids.Select(c => c.ChildName))}";
        }
    }
}
