﻿using LearningAboutTheIdentityClass.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAboutTheIdentityClass.Models
{
    public class UserRegistration
    {

        [EmailAddress, RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        [Required, VaildEmailDomain(allowedEmail:"tuseTheProgrammer.com", ErrorMessage ="Email domain must be tuseTheProgrammer.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirm password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
