using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace projSchoolService.Data.Repositories.AbstractRepos
{
    public interface IRepository<T>
    {
        IEnumerable<T>? GetAll();

        T? Get(int id);
        
        IEnumerable<T>? Get(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();

    }
}
