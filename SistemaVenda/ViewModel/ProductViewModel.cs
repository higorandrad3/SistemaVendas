using SistemaVenda.Models;
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

        [Required(ErrorMessage = "O SKU é obrigatório.")]
        public int? SKU { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public List<Batch>? Batchs { get; set; }
    }
}
