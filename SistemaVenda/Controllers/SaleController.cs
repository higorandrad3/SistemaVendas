using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
