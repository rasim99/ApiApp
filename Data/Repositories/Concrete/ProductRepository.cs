

using Core.Entities;
using Data.Contexts;
using Data.Repositores.Base;
using Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Concrete
{
    public class ProductRepository : BaseRepistory<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return  await _context.Products.FirstOrDefaultAsync(p => p.Name == name); 
        }
    }
}
