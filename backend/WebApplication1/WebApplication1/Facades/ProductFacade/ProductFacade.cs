using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Repositories.Abstract;
using WebApplication1.Models;

namespace WebApplication1.Facades.ProductFacade
{
    //addProduct(string image, string name, decimal price, decimal quantity, string Type, string description)
    public class ProductFacade
    {
        private readonly IProductRepository _productFacade;

        public ProductFacade(IProductRepository productFacade)
        {
            this._productFacade = productFacade;
        }

        public bool addProduct(string image, string name, decimal price, decimal quantity, string type, string description)
        {
            return _productFacade.addProduct(image, name, price, quantity, type, description);
        }

        public List<ProductViewModel> getAllProducts()
        {
            return _productFacade.getAllProducts();
        }
    }
}
