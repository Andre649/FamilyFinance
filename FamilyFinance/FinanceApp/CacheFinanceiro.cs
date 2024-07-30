using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceApp
{
    public class CacheFinanceiro
    {
        private List<Financa> financas = new List<Financa>();

        public void AdicionarFinanca(Financa financa)
        {
            financas.Add(financa);
        }

        public List<Financa> ObterFinancasPorMes(int mes, int ano)
        {
            return financas.Where(f => f.Data.Month == mes && f.Data.Year == ano).ToList();
        }

        public RelatorioMensal GerarRelatorioMensal(int mes, int ano)
        {
            var financasDoMes = ObterFinancasPorMes(mes, ano);
            return new RelatorioMensal
            {
                MesAno = new DateTime(ano, mes, 1),
                Financa = financasDoMes
            };
        }
    }
}
