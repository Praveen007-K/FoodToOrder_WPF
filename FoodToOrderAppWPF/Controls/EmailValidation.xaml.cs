using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodToOrderAppWPF.Controls
{
    /// <summary>
    /// Interaction logic for EmailValidation.xaml
    /// </summary>
    public class EmailValidationule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;

            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult(false, "Email address is required.");
            }

            // Regular expression for basic email validation
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(email))
            {
                return new ValidationResult(false, "Invalid email address.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
