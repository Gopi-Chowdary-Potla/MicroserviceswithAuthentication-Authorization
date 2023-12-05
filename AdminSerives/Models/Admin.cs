using System.ComponentModel.DataAnnotations;

namespace AdminSerives.Models
{
    public class Admin
    {
        [Key]
        public int Autoid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Salary { get; set; }
    }
}
