using System.ComponentModel.DataAnnotations;

namespace StantreonApi.Dtos.Users;

public abstract class UserDto
{
    public long UserId { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
