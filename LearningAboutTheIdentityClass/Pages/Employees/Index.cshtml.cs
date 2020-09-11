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
    public class IndexModel : PageModel
    {
        private readonly SQLDbContext _sQLDbContext;
        public IEnumerable<Employee> Employee { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Department> Department { get; set; }
        public IndexModel(SQLDbContext sQLDbContext)
        {
            _sQLDbContext = sQLDbContext;
        }
        public void OnGet()
        {
            Employee = _sQLDbContext.Employees.ToList();
            Department = _sQLDbContext.Departments.ToList();
            Gender = _sQLDbContext.Genders.ToList();
        }
    }
}
