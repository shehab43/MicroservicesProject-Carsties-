using IdentityModel;
using IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace IdentityService.Pages.Account.Register
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class Index : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Index(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [BindProperty]
        public RegisterViewModel Input { get; set; }

        [BindProperty]
        public bool RegisterSuccess { get; set; }


        public IActionResult OnGet(string returnurl)
        {
            Input = new RegisterViewModel
            {

                ReturnUrl = returnurl,
            };

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Input.Button != "register")
            {
                return Redirect("~");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    EmailConfirmed = true // Email confirmation recommended
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Add claims
                    await _userManager.AddClaimsAsync(user, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, Input.FullName)
                        });
                    

                    RegisterSuccess = true;

                    // Redirect to login or confirmation page
                    //return RedirectToPage("../Account/Login");
                }

                // Handle errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
