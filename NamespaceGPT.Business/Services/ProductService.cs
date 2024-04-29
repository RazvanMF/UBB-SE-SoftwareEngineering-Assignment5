using NamespaceGPT.Business.Services.Interfaces;
using NamespaceGPT.Data.Models;
using NamespaceGPT.Data.Repositories.Interfaces;

namespace NamespaceGPT.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public int AddProduct(Product product)
        {
            return productRepository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return productRepository.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product? GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public bool UpdateProduct(int id, Product product)
        {
            return productRepository.UpdateProduct(id, product);
        }
    }
}
