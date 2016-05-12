

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWLojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public int quantidade { get; set; }

        [DisplayName("Promoção")]
        public int IdPromocao { get; set; }
        [ForeignKey("IdPromocao")]
        public virtual Promocao Promocao { get; set; }
    }
}
