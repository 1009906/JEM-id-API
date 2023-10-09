using JEM_id_API.Database;
using JEM_id_API.Enums;
using JEM_id_API.Interfaces;
using JEM_id_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
