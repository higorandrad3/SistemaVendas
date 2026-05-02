using SistemaVenda.Dto;
using SistemaVenda.Models;

namespace SistemaVenda.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsByTermAsync(string term);
        Task<List<Product>> GetProductsFromIdsAsync(List<int> id);

        void Popula();
    }
}
