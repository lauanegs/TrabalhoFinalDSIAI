using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    // Simple service that uses the DbContext via repository for CRUD.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProductViewModel> CreateAsync(ProductViewModel vm)
        {
            var entity = new Product
            {
                Name = vm.Name,
                Quantity = vm.Quantity,
                Description = vm.Description,
                Price = vm.Price
            };
            await _repo.AddAsync(entity);
            return Map(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var found = await _repo.GetByIdAsync(id);
            if (found == null) return false;
            await _repo.RemoveAsync(found);
            return true;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(Map);
        }

        public async Task<ProductViewModel?> GetByIdAsync(Guid id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : Map(p);
        }

        public async Task<bool> UpdateAsync(ProductViewModel vm)
        {
            var p = await _repo.GetByIdAsync(vm.Id);
            if (p == null) return false;
            p.Name = vm.Name;
            p.Quantity = vm.Quantity;
            p.Description = vm.Description;
            p.Price = vm.Price;
            await _repo.UpdateAsync(p);
            return true;
        }

        private static ProductViewModel Map(Product p) => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Quantity = p.Quantity,
            Description = p.Description,
            Price = p.Price
        };
    }
}