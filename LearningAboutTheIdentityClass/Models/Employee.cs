using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAboutTheIdentityClass.Models
{
    public class Employee
    {
        [Key]
        [Column(Order = 0, TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(name: "Fullname", Order =1,TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "The email is not valid.")]
        [Column(Order =2, TypeName ="nvarchar(50)")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        [Column(Order =3, TypeName ="decimal(18,0)")]
        public decimal Salary { get; set; }
        [Column(name: "Department Name", Order = 4, TypeName = "nvarchar(50)")]
        [Required]
        public Department Department { get; set; }
        [Column(Order = 5, TypeName = "nvarchar(50)")]
        [Required]
        public Gender Gender { get; set; }
    }
}
