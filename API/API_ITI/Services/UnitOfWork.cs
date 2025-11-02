using Demos.Models;
using Demos.Repositories;
namespace Demos.Services
{
    public interface IUnitOfWork
    {
        StudentsRepo Students { get; }
        DepartmentRepo Departments { get; }
        ProductsRepo Products { get; }
        Task<int> CompleteAsync();
        void Dispose();
    }
    public class UnitOfWork: BaseRepo, IUnitOfWork
    {
        public UnitOfWork(ITIContext db): base(db)
        {
            Students = new StudentsRepo(db);
            Departments = new DepartmentRepo(db);
            Products = new ProductsRepo(db);
        }
        public StudentsRepo Students { get; private set; }
        public DepartmentRepo Departments { get; private set; }
        public ProductsRepo Products { get; private set; }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
   
}
