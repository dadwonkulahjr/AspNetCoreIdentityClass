using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAboutTheIdentityClass.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(name:"Department Name", TypeName ="nvarchar(50)")]
        [Display(Name ="Department")]
        public string DepartmentName { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Description { get; set; }


    }
}
