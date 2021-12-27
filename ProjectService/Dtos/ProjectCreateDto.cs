using System.ComponentModel.DataAnnotations;

namespace ProjectService.Dtos
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}