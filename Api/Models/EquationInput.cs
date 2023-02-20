using Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class EquationInput {

    [Required]
    [InputCustom]
    public char FirstInput  { get; set; }

    [Required]
    [InputCustom]
    public char SecondInput { get; set; }

    [Required]
    [InputCustom]
    public char ThirdInput  { get; set; }

    [Required]
    [InputCustom]
    public char FourthInput { get; set; }

    [Required]
    [InputCustom]
    public char FifthInput  { get; set; }

    [Required]
    [InputCustom]
    public char SixthInput  { get; set; }

    public override string ToString()
    {
      return $"{FirstInput}{SecondInput}{ThirdInput}{FourthInput}{FifthInput}{SixthInput}";
    }

    public static EquationInput ToEquationInput (string strEquation)
    {
        EquationInput eqInput = new EquationInput();

        eqInput.FirstInput = strEquation[0];
        eqInput.SecondInput = strEquation[1];
        eqInput.ThirdInput = strEquation[2];
        eqInput.FourthInput = strEquation[3];
        eqInput.FifthInput = strEquation[4];
        eqInput.SixthInput = strEquation[5];
        return eqInput;
    }
  }
}
