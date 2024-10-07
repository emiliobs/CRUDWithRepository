﻿using CRUDWithRepository.Models;
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
    }
}