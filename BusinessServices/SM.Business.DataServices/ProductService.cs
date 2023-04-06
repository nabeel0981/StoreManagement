using MS.Business.Models;

namespace SM.Business.DataServices
{
    public class ProductService
    {
        private List<ProductModel> product = new List<ProductModel>();

        public List<ProductModel> GetAllProducts() 
        {
            product.Add(new ProductModel { Id = 1, Name = "Product1" });
            product.Add(new ProductModel { Id = 2, Name = "Product2" });
            product.Add(new ProductModel { Id = 3, Name = "Product3" });
            product.Add(new ProductModel { Id = 4, Name = "Product4" });
            product.Add(new ProductModel { Id = 5, Name = "Product5" });
            return product;
        }

        public void Add(ProductModel model)
        {
            
            product.Add(model);
          
        }
      
       
        public void DeleteProduct(int id)
        {
            var prod = product.Where(x => x.Id == id).FirstOrDefault();
            if (prod != null)
            {
                product.Remove(prod);
                
            }
     }
    }
}