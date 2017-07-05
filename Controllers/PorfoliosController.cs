using System;
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
  [Route("/api/porfolios")]
  public class PorfoliosController : Controller
  {
    private readonly InvestipsDbContext context;
    private readonly IMapper mapper;
    private readonly IPorfolioRepository repository;
    public PorfoliosController(InvestipsDbContext context, IMapper mapper, IPorfolioRepository repository)
    {
      this.repository = repository;
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorfolio(int id)
    {
      var porfolio = await repository.GetPorfolio(id);

      if (porfolio == null)
      {
        return NotFound();
      }

      var porfolioResource = mapper.Map<Porfolio, PorfolioResource>(porfolio);
      return Ok(porfolioResource);
    }

    [HttpGet]
    public async Task<IEnumerable<PorfolioResource>> GetPorfolios()
    {
      var porfolios = await context.Porfolios.Include(p => p.Securities).ToListAsync();
      return Mapper.Map<List<Porfolio>, List<PorfolioResource>>(porfolios);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePorfolio([FromBody] SavePorfolioResource porfolioResource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var porfolio = mapper.Map<SavePorfolioResource, Porfolio>(porfolioResource);
      porfolio.LastUpdate = DateTime.Now;

      context.Porfolios.Add(porfolio);
      await context.SaveChangesAsync();

      porfolio = await repository.GetPorfolio(porfolio.Id);

      var result = mapper.Map<Porfolio, PorfolioResource>(porfolio);
      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePorfolio(int id, [FromBody] SavePorfolioResource porfolioResource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var porfolio = await repository.GetPorfolio(id);

      if (porfolio == null)
      {
        return NotFound();
      }

      mapper.Map<SavePorfolioResource, Porfolio>(porfolioResource, porfolio);
      porfolio.LastUpdate = DateTime.Now;

      await context.SaveChangesAsync();

      var result = mapper.Map<Porfolio, PorfolioResource>(porfolio);
      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
      var porfolio = await context.Porfolios.FindAsync(id);

      if (porfolio == null)
      {
        return NotFound();
      }
      context.Remove(porfolio);
      await context.SaveChangesAsync();

      return Ok(id);
    }
  }
}