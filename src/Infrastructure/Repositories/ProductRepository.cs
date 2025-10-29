using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _ctx;
        public ProductRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Product p)
        {
            await _ctx.Products.AddAsync(p);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _ctx.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _ctx.Products.FindAsync(id);
        }

        public async Task RemoveAsync(Product p)
        {
            _ctx.Products.Remove(p);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product p)
        {
            _ctx.Products.Update(p);
            await _ctx.SaveChangesAsync();
        }
    }
}