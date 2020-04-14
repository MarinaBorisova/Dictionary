using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;
using DC.SQLServices;
using Microsoft.Extensions.Configuration;

namespace DC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private IProductManager _productManager;
        public ProductApiController(IProductManager productManager)
        {
             _productManager = productManager;
        }
    
        
        [HttpGet("{id}")]
        public ProductModel Get(string id)
        {
            var product = _productManager.GetProduct(id);
            var productmodel = new ProductModel(product.Id, product.NameProduct);

            return productmodel;
        }
    }
}