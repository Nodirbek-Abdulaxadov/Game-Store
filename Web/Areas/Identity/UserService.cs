using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Areas.Identity.Data;
using Web.Data;
using Web.Services;

namespace Web.Areas.Identity
{
    public class UserService : UserManager<WebUser>, IUserService
    {
        private readonly IUserStore<WebUser> store;
        private readonly IFileService fileService;
        private readonly WebContext webContext;

        public UserService( IUserStore<WebUser> store, 
                            IOptions<IdentityOptions> optionsAccessor, 
                            IPasswordHasher<WebUser> passwordHasher, 
                            IEnumerable<IUserValidator<WebUser>> userValidators, 
                            IEnumerable<IPasswordValidator<WebUser>> passwordValidators, 
                            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
                            IServiceProvider services, ILogger<UserManager<WebUser>> logger,
                            IFileService fileService,
                            WebContext webContext) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.store = store;
            this.fileService = fileService;
            this.webContext = webContext;
        }

        public Task<bool> ChangeUserAvatarImage(WebUser user, IFormFile file)
        {
            try
            {
                var res = webContext.Users.FirstOrDefault(i => i.Id == user.Id);
                if (!string.IsNullOrEmpty(res.AvataraPath))
                {
                    fileService.DeleteImage(res.AvataraPath);
                }
                res.AvataraPath = fileService.UploadImage(file);
                webContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<WebUser> GetUserAsync(string id)
        {
            var user = await webContext.Users.FirstOrDefaultAsync(i => i.Id == id);

            return user;
        }
    }
}
