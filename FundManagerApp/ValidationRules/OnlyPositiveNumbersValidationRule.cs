using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FundManagerApp.ValidationRules
{
    public class OnlyPositiveNumbersValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i) && i >= 0)
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Negative numbers are not allowed");
        }
    }
    
}
