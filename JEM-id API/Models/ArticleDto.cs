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
        public int Id { get; set; } //Misschien guid?
        public string Name { get; set; }
        public int PotSize { get; set; } //Double?
        public int PlantHeight { get; set; } //Double?
        public string Color { get; set; } //Enum waardes?
        public string ProductGroup { get; set; } //Enum waardes?
    }
}
