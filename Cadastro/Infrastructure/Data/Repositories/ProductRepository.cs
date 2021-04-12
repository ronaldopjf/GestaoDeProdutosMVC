using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Infrastructure.Data.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(RegisterContext dbContext) : base(dbContext)
        {

        }

        public override IEnumerable<Product> GetAll()
        {
            return _dbContext.Set<Product>().Include(p => p.Client).ToList();
        }
    }
}
