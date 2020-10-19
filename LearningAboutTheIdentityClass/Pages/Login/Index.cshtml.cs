using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningAboutTheIdentityClass.Models;
using LearningAboutTheIdentityClass.SQLDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningAboutTheIdentityClass.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public UserLogin UserLogin { get; set; }
        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserLogin.Email,
                       UserLogin.Password, isPersistent: UserLogin.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            return Page();
        }

    }
}
