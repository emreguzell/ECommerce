using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductController (ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = dbContext.Products.ToList();
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id) 
        {
        if (id == null)
            {
                return NotFound();
            }

            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Price,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int? id [Bind("Id,Name,Price;CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbContext.Update(product);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Post: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = dbContext.Products.Find(id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }

    }
}
