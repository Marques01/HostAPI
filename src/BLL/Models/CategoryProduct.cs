namespace BLL.Models
{
    public class CategoryProduct
    {
        private int
            _categoryId = default,
            _productId = default;

        public int CategoryId { get => _categoryId; set => _categoryId = value; }

        public int ProductId { get => _productId; set => _productId = value; }

        public Product Product { get; set; }

        public Category Category { get; set; }

        public CategoryProduct()
        {
            Product = new Product();

            Category = new Category();
        }
    }
}
