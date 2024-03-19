using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.Models;

[Table("Employee", Schema ="dbo")]
public class Employee
{
    public int EmployeeId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [EmailAddress]
    [NotMapped]
    [Compare("Email",
        ErrorMessage = "Email and Confirm Email must match")]
    public string ConfirmEmail { get; set; }
    [Required]
    public DateTime DateOfBrith { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public string PhotoPath { get; set; }
}
public enum Gender
{
    Male,
    Female,
    Other
}
