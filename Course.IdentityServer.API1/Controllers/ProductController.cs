using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Course.IdentityServer.API1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product {Id = 1, Name = "kalem1", Stock = 100, Price = 200},
                new Product {Id = 2, Name = "kalem2", Stock = 100, Price = 200},
                new Product {Id = 3, Name = "kalem3", Stock = 100, Price = 200}
            };

            return Ok(productList);
        }
        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult UpdateProducts(int id)
        {
             return Ok($"is'si {id} olan product güncellendi");
        }
        public IActionResult Create(Product product)
        {
            return Ok(product);
        }
    }
    
}
