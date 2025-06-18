using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProvaWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [MinLength(2, ErrorMessage = "O minimo de caracteres é 2")]
        public string Nome { get; set; }

        [DisplayName("Categoria")]
        [MinLength(2, ErrorMessage = "O minimo de caracteres é 2")]
        public string Categoria { get; set; }

        [DisplayName("Preço")] 
        [Precision(18, 2)]
        public decimal Preco { get; set; }

        [DisplayName("Quantidade em estoque")]
        public int QuantidadeEmEstoque { get; set; }
    }
}
