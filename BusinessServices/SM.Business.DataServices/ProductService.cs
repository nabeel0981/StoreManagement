using MS.Business.Models;
using SM.Business.Interfaces;
using SM.Data;

namespace SM.Business.DataServices
{
    public class ProductService : IProductService
    {
       private readonly StoreManagementDbContext _dbContext;
        public ProductService(StoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  List<ProductModel> GetAllProducts() 
        {
            var allproducts =  _dbContext.products.ToList();
            var productsModels = allproducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name }).ToList();
            return productsModels;
        }

        public void Add(ProductModel model)
        {
            
            _dbContext.products.Add(new Data.Models.Product { Id=model.Id , Name=model.Name});
            _dbContext.SaveChanges();
          
        }

        public void UpdateProduct(ProductModel model)
        {
            var index = _dbContext.products.FirstOrDefault(x =>x.Id == model.Id);
            
            if(index!=null)
            {
                index.Name = model.Name;
            }
             
            _dbContext.products.Update(index);
            _dbContext.SaveChanges();
           
        }
      
       
        public void DeleteProduct(int id)
        {
            var prod = _dbContext.products.Where(x => x.Id == id).FirstOrDefault();
            if (prod != null)
            {
                _dbContext.products.Remove(prod);
                _dbContext.SaveChanges();
                
            }
        }
    }
}