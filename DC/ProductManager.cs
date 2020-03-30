using System;
using System.Collections.Generic;
using System.Text;

namespace DC
{
    class ProductManager
    {
        string item, value;
        private Dictionary<string, string> Products = new Dictionary<string, string>();

        public Product GetProduct(string id)
        {
            var product = new Product();
            //add functional
        }

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

        public void SeeDictionary()
        {
            foreach (KeyValuePair<string, string> pair in ProductDictionary)
            {
                Console.WriteLine($" {pair.Key} - {pair.Value}");
            }
        }
    }
}
