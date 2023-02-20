using Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class Equation
  {
    public int Id { get; set; }

    [Required]
    public string Value { get; set; }
  }
}
