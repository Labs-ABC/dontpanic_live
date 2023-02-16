using Api.Models;

namespace Api.Interfaces
{
  public interface IEquationService
  {
    public EquationInput ValidateEquation(EquationInput equationInput);

  }
}
