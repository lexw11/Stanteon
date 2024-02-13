using System.ComponentModel.DataAnnotations.Schema;

namespace StanteonApi.Models.Users;

public class Creator : User
{
    public string pageName { get; set; }

    public string urlName { get; set; }
}
