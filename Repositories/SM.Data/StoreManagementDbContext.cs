using Microsoft.EntityFrameworkCore;
using SM.Data.Models;

namespace SM.Data
{
    public class StoreManagementDbContext : DbContext
    {

        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> products { get; set; }


    }
}