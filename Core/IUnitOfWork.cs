using System;
using System.Threading.Tasks;

namespace investips.Core
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}