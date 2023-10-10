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

        public ArticleDto? UpdateArticle(ArticleDto article)
        {
            var articleToUpdate = GetByCode(article.Code);
            if (articleToUpdate != null)
            {
                articleToUpdate.Code = article.Code;
                articleToUpdate.Name = article.Name;
                articleToUpdate.PotSize = article.PotSize;
                articleToUpdate.PlantHeight = article.PlantHeight;
                articleToUpdate.Color = article.Color;
                articleToUpdate.ProductGroup = article.ProductGroup;

                _dbContext.Update(articleToUpdate);
                _dbContext.SaveChanges();
            }
            return articleToUpdate;
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
