using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC.Core;

namespace DC.Web.Models
{
    
    public class ProductModel
    {
        public string Id { get; set; }
        public string NameProduct { get; set; }

        public ProductModel(string id, string name)
        {
            Id = id;
            NameProduct = name;
        }
    }
}
