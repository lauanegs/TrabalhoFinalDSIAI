using System.ComponentModel.DataAnnotations;

namespace Application.Common.Validations
{
    public class PriceGreaterThanZeroAttribute : ValidationAttribute
    {
        public PriceGreaterThanZeroAttribute()
        {
            ErrorMessage = "O preço deve ser maior que zero.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            if (decimal.TryParse(value.ToString(), out decimal price))
            {
                return price > 0;
            }

            return false;
        }
    }
}
