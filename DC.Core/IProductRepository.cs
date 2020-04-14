using System;
using System.Collections.Generic;
using System.Text;

namespace DC.Core
{
    public interface IProductRepository
    {
        IList<Product> ProductsGetAll();
        Product ProductsGetbyId(string id);
        bool ProductsAdd(string id, string nameProduct);
    }
}
