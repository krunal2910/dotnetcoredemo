using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCorePractical.Domain;
using DotNetCorePractical.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePractical.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            var products = _uow.ProductRepository.Get().ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult ProductList(string search = "")
        {
            var products = new List<Product>();
            if (string.IsNullOrEmpty(search))
            {
                products = _uow.ProductRepository.Get().ToList();
            }
            else
            {
                products = _uow.ProductRepository.Get().Where(x => x.Name.Contains(search)).ToList();
            }
            return PartialView("ProductList", products);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new Product();
            var product = _uow.ProductRepository.GetByID(id);
            if (product != null)
            {
                model.Name = product.Name;
                model.Id = product.Id;
                model.Price = product.Price;
                model.CategoryId = product.CategoryId;
            }
            ViewBag.CategoryList = _uow.CategoryRepository.Categorylist();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (model.Id > 0)
            {
                _uow.ProductRepository.Update(model);
            }
            else
            {
                _uow.ProductRepository.Insert(model);
            }
            _uow.ProductRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _uow.ProductRepository.GetByID(id);
            if (product != null)
            {
                _uow.ProductRepository.Delete(product);
                _uow.ProductRepository.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
