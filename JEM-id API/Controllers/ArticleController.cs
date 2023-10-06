using JEM_id_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JEM_id_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public ArticleController() { }

        [HttpGet("GetNameTest")]
        public string GetNameTest()
        {
            return "GetNameTest";
        }

        [HttpGet("GetArticles")]
        public IEnumerable<ArticleDto> GetArticles()
        {
            return Enumerable.Range(1, 5).Select(index => new ArticleDto
            {
                Id = index,
                Name = index.ToString(),
                PlantHeight = index,
                PotSize = index,
                Color = $"Color {index}",
                ProductGroup = $"Productgroup {index}"
            })
            .ToArray();
        }

    }
}
