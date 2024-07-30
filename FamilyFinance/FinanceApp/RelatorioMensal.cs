using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class RelatorioMensal
    {
        public DateTime MesAno { get; set; }
    public required List<Financa> Financa { get; set; }
    public decimal TotalReceitas => Financa.Where(f => f.Tipo == "Receita").Sum(f => f.Valor);
    public decimal TotalDespesas => Financa.Where(f => f.Tipo == "Despesa").Sum(f => f.Valor);
    public decimal Saldo => TotalReceitas - TotalDespesas;
        
        
    }
}