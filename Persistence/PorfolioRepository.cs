using System.Collections.Generic;
using System.Threading.Tasks;
using investips.Models;
using Microsoft.EntityFrameworkCore;

namespace investips.Persistence
{
  public class PorfolioRepository : IPorfolioRepository
  {
    private readonly InvestipsDbContext context;
    public PorfolioRepository(InvestipsDbContext context)
    {
      this.context = context;

    }

    public async Task<List<Porfolio>> GetPorfolios()
    {
        return await context.Porfolios.Include(p => p.Securities).ToListAsync();
    }
    public async Task<Porfolio> GetPorfolio(int id, bool includeProps = true)
    {
        if(!includeProps) {
            return await context.Porfolios.FindAsync(id);
        }
      return await context.Porfolios
        .Include(p => p.Securities)
        .ThenInclude(ps => ps.Security)
        .SingleOrDefaultAsync(p => p.Id == id);
    }

    public void Add(Porfolio porfolio)
    {
        context.Porfolios.Add(porfolio);
    }

    public void Remove(Porfolio porfolio)
    {
        context.Remove(porfolio);
    }
  }
}