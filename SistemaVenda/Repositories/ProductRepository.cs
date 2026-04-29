using Microsoft.EntityFrameworkCore;
using SistemaVenda.Context;
using SistemaVenda.Dto;
using SistemaVenda.Repositories.Interfaces;

namespace SistemaVenda.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<List<ProductDto>> GetProductsByTermAsync(string term)
        {
            var products = Repository.GetProducts();

            var res = await _context.Products
                .Where(p => p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .Select(p => new ProductDto
                (
                    p.Id,
                    p.Name,
                    p.SalePrice
                ))
                .ToListAsync();

            return res;
        }

        public Task<List<ProductDto>> GetProductsFromIdsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
