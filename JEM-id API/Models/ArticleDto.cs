using JEM_id_API.Enums;
using JEM_id_API.Validators;
using System.ComponentModel.DataAnnotations;

namespace JEM_id_API.Models
{
    public class ArticleDto
    {
        /*
        Een artikel bevat:
            - Een code van max 13 karakters (verplicht en uniek)
            - Een naam van max 50 karakters (verplicht)
            - Een numerieke waarde voor potmaat (verplicht)
            - Een numerieke waarde voor planthoogte (verplicht)
            - Een kleur (optioneel)
            - Een productgroep (verplicht)
        */
        [Required]
        [MaxLength(13, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        //[IsUnique]
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
