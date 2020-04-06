using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;

namespace DC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGetController : ControllerBase
    {
        [HttpGet("{id}")]
        public ProductModel Get(string id)
        {
            var productManager = new ProductManager();
            var product = productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            return productmodel;
        }
    }
}