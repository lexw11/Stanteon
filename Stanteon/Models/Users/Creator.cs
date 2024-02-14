using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StantreonApi.Models.Users;

[Index(nameof(UrlHandle), IsUnique = true)]
public class Creator : User
{
    public string PageName { get; set; }

    public string UrlHandle { get; set; }
}
