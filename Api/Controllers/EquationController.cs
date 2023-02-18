using Api.Interfaces;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquationController : ControllerBase {

    private readonly IEquationService _equationService;

    public EquationController(IEquationService equationService) {
      _equationService = equationService;
    }

    [HttpPatch(Name = "EquationRoute")]
    public ActionResult<EquationInput> EquationRoute(EquationInput input) {
      _equationService.ValidateEquation(input);
      return input;
    }

    [HttpGet]
    public async Task<ActionResult<List<EquationInput>>> GetAllAsync()
    {
      return await _equationService.GetAllAsync();
    }
  }
}
