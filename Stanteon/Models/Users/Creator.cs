using System.ComponentModel.DataAnnotations.Schema;

namespace StantreonApi.Models.Users;

public class Creator : User
{
    public string PageName { get; set; }

    public string UrlHandle { get; set; }
}
