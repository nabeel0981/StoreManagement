using AutoMapper;
using MS.Business.Models;
using SM.Business.Interfaces;
using SM.Data;
using SM.Data.Interfaces;
using SM.Data.Models;

namespace SM.Business.DataServices
{
    public class ProductService :GenericServices<ProductModel , Product>, IProductService
    {
       private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository , IMapper mapper) :base(repository,mapper)
        {
            _repository = repository;
        }

        
        public List<ProductModel> Search(string SerachTerm)
        {
            var allproducts = _repository.Get(x => x.Name.ToLower().Trim()
            .Contains(SerachTerm.Trim().ToLower()) || x.Description.ToLower().Trim()
            .Contains(SerachTerm.Trim().ToLower())).ToList();
            var productsModels = allproducts.Select(x => new ProductModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            return productsModels;
        }
    }
}