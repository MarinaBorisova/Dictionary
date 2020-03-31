using System.Collections.Generic;
using System.Linq;

namespace DC
{
    class ProductManager
    {
        string item, value;
        private Dictionary<string, Product> Products = new Dictionary<string, Product>();

        public bool AddProduct(Product product)
        {
            //Поменять
            


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
            return Products.TryGetValue(id, out var product)? product : null;
        }


        public IList<Product> GetProducts()
        {
            return Products.Select(p => p.Value).ToList();   
        }

            
    }
}
