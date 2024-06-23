using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace ClassADO.Repository
{
    public interface IGeneralRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        T GetByName(Expression<Func<T, bool>> predicate);

    }
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GeneralRepository(CustomerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetByName(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        public int Insert(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbSet.Update(entity);
            return (_context.SaveChanges());
        }
    }
}
