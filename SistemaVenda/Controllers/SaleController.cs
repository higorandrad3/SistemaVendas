using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using SistemaVenda.Repositories.Interfaces;
using SistemaVenda.Services;

namespace SistemaVenda.Controllers
{
    public class SaleController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly OrderService _orderService;

        public SaleController(IProductRepository productRepository, OrderService orderService)
        {
            _productRepository = productRepository;
            _orderService = orderService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string term)
        {
            var res = await _productRepository.GetProductsByTermAsync(term);

            return Json(res);
        }

        [HttpGet]
        public IActionResult Summary(Order order)
        {
            return View(order);
        }
    }
}
