using System.Collections.Generic;
using Workshops.AppLogic.Entities;

namespace Workshops.AppLogic.Repositories
{
  public interface IRepository<T> where T : Entity
  {
    IEnumerable<T> GetAll();
    long Add(T entity);
    T Update(T entity);
    void Delete(long id);
  }
}