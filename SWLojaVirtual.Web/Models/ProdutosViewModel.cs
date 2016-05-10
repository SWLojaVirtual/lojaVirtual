using SWLojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace SWLojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
    }
}