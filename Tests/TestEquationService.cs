using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Test
{
  public class Tests
  {
    public EquationInput correct, incorrect, invalid;
    public EquationService service;

    [SetUp]
    public void Setup()
    {
            service = new EquationService();
            correct = EquationInput.ToEquationInput(service.ChooseDailyEquation(service.mockEquation.ToArray()));

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

    //[Test]
    //public void Test_Validate_Input_Right_Number_In_Wrong_Position_Return_T()
    //{
    //  var result = service.ValidateInput('2', 1);
    //  Assert.That(result, Is.EqualTo('T'));
    //}

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

    //[Test]
    //public void Test_Validate_Equation_Right_Equation_Unexpected_Return_One_X_And_Five_C()
    //{
    //  var expected = new EquationInput
    //  {
    //    FirstInput = 'C',
    //    SecondInput = 'C',
    //    ThirdInput = 'C',
    //    FourthInput = 'C',
    //    FifthInput = 'X',
    //    SixthInput = 'C'
    //  };

    //  var result = service.ValidateEquation(incorrect);

    //  Assert.That(result.ToString(), Is.EqualTo(expected.ToString()));
    //}

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
      DateTime date = DateTime.Now;
      string[] equations = service.mockEquation.ToArray();
      string expected = equations[date.Year * date.DayOfYear % equations.Length];

      Assert.That(service.ChooseDailyEquation(equations), Is.EqualTo(expected));
    }

    [Test]
    public void Test_ChooseDailyEquation_Returns_Not_Null_Using_MockEquation()
    {
      string[] equations = service.mockEquation.ToArray();

      Assert.That(service.ChooseDailyEquation(equations), Is.Not.Null);
    }
  }
}