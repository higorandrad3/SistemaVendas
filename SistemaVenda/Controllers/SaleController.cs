using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaVenda.Context;
using SistemaVenda.Dto;
using SistemaVenda.Models;
using SistemaVenda.Service;

namespace SistemaVenda.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProductByName(string term)
        {
            var products = Repository.GetProducts();

            var res = products.Select(p => new {
                p.Id,
                p.Name,
                p.SalePrice
            })
            .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
            .ToList();
            
            return Json(res);
        }

        [HttpPost]
        public IActionResult FinalizeSale([FromBody] List<ProductSoldDto> productsSoldDto)
        {
            if (productsSoldDto is null)
                return View("Create");

            List<Product> productsSold = new List<Product>(); 

            foreach(var productSold in productsSoldDto)
            {
                var product = Repository.GetProducts().Find(p => p.Id == productSold.id);

                if (product is null)
                    return BadRequest("Produto não encontrado");

                productsSold.Add(product);
            }

            productsSold.ForEach(p => Console.WriteLine(p.Name));

            return Redirect("Create");
        }
    }
}
