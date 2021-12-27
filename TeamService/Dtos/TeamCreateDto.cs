using System.ComponentModel.DataAnnotations;

namespace TeamService.Dtos
{
    public class TeamCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}