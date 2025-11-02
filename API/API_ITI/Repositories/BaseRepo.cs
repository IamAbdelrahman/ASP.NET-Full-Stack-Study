using Demos.Models;
using Microsoft.EntityFrameworkCore;

namespace Demos.Repositories
{
    public class BaseRepo
    {
        protected readonly ITIContext _context;
        public BaseRepo(ITIContext context)
        {
            _context = context;
        }
    }
}
