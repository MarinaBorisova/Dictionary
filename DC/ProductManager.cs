using System;
using System.Collections.Generic;
using System.Text;

namespace DC
{
    class ProductManager
    {
        string item, value;
        private Dictionary<string, string> Products = new Dictionary<string, string>();

        public bool AddProduct(string Note)
        {
            item = Note.Substring(0, Note.IndexOf(' '));
            value = Note.Substring(Note.IndexOf(' ') + 1);


            if (Products.ContainsKey(item) || Products.ContainsValue(value))
            {
                return false;
            }
            else
            {
                Products.Add(item, value);
                return true;
            }
        }

        //public Product GetSomeProducts(string item)
        //{
        //    var products = new Product();

        //    if (Products.ContainsKey(item))
        //    {
        //        products.Id = item;
        //        products.NameProduct = value;

        //        return products;
        //    }
        //}
        
        
        public Dictionary<string, string> WatchAllProduct()
        {
            foreach (KeyValuePair<string, string> pair in Products)
            {
                return Products;
            }
            var EndProducts = new Dictionary<string, string>
            {
                { "*******", "******" }
            };
            return EndProducts;
        }

            
    }
}
