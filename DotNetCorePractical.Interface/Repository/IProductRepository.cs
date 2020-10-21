using DotNetCorePractical.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractical.Interface.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
