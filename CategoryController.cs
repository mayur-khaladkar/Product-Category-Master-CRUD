using Microsoft.AspNetCore.Mvc;
using ProductCategory.Models;
using System.Linq;

namespace ProductCategory.Controllers
{
    public class CategoryController : Controller
	{
		private readonly ProductCategoryContext _context;

		public CategoryController(ProductCategoryContext context)
		{
			_context = context;
		}

		// GET: Category/Index
		public IActionResult Index()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
		}

		// GET: Category/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Category/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_context.Categories.Add(category);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		// GET: Category/Edit/5
		public IActionResult Edit(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
      
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _context.Categories.Find(category.CategoryId);
                if (existingCategory != null)
                {
                    _context.Entry(existingCategory).CurrentValues.SetValues(category);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }





        // GET: Category/Delete/5
        public IActionResult Delete(int id)
		{
			var category = _context.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		// POST: Category/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var category = _context.Categories.Find(id);
			_context.Categories.Remove(category);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
