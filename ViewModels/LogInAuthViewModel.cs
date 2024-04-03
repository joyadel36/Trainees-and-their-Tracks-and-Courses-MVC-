using System.ComponentModel.DataAnnotations;

namespace task1.ViewModels
{
    public class LogInAuthViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "you must entr your user name.....")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "you must entr your user password.....")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
