using JEM_id_API.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace JEM_id_API.Validators
{
    public class IsUniqueAttribute : ValidationAttribute
    {
        public IsUniqueAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Given value cannot be null.");
            }
            
            var articleRepository = (IArticleRepository)validationContext.GetService(typeof(IArticleRepository));

            var article = articleRepository?.GetByCode(value.ToString());
            if (article == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid value, is not unique.");
        }
    }
}
