using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningAboutTheIdentityClass.Models;
using LearningAboutTheIdentityClass.SQLDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningAboutTheIdentityClass.Pages.Employees
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly SQLDbContext _sQLDbContext;
        [BindProperty]
        public Employee Employee { get; set; }
        public CreateModel(SQLDbContext sQLDbContext)
        {
            _sQLDbContext = sQLDbContext;
        }
      
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            _sQLDbContext.Employees.Add(Employee);
            _sQLDbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
