using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;
using DC.SQLServices;
using Microsoft.Extensions.Configuration;

namespace DC.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _productManager;

        public ProductController(IConfiguration configuration)
        {
            ProductRepository productRepository = new ProductRepository(configuration.GetConnectionString("Database"));
            _productManager = new ProductManager(productRepository);
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
            //var productManager = new ProductManager();
            var product = _productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            return View("Datails", productmodel);
        }
    }
}