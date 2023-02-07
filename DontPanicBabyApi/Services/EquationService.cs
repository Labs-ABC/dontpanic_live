using DontPanicBabyApi.Interfaces;
using DontPanicBabyApi.Models;

namespace DontPanicBabyApi.Services
{
  public class EquationService : IEquationService
  {
    private readonly string ExpectedEquation;
    
    public EquationService()
    {
        ExpectedEquation = "21*2-0";
    }

    public EquationInput ValidateEquation(EquationInput equationInput) {
      string equation = equationInput.ToString();
      if (equation == null)
        return equationInput;
      for (int i = 0; i < 6; i++) {
        int foundIndex = equation.IndexOf(ExpectedEquation[i]);
        if (foundIndex == -1) {
          equation.Replace(equation[i], 'X');
        } else if (foundIndex == i) {
          equation.Replace(equation[i], 'C');
        } else {
          equation.Replace(equation[i], 'T');
        }
      }
      return equationInput.ToEquationInput(equation);
    }
  }
}
