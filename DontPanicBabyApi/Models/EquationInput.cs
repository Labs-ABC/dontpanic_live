﻿using System.ComponentModel.DataAnnotations;

namespace DontPanicBabyApi.Models
{
  public class EquationInput {

    [Required]
    public char FirstInput  { get; set; }

    [Required]
    public char SecondInput { get; set; }

    [Required]
    public char ThirdInput  { get; set; }

    [Required]
    public char FourthInput { get; set; }

    [Required]
    public char FifthInput  { get; set; }

    [Required]
    public char SixthInput  { get; set; }

    public override string ToString()
    {
      return $"{FirstInput}{SecondInput}{ThirdInput}{FourthInput}{FifthInput}{SixthInput}";
    }

    public EquationInput ToEquationInput (string strEquation)
        {
            FirstInput = strEquation[0];
            SecondInput = strEquation[1];
            ThirdInput = strEquation[2];
            FourthInput = strEquation[3];
            FifthInput = strEquation[4];
            SixthInput = strEquation[5];
            return this;
        }
  }
}