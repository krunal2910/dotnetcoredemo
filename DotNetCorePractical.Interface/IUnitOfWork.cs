using DotNetCorePractical.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractical.Interface
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }
    }
}
