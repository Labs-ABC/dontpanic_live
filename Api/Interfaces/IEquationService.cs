using Api.Models;

namespace Api.Interfaces {
  public interface IEquationService {
    public EquationInput ValidateEquation(EquationInput equationInput);
    public bool ValidateEquationResult(EquationInput eq);
    public char ValidateInput(char input, int index);
    public string ChooseDailyEquation(string[] equations);
  }
}
