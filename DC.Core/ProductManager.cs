using System.Collections.Generic;

namespace DC.Core
{
    public sealed class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

       public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddProduct(Product product)
        {
            string id = product.Id;
            string nameproduct = product.NameProduct;
            return _productRepository.ProductsAdd(id, nameproduct);
        }

        public Product GetProduct(string id)
        {
            return _productRepository.ProductsGetbyId(id);
        }


        public IList<Product> GetProducts()
        {
            return _productRepository.ProductsGetAll();
        }

    }
}
