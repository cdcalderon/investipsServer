using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using investips.Controllers.Resources;
using investips.Models;
using investips.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace investips.Controllers
{
  public class PorfoliosController : Controller
  {
    private readonly InvestipsDbContext context;
    public PorfoliosController(InvestipsDbContext context, IMapper mapper)
    {
      this.context = context;
    }

    [HttpGet("/api/porfolios")]
    public async Task<IEnumerable<PorfolioResource>> GetPorfolios()
    {
        var porfolios =  await context.Porfolios.ToListAsync();
        return Mapper.Map<List<Porfolio>, List<PorfolioResource>>(porfolios);
    }
  }
}