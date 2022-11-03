using System.ComponentModel.DataAnnotations;

namespace UniversityDatabaseImplement.Models
{
    public class HandBook
    {
        public int Id { get; set; }
        [Required]
        public string Info { get; set; }
    }
}
