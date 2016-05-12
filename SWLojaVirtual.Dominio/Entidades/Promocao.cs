using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWLojaVirtual.Dominio.Entidades
{
    public class Promocao
    {
        [Key]
        public int IdPromocao { get; set; }
        public string Descricao { get; set; }
        public int Bonus { get; set; }
    }
}
