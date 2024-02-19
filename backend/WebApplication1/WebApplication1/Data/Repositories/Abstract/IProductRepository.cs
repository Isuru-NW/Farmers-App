using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories.Abstract
{
    public interface IProductRepository
    {
        public bool addProduct(string image, string name, decimal price, decimal quantity, string Type, string description);
        List<ProductViewModel> getAllProducts();
    }
}
