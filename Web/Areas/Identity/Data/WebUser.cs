using Microsoft.AspNetCore.Identity;

namespace Web.Areas.Identity.Data;

public class WebUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? AvataraPath { get; set; }
}

