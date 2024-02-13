using System.ComponentModel.DataAnnotations.Schema;

namespace StantreonApi.Models.Users;

public class Creator : User
{
    public string pageName { get; set; }

    public string urlName { get; set; }
}
