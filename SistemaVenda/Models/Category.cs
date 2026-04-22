using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // Propriedade de Navegação: Uma categoria tem muitos produtos
        //public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
