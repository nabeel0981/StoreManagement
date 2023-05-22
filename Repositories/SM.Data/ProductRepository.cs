using SM.Data.Interfaces;
using SM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Data
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(StoreManagementDbContext context) :base(context) 
        {
          
        }
    }
}
