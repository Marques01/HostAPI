using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class Product
    {
        private Guid
            _productId = default;            

        private string
            _name = string.Empty,
            _imagePath = string.Empty;

        private decimal
            _price = default;

        public Guid ProductId { get => _productId; init => _productId = value; }        

        public string Name { get => _name; init => _name = value; }

        public string ImagePath { get => _imagePath; init => _imagePath = value; }

        public decimal Price { get => _price; init => _price = value; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }

        public Product()
        {
            _productId = Guid.NewGuid();

            Categories = new Collection<Category>();

            CategoriesProducts = new Collection<CategoryProduct>();
        }
    }
}
