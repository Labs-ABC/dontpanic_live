using Api.Data;
using Api.Interfaces;
using Api.Models;
using System.Data;

namespace Api.Services
{
	public class EquationService : IEquationService
	{

		private readonly DbEquationContext _dbEquationContext;
		public string ExpectedEquation;
		private DateTime today;

		public EquationService(DbEquationContext dbEquationContext)
		{
			ExpectedEquation = "";
			_dbEquationContext = dbEquationContext;
			ChooseDailyEquation();
		}

		public async void ChooseDailyEquation()
		{
			today = DateTime.Today;
			var dbEquationReturn = await _dbEquationContext.Equations.FindAsync((today.Year * today.DayOfYear % 14) + 1);
			if (dbEquationReturn != null && dbEquationReturn.Value != null)
				ExpectedEquation = dbEquationReturn.Value;
		}

		public bool ValidateEquationResult(EquationInput eq)
		{
			try
			{
				DataTable dataTable = new DataTable();
				var result = dataTable.Compute(eq.ToString(), "");
				if (result.ToString() != "42")
					return false;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public char ValidateInput(char input, int index)
		{
			if (input == ExpectedEquation[index])
				return 'C';
			if (ExpectedEquation.IndexOf(input) != -1)
				return 'T';
			return 'X';
		}

		public EquationInput ValidateEquation(EquationInput equationInput)
		{
			if (today != DateTime.Today)
				ChooseDailyEquation();

			if (!ValidateEquationResult(equationInput))
				return equationInput;
			equationInput.FirstInput = ValidateInput(equationInput.FirstInput, 0);
			equationInput.SecondInput = ValidateInput(equationInput.SecondInput, 1);
			equationInput.ThirdInput = ValidateInput(equationInput.ThirdInput, 2);
			equationInput.FourthInput = ValidateInput(equationInput.FourthInput, 3);
			equationInput.FifthInput = ValidateInput(equationInput.FifthInput, 4);
			equationInput.SixthInput = ValidateInput(equationInput.SixthInput, 5);
			return equationInput;
		}
	}
}
