using System.ComponentModel.DataAnnotations;

namespace ProjectService.Models
{
    public class Project
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

     
        public string Description { get; set; }

      
    }
}