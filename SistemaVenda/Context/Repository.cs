using SistemaVenda.Models;

namespace SistemaVenda.Context
{
    public static class Repository
    {
        private static List<Product> Products = new List<Product>() {
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

        public static List<Product> GetProducts() => Products;

        public static void AddProduct(Product product) => Products.Add(product);
    }
}
