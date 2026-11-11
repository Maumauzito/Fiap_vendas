using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Vendas.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade do produto deve ser um valor válido")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "A categoria do produto é obrigatória")]
        public string Categoria { get; set; } = string.Empty;

    }
}
