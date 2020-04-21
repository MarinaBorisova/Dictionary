using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;
using Microsoft.Extensions.Logging;

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
            Program.logger.Info("GetProducts");

            var products = _productManager.GetProducts().Select(p => new ProductModel(p.Id, p.NameProduct)).ToList();

            Program.logger.Info("Success getProducts");

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
            Program.logger.Info("AddProduct");
            var product = new Product(id, nameproduct);
            if (_productManager.AddProduct(product))
            {
                Program.logger.Info("Success add");
                return View();
            }
            else
            {
                Program.logger.Info("Not add");
                return RedirectToAction("Index");
            }
        }
        public ActionResult Get(string id)
        {
            Program.logger.Info("GetProduct");

            var product = _productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            Program.logger.Info("Success getProduct");

            return View("Datails", productmodel);
            
        }
    }
}