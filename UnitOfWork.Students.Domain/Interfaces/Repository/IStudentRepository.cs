using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Students.Domain.Entities;

namespace UnitOfWork.Students.Domain.Interfaces.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {

    }
}
