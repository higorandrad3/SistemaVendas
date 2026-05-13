using SistemaVenda.Repositories.Interfaces;

namespace SistemaVenda.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository) => _productRepository = productRepository;
    }
}
