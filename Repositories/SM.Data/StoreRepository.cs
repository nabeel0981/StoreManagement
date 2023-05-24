using SM.Data.Interfaces;
using SM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Data
{
    public class StoreRepository : Repository<Store>,IStoreRepository
    {
        public StoreRepository(StoreManagementDbContext context) :base(context) 
        {
          
        }
    }
}
