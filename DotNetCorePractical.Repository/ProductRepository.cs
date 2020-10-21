using DotNetCorePractical.Domain;
using DotNetCorePractical.Interface.Repository;
using System;

namespace DotNetCorePractical.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DotNetCorePracticalContext context) : base(context)
        {

        }
    }
}
