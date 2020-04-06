using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;

namespace DC.Web.Controllers
{
    public class ProductController : Controller
    {
        public  ActionResult Index()
        {
            var productManager = new ProductManager();
            var products = productManager.GetProducts().Select(p => new ProductModel(p.Id, p.NameProduct)).ToList();

           

            return View(products);
        }

        public ActionResult Partial()
        {
            return PartialView();
        }
      

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string id, string nameproduct)
        {
            var productManager = new ProductManager();
            var product = new Product(id, nameproduct);
            if (productManager.AddProduct(product))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Get(string id)
        {
            var productManager = new ProductManager();
            var product = productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            return View("Datails", productmodel);
        }
    }
}