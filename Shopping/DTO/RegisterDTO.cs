using Shopping.Models;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class RegisterDTO
    {
        [Required][UniqueUserAttripute]
        public string UserName { get; set; }
        [Required][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required][DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required][Compare("PasswordHash", ErrorMessage = "Password Not Matched")]
        [DataType(DataType.Password)]
        public string cnfirmPassword { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Government { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required][Range(minimum:14,maximum:70)]
        public int Age { get; set; }




    }
}
