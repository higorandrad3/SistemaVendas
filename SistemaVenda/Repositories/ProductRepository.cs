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
            var res = await _context.Products
                .AsNoTracking()
                .Where(p => p.Name.Contains(term))
                .Select(p => new ProductDto
                (
                    p.Id,
                    p.Name,
                    p.SalePrice
                ))
                .ToListAsync();

            return res;
        }

        public Task<List<ProductDto>> GetProductsFromIdsAsync(List<int> ids)
        {
            _context.Products
                .AsNoTracking()
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }
    }
}
