using SistemaVenda.Dto;

namespace SistemaVenda.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsByTermAsync(string term);
        Task<List<ProductDto>> GetProductsFromIdsAsync(int id);
    }
}
