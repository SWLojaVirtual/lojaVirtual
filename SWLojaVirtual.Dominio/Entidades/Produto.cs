

using System.ComponentModel.DataAnnotations;

namespace SWLojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
