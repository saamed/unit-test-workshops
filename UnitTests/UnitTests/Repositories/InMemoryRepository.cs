using System.Collections.Generic;
using System.Linq;
using Workshops.AppLogic.Entities;

namespace Workshops.AppLogic.Repositories
{
  public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
  {
    protected static IList<T> Repository = new List<T>();

    public long Add(T entity)
    {
      if (entity.Id <= 0)
        entity.Id = Repository.Count + 1;

      Repository.Add(entity);

      return entity.Id;
    }

    public void Delete(long id)
    {
      var entity = Repository.FirstOrDefault(x => x.Id == id);

      if (entity != null)
        Repository.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
      return Repository.ToArray();
    }

    public T AddOrUpdate(T entity)
    {
      var savedEntity = Repository.FirstOrDefault(x => x.Id == entity.Id);

      if (savedEntity != null)
        Delete(savedEntity.Id);

      Repository.Add(entity);

      return entity;
    }
  }
}
