﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Business.Models;
using SM.Business.DataServices;
using SM.Business.Interfaces;

namespace StoreManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public ActionResult Index(string? search)
        {
            List<ProductModel> products ;
            
            if (search == null)
            {
                products= _productService.GetAll();
            }
            else
            {
                products = _productService.Search(search);

            }

            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {

            try
            {
                _productService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.GetAll().Where(x=>x.Id==id).FirstOrDefault();
            
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
                _productService.Update(model);
             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
           _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
