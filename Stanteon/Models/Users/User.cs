namespace StanteonApi.Models.Users;

public abstract class User
{
    public long UserId { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}

