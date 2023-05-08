using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sistema_De_Pedidos.Models;
using Sistema_De_Pedidos.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sistema_De_Pedidos.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModel> products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            ProductModel product = _productRepository.ListByGuid(id);
            return View(product);
        }
        public IActionResult DeleteConfirm(Guid id)
        {
            ProductModel product = _productRepository.ListByGuid(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id) {
            _productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }
    }
}
