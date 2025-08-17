using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public static class FatherRepo
    {
        public static IEnumerable<Father> GetFathers()
        {
            return new List<Father>
            {
                new Father
                {
                    Id = 1,
                    Name = "John",
                    Kids = new List<Child>
                    {
                        new Child { Id = 1, ChildName = "Alice", FavoriteColor = "Blue", BestFriend = "Bob" },
                        new Child { Id = 2, ChildName = "Charlie", FavoriteColor = "Green", BestFriend = "David" }
                    }
                },
                new Father
                {
                    Id = 2,
                    Name = "Mike",
                    Kids = new List<Child>
                    {
                        new Child { Id = 3, ChildName = "Eve", FavoriteColor = "Red", BestFriend = "Frank" }
                    }
                }
            };
        }
    }
}
