using JEM_id_API.Models;

namespace JEM_id_API.Interfaces
{
    public interface IArticleService
    {
        public List<ArticleDto> GetAll();
        public List<ArticleDto> GetByFilter(ArticleFilterDto filter);
        public ArticleDto CreateArticle(CreateArticleDto article);
        public ArticleDto? UpdateArticle(ArticleDto article);
        public ArticleDto? DeleteArticle(string code);
    }
}
