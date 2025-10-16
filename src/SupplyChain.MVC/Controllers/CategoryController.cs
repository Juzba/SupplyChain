using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Core.Entities;
using SupplyChain.Infrastructure.Repositories;

namespace SupplyChain.MVC.Controllers
{
    public class CategoryController(IRepository<Category> repository) : Controller
    {
        private readonly IRepository<Category> _repository = repository;


        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var result = await _repository.FirstOrDefaultAsync(p => p.Id == id);
            if (result == null) return NotFound();

            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var result = await _repository.FirstOrDefaultAsync(p => p.Id == id);
            if (result == null) return NotFound();

            return View(result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            if (id != category.Id) return NotFound();
            if (!ModelState.IsValid) return View(category);

            try
            {
                _repository.Update(category);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(category.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _repository.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _repository.FindAsync(id);
            if (result != null)
            {
                _repository.Remove(result);
            }
            await _repository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _repository.AnyAsync(e => e.Id == id);
        }
    }
}
