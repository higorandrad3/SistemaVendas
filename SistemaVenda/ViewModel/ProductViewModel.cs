using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "O SKU é obrigatório.")]
        public int? SKU { get; set; }

        [Required(ErrorMessage = "A quantidade é orbigatória.")]
        public int? StockQuantity { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public decimal? SalePrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        public DateTime? ExpirationDate { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
