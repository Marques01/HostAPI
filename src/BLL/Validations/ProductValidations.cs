using BLL.Models;

namespace BLL.Validations
{
    public class ProductValidations
    {
        public void NameValidation(Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("O Nome é obrigatório!");

            if (model.Name.Length < 3)
                throw new Exception("O Nome precisa ter no minímo 3 caracteres");
        }
        
    }
}
