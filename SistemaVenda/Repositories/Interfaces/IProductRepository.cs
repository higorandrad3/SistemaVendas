using SistemaVenda.Dto;
using SistemaVenda.Models;

namespace SistemaVenda.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsByTermAsync(string term);
        Task<List<Product>> GetProductsFromIdsAsync(List<int> id);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdWithBatchs(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllActive();
        Task<Product> GetNameById(int id);
        Task AddAsync(Product product);
        Task AddBatchAsync(Batch batch);
        Task DeleteAsync(int id);
        Task UpdateAsync(Product product);
        Task SaveAsync();
    }
}
