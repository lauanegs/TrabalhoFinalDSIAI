using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Infrastructure.Repositories;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Adapt<IEnumerable<CategoryViewModel>>();
        }

        public async Task<CategoryViewModel?> GetByIdAsync(Guid id)
        {
            var c = await _repo.GetByIdAsync(id);
            return c?.Adapt<CategoryViewModel>();
        }

        public async Task<CategoryViewModel> CreateAsync(CategoryViewModel vm)
        {
            var entity = vm.Adapt<Category>();
            await _repo.AddAsync(entity);
            return entity.Adapt<CategoryViewModel>();
        }

        public async Task<bool> UpdateAsync(CategoryViewModel vm)
        {
            var entity = await _repo.GetByIdAsync(vm.Id);
            if (entity == null) return false;

            _mapper.Map(vm, entity);

            await _repo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cat = await _repo.GetByIdAsync(id);
            if (cat == null) return false;

            await _repo.RemoveAsync(cat);
            return true;
        }
    }
}
