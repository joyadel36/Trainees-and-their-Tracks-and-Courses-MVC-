using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace task1.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "you must enter Topic ...!!")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "you must enter grade ...!!")]
        public int Grade { get; set; }

        [ForeignKey("T_rainee")]
        public int T_ID { get; set; }
        
        [JsonIgnore]
        public virtual Trainee T_rainee { get; set; }
    }
}
