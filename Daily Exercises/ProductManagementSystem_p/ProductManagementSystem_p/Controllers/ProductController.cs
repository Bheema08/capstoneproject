
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem_p.Data;
using ProductManagementSystem_p.Models;
using System.Linq;
using System.Security;

namespace ProductManagementSystem_p.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            ViewBag.Success = TempData["Success"];
            ViewBag.Error = TempData["Error"];
            // change code
            return View(_context.Products.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct() => View();

        [HttpPost, Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["Success"] = $"Product \"{product.Name}\" has been successfully created!";// change code
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost, Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                TempData["Success"] = $"Product \"{product.Name}\" has been successfully updated!";
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Success"] = $"Product \"{product.Name}\" has been successfully deleted!";
            }
            return RedirectToAction("ProductList");
        }
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteProductManger(int id)
        {
            TempData["Error"] = "Access Denied: You do not have permission to delete products.";
            return RedirectToAction("ProductList");
        }
    }
}
