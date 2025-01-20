using Sistema_peças.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_peças
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_pesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura os valores dos campos de texto
                int? id = null;
                if (int.TryParse(txtID_consulta.Text, out int parsedId))
                    id = parsedId;

                string nome = txtNome_consulta.Text;

                // Valida se ao menos um dos campos foi preenchido
                if (!id.HasValue && string.IsNullOrWhiteSpace(nome))
                {
                    MessageBox.Show("Informe o ID ou o Nome para pesquisar.");
                    return;
                }

                // Instancia o controlador e faz a pesquisa
                var controller = new PecaController();
                var resultados = controller.PesquisarPeça(id, nome);

                // Exibe os resultados
                if (resultados.Any())
                {
                    // Preencher o DataGridView com os resultados
                    dataGridView1.DataSource = resultados;

                    // Opcional: ajustar a exibição das colunas
                    dataGridView1.Columns["Id"].HeaderText = "ID";
                    dataGridView1.Columns["Nome"].HeaderText = "Nome";
                    dataGridView1.Columns["Quantidade"].HeaderText = "Quantidade";
                }
                else
                {
                    MessageBox.Show("Nenhuma peça encontrada com os critérios informados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar a pesquisa: {ex.Message}");
            }
        }
    }
}
