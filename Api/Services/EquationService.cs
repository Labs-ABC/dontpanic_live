using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Api.Services
{
  public class EquationService : IEquationService
  {

    private readonly DbEquationContext _dbEquationContext;
    private readonly string ExpectedEquation;
    public readonly MockEquation mockEquation;

    public EquationService(DbEquationContext dbEquationContext) {
      
      _dbEquationContext = dbEquationContext;
      
      //Aqui vira a solicitação ao banco para solicitar as equações
      mockEquation = new MockEquation();
      //db get equations
      //var dbEquations = this.GetAllEquations();
      //ExpectedEquation = ChooseDailyEquation(dbEquations.Select(dbEquation => dbEquation.Value).ToArray());

      ExpectedEquation = ChooseDailyEquation(mockEquation.ToArray());

    }

    public string ChooseDailyEquation(string[] equations) {
      DateTime date = DateTime.Now;

      return equations[date.Year * date.DayOfYear % equations.Length];
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

    public List<Equation> GetAllEquations()
    {
      return _dbEquationContext.Equations.ToList();
    }
  }
}
