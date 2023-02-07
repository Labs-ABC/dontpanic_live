using DontPanicBabyApi.Models;

namespace DontPanicBabyApi.Interfaces
{
  public interface IEquationService
  {
    public EquationInput ValidateEquation(EquationInput equationInput);

  }
}
