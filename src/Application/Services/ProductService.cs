using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Infrastructure.Repositories;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, ICategoryRepository categoryRepo, IMapper mapper)
        {
            _repo = repo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Adapt<IEnumerable<ProductViewModel>>();
        }

        public async Task<ProductViewModel?> GetByIdAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product?.Adapt<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateAsync(ProductViewModel vm)
        {
            var entity = vm.Adapt<Product>();
            await _repo.AddAsync(entity);
            return entity.Adapt<ProductViewModel>();
        }

        public async Task<bool> UpdateAsync(ProductViewModel vm)
        {
            var entity = await _repo.GetByIdAsync(vm.Id);
            if (entity == null) return false;

            _mapper.Map(vm, entity);

            await _repo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            await _repo.RemoveAsync(product);
            return true;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
