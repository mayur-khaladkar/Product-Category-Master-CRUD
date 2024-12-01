using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategory.Models;
using System.Linq;

namespace ProductCategory.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCategoryContext _context;

        public ProductController(ProductCategoryContext context)
        {
            _context = context;
        }

        // GET: Product/Index
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    _context.Entry(existingProduct).CurrentValues.SetValues(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }


        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

