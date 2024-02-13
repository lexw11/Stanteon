using System.ComponentModel.DataAnnotations.Schema;

namespace StanteonApi.Models.Users;

public class Member : User
{
    public string DisplayName { get; set; }
}
