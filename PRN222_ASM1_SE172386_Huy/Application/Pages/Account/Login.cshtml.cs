using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Application.Services;

namespace Application.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserAccountService _userAccountService;

        public LoginModel() => _userAccountService ??= new UserAccountService();

        [BindProperty]
        public string UserName { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userAccount = await _userAccountService.GetUserAccount(UserName, Password);

            if (userAccount != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.Role, userAccount.RoleId.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                Response.Cookies.Append("UserName", userAccount.UserName);
                return RedirectToPage("/Main/Index");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                TempData["Message"] = "Login fail, please check your account";
            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Page();
        }
    }
}
