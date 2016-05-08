using System.Data.Entity;
using SWLojaVirtual.Dominio.Entidades;

namespace SWLojaVirtual.Dominio.Repositório
{
    public class DBContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}
