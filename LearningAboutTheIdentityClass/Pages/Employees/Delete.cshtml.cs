using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningAboutTheIdentityClass.Models;
using LearningAboutTheIdentityClass.SQLDataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningAboutTheIdentityClass.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly SQLDbContext _sQLDbContext;
        [BindProperty]
        public Employee Employee { get; set; }
        public DeleteModel(SQLDbContext sQLDbContext)
        {
            _sQLDbContext = sQLDbContext;
        }
        public IActionResult OnGet(int id)
        {
            Employee = _sQLDbContext.Employees.Find(id);
            if(Employee == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Employee = _sQLDbContext.Employees.Find(Employee.Id);
            if(Employee == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
            _sQLDbContext.Employees.Remove(Employee);
            _sQLDbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
