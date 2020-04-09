using Microsoft.AspNetCore.Mvc;
using DC.Core;
using DC.Web.Models;
using DC.SQLServices;
using Microsoft.Extensions.Configuration;

namespace DC.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGetController : ControllerBase
    {
        //private ProductManager _productManager;
        //public ProductGetController(IConfiguration configuration)
        //{
        //    ProductRepository productRepository = new ProductRepository(configuration.GetConnectionString("Database"));
        //    _productManager = new ProductManager(productRepository);
        //}
        //[HttpGet("{id}")]

    }
}