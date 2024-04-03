using System.ComponentModel.DataAnnotations;

namespace task1.ViewModels
{
    public class SignUpAuthViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "you must entr your user name.....")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "you must entr your phone number.....")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "you must entr your email.....")]
        public string Email { get; set; }

        [Required(ErrorMessage = "you must entr your user password.....")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "you must entr your user password.....")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
   
    }
}
