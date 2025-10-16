using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Core.Entities;
using SupplyChain.Infrastructure.Repositories;

namespace SupplyChain.MVC.Controllers;

[Authorize]
public class ProductController(IRepository<Product> repository) : Controller
{
    private readonly IRepository<Product> _repository = repository;


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
    public async Task<IActionResult> Create([Bind("Id,SKU,Name,CategoryId,UnitPrice,MinStockLevel,IsActive,BarCode,Weight,Unit")] Product product)
    {
        if (!ModelState.IsValid) return View(product);

        await _repository.AddAsync(product);
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
    public async Task<IActionResult> Edit(int id, [Bind("Id,SKU,Name,CategoryId,UnitPrice,MinStockLevel,IsActive,BarCode,Weight,Unit")] Product product)
    {
        if (id != product.Id) return NotFound();
        if (!ModelState.IsValid) return View(product);

        try
        {
            _repository.Update(product);
            await _repository.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CategoryExists(product.Id)) return NotFound();
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

