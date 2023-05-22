using MS.Business.Models;
using SM.Business.Interfaces;
using SM.Data;
using SM.Data.Interfaces;
using SM.Data.Models;

namespace SM.Business.DataServices
{
    public class ProductService : IProductService
    {
       private readonly IRepository<Product> _dbContext;
        public ProductService(IRepository<Product> dbContext)
        {
            _dbContext = dbContext;
        }

        public  List<ProductModel> GetAllProducts() 
        {
            var allproducts =  _dbContext.GetAll();
            var productsModels = allproducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name , Description=x.Description }).ToList();
            return productsModels;
        }

        public List<ProductModel> Search(string SerachTerm)
        {
            var allproducts = _dbContext.Get(x => x.Name.ToLower().Trim()
            .Contains(SerachTerm.Trim().ToLower()) || x.Description.ToLower().Trim()
            .Contains(SerachTerm.Trim().ToLower())).ToList();
            var productsModels = allproducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            return productsModels;
        }

        public void Add(ProductModel model)
        {
            
            _dbContext.Save(new Data.Models.Product { Id=model.Id , Name=model.Name , Description=model.Description});
            //_dbContext.SaveChanges();
          
        }

        public void UpdateProduct(ProductModel model)
        {
            _dbContext.Save(new Product { Id = model.Id, Name = model.Name, Description = model.Description });
        }
      
       
        public void DeleteProduct(int id)
        {
            var prod = _dbContext.Get(x => x.Id == id).FirstOrDefault();
            if (prod != null)
            {
                _dbContext.Delete(prod);
               // _dbContext.SaveChanges();
                
            }
        }
    }
}