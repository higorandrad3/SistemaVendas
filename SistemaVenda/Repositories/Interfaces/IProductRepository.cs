using SistemaVenda.Dto;
using SistemaVenda.Models;

namespace SistemaVenda.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsByTermAsync(string term);
        Task<List<Product>> GetProductsFromIdsAsync(List<int> id);
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SaveAsync();
    }
}
