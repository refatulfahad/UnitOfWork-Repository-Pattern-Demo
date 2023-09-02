using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Students.Data.EFCore.Context;
using UnitOfWork.Students.Domain.Interfaces.Repository;

namespace UnitOfWork.Students.Data.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;


        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
