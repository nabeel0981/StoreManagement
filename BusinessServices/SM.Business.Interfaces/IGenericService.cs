using MS.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Business.Interfaces
{
    public interface IGenericService<TModel>
    {
        public List<TModel> GetAll();
        public void Add(TModel model);
        public void Update(TModel model);
        public void Delete(int id);
    }
}
