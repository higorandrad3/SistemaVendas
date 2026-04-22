using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Context;

namespace SistemaVenda.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetProductsInCart()
        {
            return PartialView("_ListPartial", Repository.GetProducts());
        }

        public IActionResult GetProductByName(string termo)
        {
            var products = Repository.GetProducts();

            var res = products.Where(p => p.Name.StartsWith(termo, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!res.Any())
                Console.WriteLine("é null");
            return Json(res);
        }
    }
}
