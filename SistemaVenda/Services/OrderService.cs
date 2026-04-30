using SistemaVenda.Dto;
using SistemaVenda.Models;
using SistemaVenda.Repositories.Interfaces;

namespace SistemaVenda.Services
{
    public class OrderService
    {
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository) => _productRepository = productRepository;
        public async Task<Order> CreateOrderAsync(List<ProductSoldDto> productsSold)
        {
            var productsIds = new List<int>();

            productsSold.ForEach(p => productsIds.Add(p.id));

            var products = await _productRepository.GetProductsFromIdsAsync(productsIds);

            decimal totalPrice = 0;

            foreach (var item in productsSold)
            {
                totalPrice += item.quantity * products.Find(p => item.id == p.id).salePrice;
            }

            var order = new Order()
            {
                Id = productsIds[0],
                OrderValue = totalPrice,
                PaymentMethod = "pix"
            };

            return order;
        }
    }
}
