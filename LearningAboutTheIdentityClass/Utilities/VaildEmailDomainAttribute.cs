using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAboutTheIdentityClass.Utilities
{
    public class VaildEmailDomainAttribute : ValidationAttribute
    {
        private readonly string _allowedEmail;

        public VaildEmailDomainAttribute(string allowedEmail)
        {
            this._allowedEmail = allowedEmail;
        }


        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            string[] arrayOfStrings = value.ToString().Split('@');
            return arrayOfStrings[1].ToUpper() == _allowedEmail.ToUpper();
        }

    }
}
