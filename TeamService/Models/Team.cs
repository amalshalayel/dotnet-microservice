using System.ComponentModel.DataAnnotations;

namespace TeamService.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

   
        public string Phone { get; set; }

     
        public string Description { get; set; }

      
    }
}