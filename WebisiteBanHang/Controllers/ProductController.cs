using Microsoft.AspNetCore.Mvc;
using WebisiteBanHang.Repositories;
using WebisiteBanHang.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebisiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Display(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    product.ImageUrl = SaveImage(Image);
                }
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name");
            return View(product);
        }

        public IActionResult Update(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    product.ImageUrl = SaveImage(Image);
                }
                _productRepository.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        private string SaveImage(IFormFile image)
        {
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return "/images/" + image.FileName;
        }
    }
}