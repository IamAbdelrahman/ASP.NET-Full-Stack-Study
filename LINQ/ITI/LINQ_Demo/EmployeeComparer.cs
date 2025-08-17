using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    internal class EmployeeComparer: IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            // Compare by Name first
            int nameComparison = string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            if (nameComparison != 0) return nameComparison;
            // If names are equal, compare by Salary
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
