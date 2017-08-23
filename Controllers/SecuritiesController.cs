using System.Threading.Tasks;
using AutoMapper;
using AutoMapper;
using investips.Controllers.Resources;
using investips.Core;
using investips.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace investips.Controllers {
    [Route("/api/securities")]
  public class SecuritiesController : Controller {
    private readonly IMapper mapper;
    private readonly IUnitOfWork uow;
    private readonly ISecurityRepository securityRepository;

    public SecuritiesController (IMapper mapper, IUnitOfWork uow, ISecurityRepository securityRepository) {
      this.securityRepository = securityRepository;
      this.uow = uow;
      this.mapper = mapper;

    }

[HttpGet("{id}")]
    public async Task<IActionResult> GetSecurity(int id)
    {
      var security = await securityRepository.GetSecurity(id);

      if (security == null)
      {
        return NotFound();
      }

      var porfolioResource = mapper.Map<Security, SecurityResource>(security);
      return Ok(security);
    }
    

    [HttpPost]
    public async Task<IActionResult> CreateSecurity ([FromBody] SecurityResource securityResource) {
      if (!ModelState.IsValid) {
        return BadRequest (ModelState);
      }

      var security = Mapper.Map<SecurityResource, Security> (securityResource);
      securityRepository.Add (security);
      await uow.CompleteAsync ();

      security = await securityRepository.GetSecurity (security.Id);
      var result = mapper.Map<Security, SecurityResource> (security);
      return Ok (result);
    }
  }
}