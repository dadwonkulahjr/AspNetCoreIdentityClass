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
    public class EditModel : PageModel
    {
        private readonly SQLDbContext _sQLDbContext;
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public Department Department { get; set; }
        [BindProperty]
        public Gender Gender { get; set; }

        public EditModel(SQLDbContext sQLDbContext)
        {
            _sQLDbContext = sQLDbContext;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _sQLDbContext.Employees.Find(id);
            Department = _sQLDbContext.Departments.Find(id);
            Gender = _sQLDbContext.Genders.Find(id);
            if(Employee == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
            return Page();
        }
    }
}
