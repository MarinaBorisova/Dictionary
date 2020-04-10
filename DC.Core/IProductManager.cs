using System.Collections.Generic;

namespace DC.Core
{
    public interface IProductManager
    {
        bool AddProduct(Product product);
        Product GetProduct(string id);
        IList<Product> GetProducts();
    }
}
