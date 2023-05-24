using AutoMapper;
using MS.Business.Models;
using SM.Business.Interfaces;
using SM.Data;
using SM.Data.Interfaces;
using SM.Data.Models;

namespace SM.Business.DataServices
{
    public class StoreService :GenericServices<StoreModel , Store>, IStoreService
    {
       
        public StoreService(IRepository<Store> repository , IMapper mapper) :base(repository,mapper)
        {
           
        }

    }
}