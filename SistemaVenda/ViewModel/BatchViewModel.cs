using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.ViewModel
{
    public class BatchViewModel
    {
        [Required(ErrorMessage = "Lote obrigatório")]
        public string BatchId { get; set; }

        [StringLength(50)]
        public string? Brand { get; set; }

        public int SKU { get; set; } = 1;

        [Required(ErrorMessage = "Quantidade obrigatório")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Preço de venda obrigatório")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "Preço de compra obrigatório")]
        public decimal? PurchasePrice { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Data de validade obrigatório")]
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
