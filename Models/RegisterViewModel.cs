using System.ComponentModel.DataAnnotations;

namespace liveraryIdentity.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Password and Confirmation password do not match")]
    public required string ConfirmPassword { get; set; }
}
