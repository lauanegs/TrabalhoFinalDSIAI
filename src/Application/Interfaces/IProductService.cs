using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel?> GetByIdAsync(Guid id);
        Task<ProductViewModel> CreateAsync(ProductViewModel vm);
        Task<bool> UpdateAsync(ProductViewModel vm);
        Task<bool> DeleteAsync(Guid id);
    }
}