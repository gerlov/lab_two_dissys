using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Admin;

public class UserVm
{
    [ScaffoldColumn(false)]
    public string Id { get; set; }

    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Email Address")]
    public string Email { get; set; }

    public static UserVm FromUser(WebApplication1.Areas.Identity.Data.WebApplication1User user)
    {
        return new UserVm
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}