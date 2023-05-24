using MS.Business.Models;

namespace SM.Business.Interfaces
{
    public interface IProductService : IGenericService<ProductModel>
    {
     public  List<ProductModel> Search(string SerachTerm);
    }
}
