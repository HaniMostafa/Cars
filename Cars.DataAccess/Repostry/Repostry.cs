using Cars.DataAccess.Data;
using Cars.DataAccess.Repostry.IRepostry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry
{
    public class Repostry<T> : IRepostry<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repostry(ApplicationDbContext db)
        {
            _db = db;
            _db.Cars.Include(a => a.KindOfCar);
            this._dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filters, string? InCludeProprty = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filters);
            if (!string.IsNullOrEmpty(InCludeProprty))
            {
                foreach (var includePror in InCludeProprty.Split(new char[] { '-' }
                , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePror);

                }

            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filters=null, string? InCludeProprty = null)
        {
            IQueryable<T> query = _dbSet;
            if (filters!=null)
            {
                query.Where(filters);
            }
            if (!string.IsNullOrEmpty(InCludeProprty))
            {
                foreach (var includePror in InCludeProprty.Split(new char[] { '-' }
                , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePror);

                }

            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
