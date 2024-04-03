using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace task1.Models
{
    public enum Gender { Male, Female }
    [Table("Trainee")]
    public class Trainee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        [MaxLength(20, ErrorMessage = " name must be less than 20 characters"), MinLength(3, ErrorMessage = " name must be more than 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter your phone number")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="error in phone number syntax..!!!")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "You must enter your birth date")]
        [DataType(DataType.Date, ErrorMessage = "error in birth date syntax..!!!")]
        public DateTime Birthdate { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required(ErrorMessage = "You must choose your gender")]
        public Gender gender { get; set; }

        [ForeignKey("T_rack")]
        public int TR_ID { get; set; }

        public virtual Track T_rack { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
