using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StantreonApi.Models.Users;

[Index(nameof(UrlHandle), IsUnique = true)]
public class Creator : User
{
    [Required]
    public string PageName { get; set; }

    [Required]
    public string UrlHandle { get; set; }

    public ICollection<Member> Members { get; set; }
}
