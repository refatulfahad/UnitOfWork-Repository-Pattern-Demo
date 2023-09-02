using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StudentRepository = new StudentRepository(_context);
        }

        public IStudentRepository StudentRepository { get; private set; }

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
