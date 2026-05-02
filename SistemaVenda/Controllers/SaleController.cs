using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Dto;
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

        [HttpPost]
        public async Task<IActionResult> FinalizeSale([FromBody] List<ProductSoldDto> productsSoldDto)
        {
            if (productsSoldDto is null)
                return BadRequest("O carrinho de produto está vazia!");

            var order = await _orderService.CreateOrderAsync(productsSoldDto);

            return RedirectToAction("Summary", order);
        }

        [HttpGet]
        public IActionResult Summary(Order order)
        {
            return View(order);
        }
    }
}
