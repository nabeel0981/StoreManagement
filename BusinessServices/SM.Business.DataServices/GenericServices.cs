using AutoMapper;
using SM.Business.Interfaces;
using SM.Data.Interfaces;
using SM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Business.DataServices
{
    public class GenericServices<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericServices(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public List<TModel> GetAll()
        {
            var allEntity = _repository.GetAll();
            var allModels = _mapper.Map<List<TModel>>(allEntity);
            return allModels;
        }
        public TModel GetById(int id)
        {
            var entity = _repository.Get(x=>x.Id==id).FirstOrDefault();
            var model = _mapper.Map<TModel>(entity);
            return model;
        }
        public void Add(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }

        public void Update(TModel model)
        {
            var Entity = _mapper.Map<TEntity>(model);
            _repository.Save(Entity);
        }

        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _repository.Delete(entity);
            }
        }
      
        
    }
}
