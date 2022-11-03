using System.ComponentModel.DataAnnotations;

namespace UniversityDatabaseImplement.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Flm { get; set; }
        [Required]
        public string ShortCharacteristic { get; set; }
        [Required]
        public string Grade { get; set; }
        public double? Scholatship { get; set; }
    }
}
