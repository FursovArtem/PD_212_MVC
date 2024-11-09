﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PD_212_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int teacher_id { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        [Column(TypeName = "nvarchar(50)")]
        public required string last_name { get; set; }
        [Required]
        [DisplayName("Имя")]
        [Column(TypeName = "nvarchar(50)")]
        public required string first_name { get; set; }
        [DisplayName("Отчество")]
        [Column(TypeName = "nvarchar(50)")]
        public string? middle_name { get; set; }
        [Required]
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public required DateTime birth_date { get; set; }
        [Required]
        [DisplayName("Дата трудоустройства")]
        [DataType(DataType.Date)]
        public required DateTime work_since { get; set; }
    }
}
