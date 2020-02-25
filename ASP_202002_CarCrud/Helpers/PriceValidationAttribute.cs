using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Helpers
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        public int Divider { get; set; }
        public string ErrorMessage { get; set; }
        public override bool IsValid(object value)
        {
            int price = (int)value;
            if (price % Divider == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage;
        }
    }
}
