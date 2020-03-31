using System.Collections.Generic;
using System.Linq;

namespace DC.Core
{
    public sealed class ProductManager
    {
        private Dictionary<string, Product> Products = new Dictionary<string, Product>();

        public bool AddProduct(Product product)
        {

            if (Products.ContainsKey(product.Id))
            {
                return false;
            }
            else
            {
                Products.Add(product.Id, product);
                return true;
            }
        }

        public Product GetProduct(string id)
        {
            return Products.TryGetValue(id, out var product) ? product : null;
        }


        public IList<Product> GetProducts()
        {
            return Products.Select(p => p.Value).ToList();
        }

    }
}
