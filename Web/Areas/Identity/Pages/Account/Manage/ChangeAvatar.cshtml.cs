using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Web.Areas.Identity.Data;

namespace Web.Areas.Identity.Pages.Account.Manage
{
    public class ChangeAvatarModel : PageModel
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;
        private readonly IUserService userService;

        public ChangeAvatarModel(
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager,
            IUserService userService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.userService = userService;
        }

        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; } = string.Empty;
        public class InputModel
        {
            public IFormFile? ImageFile { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ImagePath = user.AvataraPath;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var res = await userService.ChangeUserAvatarImage(user, Input.ImageFile);
            if (res)
            {
                return RedirectToPage();
            }

            return Page();
        }
    }
}
