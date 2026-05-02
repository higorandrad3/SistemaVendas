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

        public void Popula()
        {
            var products = new List<Product>() {
            new Product(){
            Id = 1,
            Name = "Baton",
            Description = "Baton para labios",
            Brand = "Natura",
            ExpirationDate = DateTime.Now,
            ManufacturingDate = DateTime.Now,
            ImageUrl = "",
            IsActive = true,
            SalePrice = 25.50m,
            PurchasePrice = 0,
            SKU = 1,
            StockQuantity = 100
            },

            new Product(){
            Id = 2,
            Name = "Perfume Homem coragio",
            Description = "PErfume para labios",
            Brand = "O Boticario",
            ExpirationDate = DateTime.Now,
            ManufacturingDate = DateTime.Now,
            ImageUrl = "",
            IsActive = true,
            SalePrice = 250.50m,
            PurchasePrice = 0,
            SKU = 1,
            StockQuantity = 50
            }
            };

            _context.AddRange(products);
            _context.SaveChanges();
            
        }
    }
}
