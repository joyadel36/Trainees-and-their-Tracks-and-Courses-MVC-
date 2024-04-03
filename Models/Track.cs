using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    [Table ("Track")]
    public class Track
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "you must enter track name...!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you must enter track description...!!")]
        [MinLength(5,ErrorMessage ="you must enter at least 5 character...!!")]
        public string Description { get; set; }

        public virtual ICollection<Trainee>? Trainees { get; set; }

    }
}
