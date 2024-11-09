using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD_212_MVC.Models
{
    public class Student
    {
        [Key]
        public int stud_id { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        [Column(TypeName = "nvarchar(32)")]
        public required string last_name { get; set; }
        [Required]
        [DisplayName("Имя")]
        [Column(TypeName = "nvarchar(32)")]
        public required string first_name { get; set; }
        [DisplayName("Отчество")]
        [Column(TypeName = "nvarchar(32)")]
        public string? middle_name { get; set; }
        [Required]
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public required DateTime birth_date { get; set; }
    }
}
