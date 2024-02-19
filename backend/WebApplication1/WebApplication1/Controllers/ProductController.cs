using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Facades.ProductFacade;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductFacade _productFacade;

        public ProductController(ProductFacade productFacade)
        {
            this._productFacade = productFacade;
        }

        [HttpPost]
        [Route("addProduct/{image}/{name}/{price}/{quantity}/{type}/{description}")]
        public IActionResult addProduct(string image, string name, decimal price, decimal quantity, string type, string description)
        {           
            try
            {
                bool success = _productFacade.addProduct(image, name, price, quantity, type, description);

                if (success)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(new { success = false, error = "Adding Product Failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = "An error occurred during adding product." });
            }
        }

        [HttpGet]
        [Route("getAllProducts")]
        public IActionResult getAllProducts()
        {
            try
            {
                return Ok(_productFacade.getAllProducts());
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
