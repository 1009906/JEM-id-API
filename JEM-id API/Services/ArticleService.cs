using JEM_id_API.Interfaces;
using JEM_id_API.Models;

namespace JEM_id_API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository) 
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleDto> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public ArticleDto CreateArticle(CreateArticleDto article)
        {
            var newArticle = new ArticleDto()
            {
                Code = GenerateArticleCode(),
                Name = article.Name,
                PotSize = article.PotSize,
                PlantHeight = article.PlantHeight,
                Color = article.Color,
                ProductGroup = article.ProductGroup 
            };

            return _articleRepository.CreateArticle(newArticle);
        }

        public ArticleDto? DeleteArticle(string code)
        {
            return _articleRepository.DeleteArticle(code);
        }

        private string GenerateArticleCode()
        {
            var newCode = Guid.NewGuid().ToString().Substring(0, 13);
            var isExistingArticle = _articleRepository.GetByCode(newCode);

            while (isExistingArticle != null)
            {
                newCode = Guid.NewGuid().ToString().Substring(0, 13);
                isExistingArticle = _articleRepository.GetByCode(newCode);
            }

            return newCode;
        }
    }
}
