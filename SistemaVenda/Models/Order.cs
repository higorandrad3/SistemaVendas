namespace SistemaVenda.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal OrderValue { get; set; }
        public string PaymentMethod { get; set; }
    }
}
