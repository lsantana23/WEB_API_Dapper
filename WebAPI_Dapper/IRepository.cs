using System.Collections.Generic;

namespace WebAPI_Dapper
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Add(T entity);
        bool Delete(int id);
        void Update(T entity);
    }
}