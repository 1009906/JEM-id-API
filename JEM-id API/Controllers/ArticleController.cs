using JEM_id_API.Enums;
using JEM_id_API.Interfaces;
using JEM_id_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace JEM_id_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetAll")]
        public List<ArticleDto> GetAll()
        {
            return _articleService.GetAll();
        }

        [HttpGet("GetByFilter")]
        public IActionResult GetByFilter(string? name, double? fromPotSize, double? toPotSize, ColorEnum? color, ProductGroupsEnum? productGroup)
        {
            if ((fromPotSize == null && toPotSize == null) || (fromPotSize <= toPotSize))
            {
                var filter = new ArticleFilterDto()
                {
                    Name = name,
                    FromPotSize = fromPotSize,
                    ToPotSize = toPotSize,
                    Color = color,
                    ProductGroup = productGroup
                };

                var articles = _articleService.GetByFilter(filter);
                return Ok(articles);
            }
            return BadRequest("Invalid range of potsize.");
        }

        [HttpPost("Create")]
        public IActionResult CreateArticle([FromForm] CreateArticleDto articleDto)
        {
            if (!ModelState.IsValid || articleDto == null)
            {
                return BadRequest("Article is invalid.");
            }
            var article = _articleService.CreateArticle(articleDto);
            return Ok(article);
        }

        [HttpPut("Update")]
        public IActionResult UpdateArticle([FromForm] ArticleDto articleDto)
        {
            if (!ModelState.IsValid || articleDto == null)
            {
                return BadRequest("Article is invalid.");
            }

            var article = _articleService.UpdateArticle(articleDto);
            if (article == null)
            {
                return NotFound("Article cannot be found.");
            }
            return Ok(article);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteArticle(string code) 
        {
            var article = _articleService.DeleteArticle(code);
            if (article == null)
            {
                return NotFound("Article cannot be found.");
            }
            return Ok(article);
        }
    }
}
