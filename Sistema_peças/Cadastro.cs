using Sistema_peças.Controller;
using Sistema_peças.Model;
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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_menu_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capturar os dados
            string nome, fabricante, tipoVeiculo, categoria;
            decimal precoCompra, precoVenda;
            int quantidade;

            try
            {
                // Validação básica
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtFabricante.Text) ||
                    string.IsNullOrWhiteSpace(txtTipoVeiculo.Text) ||
                    string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos!");
                    return;
                }

                // Captura dos valores numéricos com validação
                precoCompra = decimal.Parse(txtPrecoCompra.Text);
                precoVenda = decimal.Parse(txtPrecoVenda.Text);
                quantidade = int.Parse(txtQuantidade.Text);

                if (precoCompra <= 0 || precoVenda <= 0 || quantidade < 0)
                {
                    MessageBox.Show("Valores inválidos nos campos numéricos.");
                    return;
                }

                // Captura dos valores textuais
                nome = txtNome.Text;
                fabricante = txtFabricante.Text;
                tipoVeiculo = txtTipoVeiculo.Text;
                categoria = txtCategoria.Text;
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro ao converter valores. Certifique-se de que todos os campos estão corretos.");
                return;
            }

            // Criar uma nova peça
            var peca = new Peça
            {
                Nome = nome,
                Fabricante = fabricante,
                TipoVeiculo = tipoVeiculo,
                Categoria = categoria,
                PrecoCompra = precoCompra,
                PrecoVenda = precoVenda,
                Quantidade = quantidade,
                Status = "Ativo"
            };

            try
            {
                // Instanciar o controlador e salvar no banco
                var controller = new PeçaController();
                var sucesso = controller.CadastrarPeça(peca);

                // Mostrar uma mensagem ao usuário
                if (sucesso)
                    MessageBox.Show("Peça cadastrada com sucesso!");
                else
                    MessageBox.Show("Erro ao cadastrar a peça.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void Nome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
