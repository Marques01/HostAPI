using BLL.Models;

namespace BLL.Validations
{
    public class CategoryValidations
    {
        public void Validate(Category category)
        {
            RemoveWhiteSpaces(category);

            if (category.Name.Length < 3)
                throw new Exception("O nome deve ter no mínimo 3 caracteres");

            if (category.Name is null)
                throw new Exception("O nome é obrigatório!");
        }

        private void RemoveWhiteSpaces(Category category)
        {
            category.Name.Trim();
        }
    }
}
