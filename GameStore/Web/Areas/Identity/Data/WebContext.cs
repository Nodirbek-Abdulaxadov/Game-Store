using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Identity.Data;

namespace Web.Data;

public class WebContext : IdentityDbContext<WebUser>
{
    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
