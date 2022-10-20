using Web.Areas.Identity.Data;

namespace Web.Areas.Identity
{
    public interface IUserService
    {
        Task<WebUser> GetUserAsync(string id);
        Task<bool> ChangeUserAvatarImage(WebUser user, IFormFile file);
    }
}
