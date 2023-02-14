using DontPanicBabyApi.Interfaces;
using DontPanicBabyApi.Models;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DontPanicBabyApi.Services
{
  public class EquationService : IEquationService
  {
    private readonly string ExpectedEquation;

    public EquationService() {
      ExpectedEquation = "21*2-0";
    }

    public bool ValidateEquationResult(EquationInput eq) {
      try {
        DataTable dataTable = new DataTable();
        var result = dataTable.Compute(eq.ToString(), "");
        if (result.ToString() != "42")
          return false;
        return true;
      } catch {
        return false;
      }


    }

    public char ValidateInput(char input, int index) {
      if (input == ExpectedEquation[index])
        return 'C';
      if (ExpectedEquation.IndexOf(input) != -1)
        return 'T';
      return 'X';
    }

    public EquationInput ValidateEquation(EquationInput equationInput) {
      if (!ValidateEquationResult(equationInput))
        return equationInput;

      equationInput.FirstInput = ValidateInput(equationInput.FirstInput, 0);
      equationInput.SecondInput = ValidateInput(equationInput.SecondInput, 1);
      equationInput.ThirdInput = ValidateInput(equationInput.ThirdInput, 2);
      equationInput.FourthInput = ValidateInput(equationInput.FourthInput,3);
      equationInput.FifthInput = ValidateInput(equationInput.FifthInput, 4);
      equationInput.SixthInput = ValidateInput(equationInput.SixthInput, 5);

      return equationInput;
    }
  }
}
