using System;
using System.Threading.Tasks;

namespace investips.Persistence
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}