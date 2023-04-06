using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Business.Models;
using SM.Business.DataServices;

namespace StoreManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public ActionResult Index(string? search)
        {
            List<ProductModel> products = null;
            
            if (search == null)
            {
                products= _productService.GetAllProducts();
            }
            else
            {
                products = _productService.GetAllProducts().Where(x => x.Name.ToLower().Trim().Contains(search.Trim().ToLower())).ToList();

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
            var product = _productService.GetAllProducts().Where(x=>x.Id==id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            try
            {
              var products  =  _productService.GetAllProducts().Where(x => x.Id == model.Id).FirstOrDefault();
              if(products!=null)
                {
                    products.Name = model.Name;
                }
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
           _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
