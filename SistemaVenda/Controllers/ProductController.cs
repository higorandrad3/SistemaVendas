using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using SistemaVenda.Repositories.Interfaces;
using SistemaVenda.ViewModel;

namespace SistemaVenda.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _autoMapper;
        public ProductController(IProductRepository productRepository, IMapper autoMapper)
        {
            _productRepository = productRepository;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productVM)
        {
            if (!ModelState.IsValid)
                return View(productVM);

            var product = _autoMapper.Map<Product>(productVM);

            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var product = _productRepository.GetByIdAsync(id);

        //    if (product is null)
        //        return NotFound();

        //    var productVM = _autoMapper.Map<ProductViewModel>(product);

        //    return View(productVM);
        //}

        //[HttpDelete("{id:int:min(1)}")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] ProductViewModel productVM)
        //{
        //    if (id <= 0)
        //        return NotFound("ID invalido!");

        //    if (id != productVM.Id)
        //        return BadRequest("ID diferente.");

        //    await _productRepository.DeleteAsync(id);

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return View();

            var productVM = _autoMapper.Map<ProductViewModel>(product);

            return View(productVM);
        }

        [HttpPost("{id:int}")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, ProductViewModel productVM)
        {
            if (id != productVM.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(productVM);

            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            product = _autoMapper.Map<Product>(productVM);

            await _productRepository.UpdateAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
