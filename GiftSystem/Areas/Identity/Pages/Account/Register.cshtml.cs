using GiftSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GiftSystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<GiftSystemUser> _signInManager;
        private readonly UserManager<GiftSystemUser> _userManager;

        public RegisterModel(
            UserManager<GiftSystemUser> userManager,
            SignInManager<GiftSystemUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 3)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //returnUrl = "/Identity/Account/Login";
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // var isRoot = !_userManager.Users.Any();   TODO: add admin area; first seed the DB with the roles; inject roleManager

                var user = new GiftSystemUser { UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.PhoneNumber };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    //if (isRoot)
                    //{
                    //    await _userManager.AddToRoleAsync(user, "Admin");
                    //}
                    //else
                    //{
                    //    await _userManager.AddToRoleAsync(user, "User");
                    //}

                    return Redirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
