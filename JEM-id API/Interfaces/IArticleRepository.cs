using JEM_id_API.Models;

namespace JEM_id_API.Interfaces
{
    public interface IArticleRepository
    {
        public ArticleDto? GetByCode(string code);
        public List<ArticleDto> GetAll();
        public ArticleDto CreateArticle(ArticleDto article);
        public ArticleDto? DeleteArticle(string code);
    }
}
