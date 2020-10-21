using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCorePractical.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePractical.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            var categories = _uow.CategoryRepository.Get().ToList();
            return View(categories);
        }
    }
}
