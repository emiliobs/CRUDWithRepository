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
            try
            {
                var products = await _unitOfWork.ProductRepository.GetProducts();
                return View(products);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Add(product);
                    await _unitOfWork.SaveAsync();

                    TempData["successMessage"] = "Product has been Created.";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model state is Invalid.";
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
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
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return View(product);
                }

                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Update(product);
                    await _unitOfWork.SaveAsync();

                    TempData["successMessage"] = "Product has been Update.";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model State is Invalid.";
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
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
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
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
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return View(product);
                }

                if (ModelState.IsValid)
                {
                    await _unitOfWork.ProductRepository.Delete(id);
                    await _unitOfWork.SaveAsync();

                    TempData["successMessage"] = "Product has been Delete.";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model State is Invalid.";
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(product);
        }
    }
}