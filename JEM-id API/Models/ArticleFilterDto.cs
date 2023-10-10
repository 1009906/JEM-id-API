using JEM_id_API.Enums;

namespace JEM_id_API.Models
{
    public class ArticleFilterDto
    {
        public string? Name { get; set; }
        public double? FromPotSize { get; set; }
        public double? ToPotSize { get; set; }
        public ColorEnum? Color { get; set; }
        public ProductGroupsEnum? ProductGroup { get; set; }
    }
}
