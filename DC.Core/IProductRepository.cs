using System;
using System.Collections.Generic;
using System.Text;

namespace DC.Core
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        Product GetProduct(string id);
        bool AddProduct(Product product);
    }
}
