using UnitOfWork.Students.Data.EFCore.Context;
using UnitOfWork.Students.Domain.Entities;
using UnitOfWork.Students.Domain.Interfaces.Repository;

namespace UnitOfWork.Students.Data.EFCore.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
