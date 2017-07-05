using System.Threading.Tasks;
using investips.Models;
using Microsoft.EntityFrameworkCore;

namespace investips.Persistence
{
  public class PorfolioRepository
  {
    private readonly InvestipsDbContext context;
    public PorfolioRepository(InvestipsDbContext context)
    {
      this.context = context;

    }
    public async Task<Porfolio> GetPorfolio(int id)
    {
      return await context.Porfolios
        .Include(p => p.Securities)
        .ThenInclude(ps => ps.Security)
        .SingleOrDefaultAsync(p => p.Id == id);
    }
  }
}