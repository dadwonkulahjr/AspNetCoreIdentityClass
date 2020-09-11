using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LearningAboutTheIdentityClass.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningAboutTheIdentityClass.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public UserRegistration UserRegistration { get; set; }
        public IndexModel(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    UserName = UserRegistration.Email,
                    Email = UserRegistration.Email
                };

                //Register New User using the userManager class
                IdentityResult result = await _userManager.CreateAsync(identityUser, UserRegistration.Password);
                if (result.Succeeded)
                {
                    //If the user is created successfully signIn the 
                    //User right away
                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                //If the Registration was not 
                //Successfully check for all errors 
                //And display it to the User.

                foreach (IdentityError error in result.Errors)
                {
                    //Call the ModelState Object
                    //And add the required error message
                    //and send it back to the user...
                    ModelState.AddModelError(string.Empty, error.Description);
                }
             
            }

            return Page();
        }
    }
}
