using System.Collections.Generic;
using Workshops.AppLogic.Entities;

namespace Workshops.Applogic
{
  public class SearchResult<T> where T : Entity
  {
    public IEnumerable<T> Data { get; set; }
  }
}