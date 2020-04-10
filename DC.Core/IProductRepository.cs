using System;
using System.Collections.Generic;
using System.Text;

namespace DC.Core
{
    public interface IProductRepository
    {
        IList<Product> Products_Get_All();
        Product Products_Get_by_Id(string id);
        bool Products_Add(string id, string nameProduct);
    }
}
