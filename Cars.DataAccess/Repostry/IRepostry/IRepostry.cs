using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry.IRepostry
{
    public interface IRepostry<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T,bool>> filters);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
