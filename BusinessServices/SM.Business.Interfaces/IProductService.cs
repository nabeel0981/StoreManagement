﻿using MS.Business.Models;

namespace SM.Business.Interfaces
{
    public interface IProductService
    {
        public List<ProductModel> GetAllProducts();
        public List<ProductModel> Search(string SerachTerm);
        public void Add(ProductModel model);
        public void UpdateProduct(ProductModel model);
        public void DeleteProduct(int id);
    }
}