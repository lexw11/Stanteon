using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StantreonApi.Models.Users;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Phone), IsUnique = true)]
public abstract class User
{
    public long UserId { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Phone]
    [Required]
    public string Phone { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}

