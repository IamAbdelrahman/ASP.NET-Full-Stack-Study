using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public static class ChildRepo
    {
        public static IEnumerable<Child> GetChildren()
        {
            return new List<Child>
            {
                new Child { Id = 1, ChildName = "Zlice", FavoriteColor = "Blue", BestFriend = "Bob" },
                new Child { Id = 1, ChildName = "Ylice", FavoriteColor = "Green", BestFriend = "David" },
                new Child { Id = 3, ChildName = "Alice", FavoriteColor = "Red", BestFriend = "Frank" },
                new Child { Id = 1, ChildName = "Ali", FavoriteColor = "Blue", BestFriend = "Bob" },
                new Child { Id = 1, ChildName = "Yaya", FavoriteColor = "Green", BestFriend = "David" },
                new Child { Id = 3, ChildName = "Amir", FavoriteColor = "Red", BestFriend = "Frank" }
            };
        }
    }
}
