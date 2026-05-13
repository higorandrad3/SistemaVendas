using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenda.Models
{
    public class Batch
    {
        [Key]
        public string BatchId { get; set; }

        [StringLength(50)]
        public string? Brand { get; set; }

        [Required]
        public int SKU { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public Product Product { get; set; }
    }
}
