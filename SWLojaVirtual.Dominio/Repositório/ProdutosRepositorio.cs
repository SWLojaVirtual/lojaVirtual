using SWLojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWLojaVirtual.Dominio.Repositório
{
    public class ProdutosRepositorio
    {
        private readonly DBContext _context = new DBContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Produto>().ToTable("Produto");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
