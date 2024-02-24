using UnitOfWork.Students.Data.EFCore.Context;
using UnitOfWork.Students.Data.EFCore.Repositories;
using UnitOfWork.Students.Domain.Interfaces;
using UnitOfWork.Students.Domain.Interfaces.Repository;

namespace UnitOfWork.Students.Data.EFCore.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        private IStudentRepository _studentRepository;

        public IStudentRepository StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
