using DotNetCorePractical.Domain;
using DotNetCorePractical.Interface.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePractical.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DotNetCorePracticalContext context) : base(context)
        {

        }

        public List<SelectListItem> Categorylist()
        {
            var categoryList = new List<SelectListItem>();
            foreach (var category in context.Category.ToList())
            {
                categoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            return categoryList;
        }
    }
}
