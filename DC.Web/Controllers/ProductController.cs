using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;

namespace DC.Web.Controllers
{
    [Route ("[Controller]")]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var productManager = new ProductManager();

            productManager.AddProduct(new Product("qwe", "ewq"));
            productManager.AddProduct(new Product("asd", "dsa"));
            productManager.AddProduct(new Product("zxc", "cxz"));

            var products =  productManager.GetProducts().Select(p => new ProductModel(p.Id, p.NameProduct)).ToList();

            return View(products);
        }

        public void SaveEneters()
        { }
    }
}