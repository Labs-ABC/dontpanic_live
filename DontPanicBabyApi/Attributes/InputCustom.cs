using DontPanicBabyApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DontPanicBabyApi.Attributes {
  public class InputCustomAttribute : ValidationAttribute {

    public string GetErrorMessage() => "Invalid characters!";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
      
      var inputs = ( EquationInput ) validationContext.ObjectInstance;

      string pattern = "^[0-9\\+\\/\\*\\-]+$";

      bool isMatch = Regex.IsMatch(inputs.ToString(), pattern);

      if (isMatch == false)
        return new ValidationResult(GetErrorMessage());

      return ValidationResult.Success;
    }
  }
}
