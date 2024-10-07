using CRUDWithRepository.Models;
using CRUDWithRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithRepository.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductRepository.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var product = await _unitOfWork.ProductRepository.GetProductById(id);
            if (product == null)
            {
                return View();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return View(product);
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var product = await _unitOfWork.ProductRepository.GetProductById(id);
            if (product == null)
            {
                return View();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var product = await _unitOfWork.ProductRepository.GetProductById(id);
            if (product == null)
            {
                return View();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, Product product)
        {
            if (id != product.Id)
            {
                return View(product);
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepository.Delete(id);
                await _unitOfWork.SaveAsync();

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}