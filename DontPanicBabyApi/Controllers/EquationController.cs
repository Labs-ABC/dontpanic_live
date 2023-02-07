using DontPanicBabyApi.Models;
using DontPanicBabyApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DontPanicBabyApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquationController : ControllerBase
  {
    [HttpPatch(Name = "EquationRoute")]
    public ActionResult<EquationInput> EquationRoute(EquationInput input) {
      input.FirstInput = 'X';
      var equationService = new EquationService();
      equationService.ValidateEquation(input);
      return input;
    }
  }
}
