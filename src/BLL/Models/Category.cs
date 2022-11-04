using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Category
    {
        private Guid
            _categoryId = default;

        private string
            _name = string.Empty;

        public Guid CategoryId { get => _categoryId; init => _categoryId = value; }

        public string Name { get => _name; init => _name = value; }

        public ICollection<Product> Products { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }

        public Category()
        {
            _categoryId = Guid.NewGuid();

            Products = new Collection<Product>();

            CategoriesProducts = new Collection<CategoryProduct>();
        }
    }
}
