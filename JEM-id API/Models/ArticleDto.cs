using JEM_id_API.Enums;
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
        [Key]
        [Required]
        public int Id { get; set; } //Misschien guid?

        [Required]
        public string Name { get; set; }

        [Required]
        public double PotSize { get; set; }

        [Required]
        public double PlantHeight { get; set; }

        public ColorEnum Color { get; set; } //Enum waardes?

        [Required]
        public string ProductGroup { get; set; } //Enum waardes?
    }
}
