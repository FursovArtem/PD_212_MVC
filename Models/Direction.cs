using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD_212_MVC.Models
{
    public class Direction
    {
        [Key]
        public byte direction_id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Направление")]
        public required string direction_name { get; set; }

        public ICollection<Group>? Groups { get; set; }
    }
}
