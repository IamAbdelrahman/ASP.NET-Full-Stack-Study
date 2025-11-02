using Demos.Models;
using Microsoft.EntityFrameworkCore;

namespace Demos.Repositories
{
    public class DepartmentRepo: GenericRepo<Department>
    {
        public DepartmentRepo(ITIContext context) : base(context) { }
    }
}
