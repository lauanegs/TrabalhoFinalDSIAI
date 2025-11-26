using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _svc;

        public ProductController(IProductService svc)
        {
            _svc = svc;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _svc.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new ProductViewModel();
            await PopulateCategoriesSelectList(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesSelectList(vm);
                return View(vm);
            }

            await _svc.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var vm = await _svc.GetByIdAsync(id);
            if (vm == null) return NotFound();

            await PopulateCategoriesSelectList(vm);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesSelectList(vm);
                return View(vm);
            }

            var ok = await _svc.UpdateAsync(vm);
            if (!ok) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var vm = await _svc.GetByIdAsync(id);
            if (vm == null) return NotFound();

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _svc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var vm = await _svc.GetByIdAsync(id);
            if (vm == null) return NotFound();

            return View(vm);
        }

        private async Task PopulateCategoriesSelectList(ProductViewModel vm)
        {
            var categories = await _svc.GetCategoriesAsync(); 
            vm.Categories = categories.ToList();
            ViewBag.CategoriesSelectList = categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = c.Id == vm.CategoryId
                })
                .ToList();
        }
    }
}
