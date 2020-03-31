using System;
using System.Collections.Generic;
using System.Text;

namespace DC
{
    public sealed class Product
    {
        public string Id { get; set; }
        public string NameProduct { get; set; }

        public Product(string id, string name)
        {
            Id = id;
            NameProduct = name;
        }
    }
}
