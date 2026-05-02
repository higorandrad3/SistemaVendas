using SistemaVenda.Dto;
using SistemaVenda.Models;
using SistemaVenda.Repositories.Interfaces;

namespace SistemaVenda.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository) => _productRepository = productRepository;
        public async Task<Order> CreateOrderAsync(List<ProductSoldDto> productsSoldDto)
        {
            var productsSold = await _productRepository.GetProductsFromIdsAsync(
                    productsSoldDto
                    .Select(p => p.id)
                    .ToList()
                    );
            productsSold.Select(p => new Order
            {
                Products = productsSold,

            });

            var totalPrice = productsSold.Sum(p => p.SalePrice * productsSoldDto.Find(x => x.id == p.Id).quantity);

            var generate = new Random();
            var order = new Order()
            {
                Id = generate.Next(),
                Products = productsSold,
                OrderValue = totalPrice,
                PaymentMethod = "pix"
            };

            return order;
        }
    }
}
