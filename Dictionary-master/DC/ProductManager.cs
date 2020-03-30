using System;
using System.Collections.Generic;
using System.Text;

namespace DC
{
    class ProductManager
    {
        string item, valuea;
        private Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                return ProductDictionary[key];
            }
            set
            {
                if (!ProductDictionary.ContainsKey(item) || !ProductDictionary.ContainsValue(valuea))
                {
                    ProductDictionary[key] = value;
                }
                else
                {
                    ProductDictionary[key] = null;
                }
            }
        }

        public void AddProduct(string Note)
        {
           item = Note.Substring(0, Note.IndexOf(' '));
           valuea = Note.Substring(Note.IndexOf(' ') + 1);


            if (ProductDictionary.ContainsKey(item) || ProductDictionary.ContainsValue(valuea))
            {
                Console.WriteLine("Error");
            }
            else
            {
                ProductDictionary.Add(item, valuea);
                Console.WriteLine("Success");
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
