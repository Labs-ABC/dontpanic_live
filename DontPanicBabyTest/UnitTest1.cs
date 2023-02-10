using DontPanicBabyApi.Models;
using DontPanicBabyApi.Services;

namespace DontPanicBabyTest
{
  public class Tests
  {
        public EquationInput correct, incorrect, invalid;
        public EquationService service;

    [SetUp]
    public void Setup()
    {
            correct = new EquationInput
            {
                FirstInput = '2',
                SecondInput = '1',
                ThirdInput = '*',
                FourthInput = '2',
                FifthInput = '-',
                SixthInput = '0'
            };

            incorrect = new EquationInput
            {
                FirstInput = '2',
                SecondInput = '1',
                ThirdInput = '*',
                FourthInput = '2',
                FifthInput = '+',
                SixthInput = '0'
            };

            invalid = new EquationInput
            {
                FirstInput = '2',
                SecondInput = '1',
                ThirdInput = '+',
                FourthInput = '2',
                FifthInput = '-',
                SixthInput = '0'
            };

            service = new EquationService();
        }

    [Test]
    public void Test_Validate_Equation_Result_Return_True()
    {
      var result = service.ValidateEquationResult(correct);
      Assert.That(result, Is.True);
    }
  }
}