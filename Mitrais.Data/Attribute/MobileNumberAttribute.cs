using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mitrais.Data.Attribute
{
    public class MobileNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            long number;
            var stringValue = value.ToString();
            if(stringValue.Length < 10 || stringValue.Substring(0, 3) != "+62" || !long.TryParse(stringValue.Substring(3), out number))
            {
                return false;
            }

            return true;
        }
    }
}
