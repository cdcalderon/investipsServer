using System.Threading.Tasks;

namespace investips.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly InvestipsDbContext context;
    public UnitOfWork(InvestipsDbContext context)
    {
      this.context = context;

    }
    public async Task CompleteAsync()
    {
      await context.SaveChangesAsync();
    }
  }
}