using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _svc;

        public CategoryController(ICategoryService svc)
        {
            _svc = svc;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _svc.GetAllAsync();
            return View(list);
        }

        public IActionResult Create() => View(new CategoryViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            await _svc.CreateAsync(vm);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var vm = await _svc.GetByIdAsync(id);
            if (vm == null)
                return NotFound();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var ok = await _svc.UpdateAsync(vm);
            if (!ok)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var vm = await _svc.GetByIdAsync(id);
            if (vm == null)
                return NotFound();
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
            if (vm == null)
                return NotFound();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string term)
        {
            var result = await _svc.GetAllAsync();

            if (!string.IsNullOrEmpty(term))
                result = result.Where(c =>
                    c.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                );

            return PartialView("_CategoryTablePartial", result);
        }
    }
}
