using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.DBProviders;
using WebApplication1.Data.Repositories.Abstract;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories.Product
{
    public class ProductRepository : SQLRepository, IProductRepository
    {
        private readonly SQLDBContext SQLDbContext;

        public ProductRepository(SQLDBContext sqlDbContext)
        {
            SQLDbContext = sqlDbContext;
        }

        public bool addProduct(string image, string name, decimal price, decimal quantity, string Type, string description)
        {
            try
            {
                var dbParams = new DbParameter[6];
                dbParams[0] = StringParameter("@Image", image); 
                dbParams[1] = StringParameter("@Name", name);
                dbParams[2] = DecimalParameter("@Price", price);
                dbParams[3] = DecimalParameter("@Quantity", quantity);
                dbParams[4] = StringParameter("@Type", Type);
                dbParams[5] = StringParameter("@Description", description);

                object result = SQLDbContext.ExecuetReader("InsertProduct", dbParams);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductViewModel> getAllProducts()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            var dbParams = new DbParameter[0];
            DbDataReader dbDataReader = SQLDbContext.ExecuetReader("GetProducts", dbParams);
            try
            {
                while (dbDataReader.Read())
                {
                    ProductViewModel product = new ProductViewModel();
                    product.Id = Convert.ToInt32(dbDataReader["Product_id"]);
                    product.Image = dbDataReader["Image"].ToString();
                    product.Name = dbDataReader["Name"].ToString();
                    product.Price = Convert.ToDecimal(dbDataReader["Price"]);
                    product.Quantity = Convert.ToDecimal(dbDataReader["Quantity"]);
                    product.Type = dbDataReader["Type"].ToString();
                    product.Description = dbDataReader["Description"].ToString();
                    productList.Add(product);
                }
                dbDataReader.Close();

                return productList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
