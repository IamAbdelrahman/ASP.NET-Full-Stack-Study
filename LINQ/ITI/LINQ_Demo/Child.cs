using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    public class Child
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string FavoriteColor { get; set; }
        public string BestFriend { get; set; }
        public override string ToString()
        {
            return $"{Id} - {ChildName} - {FavoriteColor} - {BestFriend}";
        }
    }
}
