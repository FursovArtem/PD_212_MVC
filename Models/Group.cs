using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD_212_MVC.Models
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }
        [Required]
        [Column(TypeName = "nchar(10)")]
        [DisplayName("Группа")]
        public required string group_name { get; set; }
        [ForeignKey("Direction")]
        [Required]
        public required byte direction { get; set; }

        [DisplayName("Направление")]
        public required Direction Direction { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
