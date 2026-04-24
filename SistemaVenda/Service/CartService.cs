using SistemaVenda.Models;

namespace SistemaVenda.Service
{
    public static class CartService
    {
        private static List<Product> ProductsInCart = new List<Product>();


        public static void AddProduct(Product product) => ProductsInCart.Add(product);

        public static List<Product> GetProductsInCart() => ProductsInCart;
    }
}
