using Demos.Models;
using Microsoft.EntityFrameworkCore;

namespace Demos.Repositories
{
    public interface IStudentRepo: IGenericRepo<Student>
    {
        public Task<Student?> GetStudentByName(string name);
    }
    public class StudentsRepo: GenericRepo<Student>, IStudentRepo
    {
        public StudentsRepo(ITIContext context) : base(context) { }
        public async Task<Student?> GetStudentByName (string name)
        {
            var students = await GetAllAsync();
            return students.FirstOrDefault(s => s.FullName == name);
        }
    }
}
