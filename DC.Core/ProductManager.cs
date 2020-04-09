using System.Collections.Generic;
using System.Linq;

namespace DC.Core
{
    public sealed class ProductManager
    {
        //private static Dictionary<string, Product> Products = new Dictionary<string, Product>();
        private readonly IProductRepository _productRepository;

       public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddProduct(Product product)
        {
          return _productRepository.AddProduct(product);
            //if (Products.ContainsKey(product.Id))
            //{
            //    return false;
            //}
            //else
            //{
            //    Products.Add(product.Id, product);
            //    return true;
            //}
        }

        public Product GetProduct(string id)
        {
            return _productRepository.GetProduct(id);
            //return Products.TryGetValue(id, out var product) ? product : null;
        }


        public IList<Product> GetProducts()
        {
            return _productRepository.GetProducts();
            //return Products.Select(p => p.Value).ToList();
        }

    }
}
