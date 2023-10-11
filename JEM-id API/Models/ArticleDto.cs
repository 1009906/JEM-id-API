using JEM_id_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace JEM_id_API.Models
{
    public class ArticleDto
    {
        [Required]
        [MaxLength(13, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double PotSize { get; set; }

        [Required]
        public double PlantHeight { get; set; }

        public ColorEnum? Color { get; set; }

        [Required]
        public ProductGroupsEnum ProductGroup { get; set; }
    }
}
