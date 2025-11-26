using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel?> GetByIdAsync(Guid id);
        Task<CategoryViewModel> CreateAsync(CategoryViewModel vm);
        Task<bool> UpdateAsync(CategoryViewModel vm);
        Task<bool> DeleteAsync(Guid id);
    }
}
