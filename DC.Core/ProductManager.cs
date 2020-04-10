using System.Collections.Generic;

namespace DC.Core
{
    public sealed class ProductManager : IProductManager
    {
        //private static Dictionary<string, Product> Products = new Dictionary<string, Product>();
        private readonly IProductRepository _productRepository;

       public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddProduct(Product product)
        {
            string id = product.Id;
            string nameproduct = product.NameProduct;
          return _productRepository.Products_Add(id, nameproduct);
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
            return _productRepository.Products_Get_by_Id(id);
            //return Products.TryGetValue(id, out var product) ? product : null;
        }


        public IList<Product> GetProducts()
        {
            return _productRepository.Products_Get_All();
            //return Products.Select(p => p.Value).ToList();
        }

    }
}
