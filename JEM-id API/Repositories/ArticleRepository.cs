using JEM_id_API.Database;
using JEM_id_API.Interfaces;
using JEM_id_API.Models;

namespace JEM_id_API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DatabaseContext _dbContext;

        public ArticleRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ArticleDto? GetByCode(string code)
        {
            return _dbContext.Articles.FirstOrDefault(x => x.Code == code);
        }

        public List<ArticleDto> GetAll()
        {
            return _dbContext.Articles.ToList();
        }

        public ArticleDto CreateArticle(ArticleDto article)
        {
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return article;
        }

        public ArticleDto? DeleteArticle(string code)
        {
            var article = GetByCode(code);
            if (article != null)
            {
                _dbContext.Articles.Remove(article);
                _dbContext.SaveChanges();
            }
            return article;
        }

    }
}
