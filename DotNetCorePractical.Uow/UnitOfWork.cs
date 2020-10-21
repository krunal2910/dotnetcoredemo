using DotNetCorePractical.Domain;
using DotNetCorePractical.Interface;
using DotNetCorePractical.Interface.Repository;
using DotNetCorePractical.Repository;
using System;

namespace DotNetCorePractical.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DotNetCorePracticalContext _context = null;
        public UnitOfWork(DotNetCorePracticalContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);

            CategoryRepository = new CategoryRepository(_context);
        }

        public IProductRepository ProductRepository { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }
    }
}
