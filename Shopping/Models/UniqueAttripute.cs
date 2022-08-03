using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shopping.Models
{
    public class UniqueUserAttripute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Shipping dp= new Shipping();
         AppUser user=  dp.Users.FirstOrDefault(x=>x.UserName==value.ToString());
            if (user == null)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Name Already Exists");
            }
        }
    }


    public class UniqueCityAttripute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Shipping dp = new Shipping();
            City user = dp.cities.FirstOrDefault(x => x.cityName == value.ToString());
            if (user == null)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Name Already Exists");
            }

        }
    }

    public class UniqueGovernmentAttripute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Shipping dp = new Shipping();
            Government user = dp.governments.FirstOrDefault(x => x.Name == value.ToString());
            if (user == null)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Name Already Exists");
            }

        }
    }
}
