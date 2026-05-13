using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int SKU { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public List<Batch>? Batchs { get; set; }

        // Relacionamento Muitos-para-Muitos ou Um-para-Muitos
        //public virtual List<Category> Categories { get; set; } = new List<Category>();
    }
}
