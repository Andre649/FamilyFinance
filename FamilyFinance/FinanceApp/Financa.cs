using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class Financa
    {
        public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public required string Tipo { get; set; } // Receita ou Despesa
    public required string Categoria { get; set; } // Ex.: Alimentação, Transporte, etc.
        
    }
}