using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Students.Domain.Interfaces.Repository;

namespace UnitOfWork.Students.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        int Save();
    }
}
