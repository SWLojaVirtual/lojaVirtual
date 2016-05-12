using SWLojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWLojaVirtual.Dominio.Repositório
{
    public class PromocoesRepositorio
    {
        private readonly DBContext _context = new DBContext();

        public IEnumerable<Promocao> Promocoes
        {
            get { return _context.Promocoes; }
        }
    }
}
