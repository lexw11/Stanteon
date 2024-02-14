using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StantreonApi.Models.Users;

[Index(nameof(Email), IsUnique = true)]
public abstract class User
{
    public long UserId { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}

