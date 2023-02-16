using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquationController : ControllerBase
  {
    [HttpPatch(Name = "EquationRoute")]
    public ActionResult<EquationInput> EquationRoute(EquationInput input) {
      var equationService = new EquationService();
      equationService.ValidateEquation(input);
      return input;
    }
  }
}
