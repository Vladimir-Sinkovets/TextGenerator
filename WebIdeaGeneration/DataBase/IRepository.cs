using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebIdeaGeneration.DataBase
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
        void Add(TEntity entity);
        void Remove(TId id);
        void SaveChanges();
    }
}
