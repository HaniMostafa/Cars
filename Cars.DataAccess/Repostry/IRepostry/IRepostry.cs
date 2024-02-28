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
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filters=null,string ? InCludeProprty=null);
        public T Get(Expression<Func<T,bool>> filters, string? InCludeProprty = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
