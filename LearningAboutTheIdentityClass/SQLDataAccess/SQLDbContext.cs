using LearningAboutTheIdentityClass.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAboutTheIdentityClass.SQLDataAccess
{
    public class SQLDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public SQLDbContext(DbContextOptions<SQLDbContext> options)
            :base(options)
        {

        }
    }
}
