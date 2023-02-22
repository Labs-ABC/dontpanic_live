using Api.Models;
using Api.Services;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Test
{
  public class Tests
  {
    public EquationInput correct, incorrect, invalid;
    public EquationService service;
    public DbEquationContext equationContext;

    [SetUp]
		public void Setup()
    {

      var equationsList = new List<Equation>()
      {
				new Equation { Value = "4*11-2" },
			  new Equation { Value = "50-8*2" },
			  new Equation { Value = "182-63" },
			  new Equation { Value = "21*2-0" },
			  new Equation { Value = "10*4+2" },
			  new Equation { Value = "000042" },
			  new Equation { Value = "42*1-0" },
			  new Equation { Value = "21+021" },
			  new Equation { Value = "066-24" },
			  new Equation { Value = "33+9+0" },
			  new Equation { Value = "14*3+0" },
			  new Equation { Value = "7*6-00" },
			  new Equation { Value = "42+0+0" },
			  new Equation { Value = "21*2+0" },
		};

    var dbContextOptions = new DbContextOptionsBuilder<DbEquationContext>().UseInMemoryDatabase(databaseName: "Equations").Options;

		equationContext = new DbEquationContext(dbContextOptions);
		equationContext.Database.EnsureCreated();
		equationContext.Equations.AddRange(equationsList);
		equationContext.SaveChanges();

		service = new EquationService(equationContext);
    Console.WriteLine($"teste zika{service.ExpectedEquation}");
    correct = EquationInput.ToEquationInput(service.ExpectedEquation);

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
    }

    [Test]
    public void Test_Validate_Equation_Result_Correct_Return_True()
    {
      var result = service.ValidateEquationResult(correct);
      Assert.That(result, Is.True);
    }


    [Test]
    public void Test_Validate_Equation_Result_Invalid_Return_False()
    {
      var result = service.ValidateEquationResult(invalid);
      Assert.That(result, Is.False);
    }

    [Test]
    public void Test_Validate_Equation_Result_Incorrect_Return_True()
    {
      var result = service.ValidateEquationResult(incorrect);
      Assert.That(result, Is.True);
    }

    [Test]
    public void Test_Validate_Equation_Result_Two_Operator_Return_False()
    {
      var twoOperators = new EquationInput
      {
        FirstInput = '2',
        SecondInput = '1',
        ThirdInput = '*',
        FourthInput = '*',
        FifthInput = '1',
        SixthInput = '0'
      };

      var result = service.ValidateEquationResult(twoOperators);
      Assert.That(result, Is.False);
    }

    [Test]
    public void Test_Validate_Equation_Result_Operator_At_Begin_Return_False()
    {
      var operatorsAtBegin = new EquationInput
      {
        FirstInput = '-',
        SecondInput = '1',
        ThirdInput = '*',
        FourthInput = '2',
        FifthInput = '1',
        SixthInput = '0'
      };

      var result = service.ValidateEquationResult(operatorsAtBegin);
      Assert.That(result, Is.False);
    }

    [Test]
    public void Test_Validate_Equation_Result_Operator_At_End_Return_False()
    {
      var operatorsAtEnd = new EquationInput
      {
        FirstInput = '2',
        SecondInput = '1',
        ThirdInput = '*',
        FourthInput = '2',
        FifthInput = '1',
        SixthInput = '/'
      };

      var result = service.ValidateEquationResult(operatorsAtEnd);
      Assert.That(result, Is.False);
    }

    [Test]
    public void Test_Validate_Input_Right_Number_In_Right_Position_Return_C()
    {
      var result = service.ValidateInput(correct.FirstInput, 0);
      Assert.That(result, Is.EqualTo('C'));
    }

    [Test]
    public void Test_Validate_Input_Right_Number_In_Wrong_Position_Return_T()
    {
      var result = service.ValidateInput('2', 1);
      Assert.That(result, Is.EqualTo('T'));
    }

    [Test]
    public void Test_Validate_Input_Wrong_Number_Return_X()
    {
      var result = service.ValidateInput('X', 1);
      Assert.That(result, Is.EqualTo('X'));
    }

    [Test]
    public void Test_Validate_Equation_Right_Equation_And_Expected_Return_All_C()
    {
      var expected = new EquationInput
      {
        FirstInput = 'C',
        SecondInput = 'C',
        ThirdInput = 'C',
        FourthInput = 'C',
        FifthInput = 'C',
        SixthInput = 'C'
      };
      
      var result = service.ValidateEquation(correct);

      Assert.That(result.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Test_Validate_Equation_Invalid_Equation_Unexpected_Return_All_X()
    {
      var expected = new EquationInput
      {
        FirstInput = '2',
        SecondInput = '1',
        ThirdInput = '+',
        FourthInput = '2',
        FifthInput = '-',
        SixthInput = '0'
      };

      var result = service.ValidateEquation(invalid);

      Assert.That(result.ToString(), Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Test_ChooseDailyEquation_Returns_Correct_Equation_Using_MockEquation()
    {
      DateTime date = DateTime.Today;

			Equation[] equations = equationContext.Equations.ToArray();
      string expected = equations[date.Year * date.DayOfYear % equations.Length].Value;

      service.ChooseDailyEquation();
      Assert.That(service.ExpectedEquation, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ChooseDailyEquation_Returns_Not_Null_Using_MockEquation()
    {
      service.ChooseDailyEquation();

			Assert.That(service.ExpectedEquation, Is.Not.Null);
    }
  }
}