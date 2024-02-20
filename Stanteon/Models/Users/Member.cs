namespace StantreonApi.Models.Users;

public class Member : User
{
    public string DisplayName { get; set; }

    public ICollection<Creator> Creators { get; set; }
}