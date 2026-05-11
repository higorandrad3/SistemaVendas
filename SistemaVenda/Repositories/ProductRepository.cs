using Microsoft.EntityFrameworkCore;
using SistemaVenda.Context;
using SistemaVenda.Dto;
using SistemaVenda.Models;
using SistemaVenda.Repositories.Interfaces;

namespace SistemaVenda.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Product product)
        {
            await _context.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

            _context.Products.Remove(product);
        }

        public async Task<List<Product>> GetAllActive()
        {
            return await _context.Products.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

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

        public async Task<List<Product>> GetProductsFromIdsAsync(List<int> ids)
        {
            var res = await _context.Products
                .AsNoTracking()
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();

            return res;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product productModified)
        {
            _context.Products.Update(productModified);

            await SaveAsync();
        }
    }
}
