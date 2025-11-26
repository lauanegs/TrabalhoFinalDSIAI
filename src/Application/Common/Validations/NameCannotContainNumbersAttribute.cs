using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.Common.Validations
{
    public class NameCannotContainNumbersAttribute : ValidationAttribute
    {
        public NameCannotContainNumbersAttribute()
        {
            ErrorMessage = "O nome não pode conter números.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var text = value.ToString();

            return !text.Any(char.IsDigit);
        }
    }
}
