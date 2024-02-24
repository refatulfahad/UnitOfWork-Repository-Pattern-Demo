using UnitOfWork.Students.Domain.Interfaces.Repository;

namespace UnitOfWork.Students.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        int Save();
    }
}
