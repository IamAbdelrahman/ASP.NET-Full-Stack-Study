using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public class ChildComparer: IComparer<Child>
    {
        public int Compare (Child? x, Child? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            // Compare by Name first
            int result = String.Compare(x.ChildName, y.ChildName, StringComparison.OrdinalIgnoreCase);
            if (result != 0) return result;
            return x.Id.CompareTo(y.Id); // If names are equal, compare by Id
        }

    }
}
