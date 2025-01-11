using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_peças.Model
{
    internal class Vendas
    {
        public virtual int Id { get; set; }
        public virtual int PecaId { get; set; }
        public virtual int QuantidadeVendida { get; set; }
        public virtual decimal ValorVenda { get; set; }
        public virtual DateTime DataVenda { get; set; }
    }
}
