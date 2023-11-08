using System.ComponentModel.DataAnnotations;

namespace liveraryIdentity.Models;

public class EditViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public required string Id { get; set; }
    

}
