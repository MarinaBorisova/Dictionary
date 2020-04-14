using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;

namespace DC.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public  ActionResult Index()
        {
            var products = _productManager.GetProducts().Select(p => new ProductModel(p.Id, p.NameProduct)).ToList();

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
            //var productManager = new ProductManager();
            var product = new Product(id, nameproduct);
            if (_productManager.AddProduct(product))
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
            var product = _productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            return View("Datails", productmodel);
        }
    }
}