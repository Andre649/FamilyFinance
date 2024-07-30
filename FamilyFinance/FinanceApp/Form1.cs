using System;
using System.Linq;
using System.Windows.Forms;

namespace FinanceApp
{
    public partial class Form1 : Form
    {
        private CacheFinanceiro cache = new CacheFinanceiro();

        public Form1()
        {
            InitializeComponent();

            // Inicialize os componentes do formulário
            this.Text = "Controle Financeiro";
            this.Size = new System.Drawing.Size(800, 600);

            // TextBox para Valor
            TextBox txtValor = new TextBox() { Top = 20, Left = 20, Width = 200 };
            this.Controls.Add(txtValor);

            // TextBox para Data
            TextBox txtData = new TextBox() { Top = 60, Left = 20, Width = 200 };
            this.Controls.Add(txtData);

            // ComboBox para Tipo
            ComboBox cmbTipo = new ComboBox() { Top = 100, Left = 20, Width = 200 };
            cmbTipo.Items.AddRange(new string[] { "Receita", "Despesa" });
            this.Controls.Add(cmbTipo);

            // TextBox para Categoria
            TextBox txtCategoria = new TextBox() { Top = 140, Left = 20, Width = 200 };
            this.Controls.Add(txtCategoria);

            // Botão para Adicionar
            Button btnAdicionar = new Button() { Text = "Adicionar", Top = 180, Left = 20 };
            btnAdicionar.Click += (sender, e) => {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var financa = new Financa
                {
                    Data = DateTime.Parse(txtData.Text),
                    Valor = decimal.Parse(txtValor.Text),
                    Tipo = cmbTipo.SelectedItem.ToString(),
                    Categoria = txtCategoria.Text
                };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                cache.AdicionarFinanca(financa);
                MessageBox.Show("Finança adicionada com sucesso!");
            };
            this.Controls.Add(btnAdicionar);

            // Botão para Gerar Relatório
            Button btnGerarRelatorio = new Button() { Text = "Gerar Relatório", Top = 220, Left = 20 };
            btnGerarRelatorio.Click += (sender, e) => {
                int mes = int.Parse(txtMes.Text);
                int ano = int.Parse(txtAno.Text);

                var relatorio = cache.GerarRelatorioMensal(mes, ano);
                dataGridViewRelatorio.DataSource = relatorio.Financa;
            };
            this.Controls.Add(btnGerarRelatorio);

            // DataGridView para exibir o relatório
            DataGridView dataGridViewRelatorio = new DataGridView() { Top = 260, Left = 20, Width = 740, Height = 300 };
            this.Controls.Add(dataGridViewRelatorio);
        }
    }
}
