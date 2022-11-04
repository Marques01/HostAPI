namespace BLL.Models
{
    public class CategoryProduct
    {
        private Guid
            _categoryId = default,
            _productId = default;

        public Guid CategoryId { get => _categoryId; set => _categoryId = value; }

        public Guid ProductId { get => _productId; set => _productId = value; }

        public Product Product { get; set; }

        public Category Category { get; set; }

        public CategoryProduct()
        {
            Product = new Product();

            Category = new Category();
        }
    }
}
