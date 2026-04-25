using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Context;
using SistemaVenda.Dto;
using SistemaVenda.Service;

namespace SistemaVenda.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateCart([FromBody] int id)
        {
            var product = Repository.GetProducts().FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            CartService.AddProduct(product);

            return Ok();
        }

        [HttpPost]
        public PartialViewResult GetProductsInCart([FromBody] List<ProductDto> products)
        {
            return PartialView("_ListPartial", products);
        }

        public IActionResult GetProductByName(string termo)
        {
            var products = Repository.GetProducts();

            var res = products.Where(p => p.Name.StartsWith(termo, StringComparison.OrdinalIgnoreCase)).ToList();
            
            return Json(res);
        }
    }
}
