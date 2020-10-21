using DotNetCorePractical.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractical.Interface.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        List<SelectListItem> Categorylist();
    }
}
