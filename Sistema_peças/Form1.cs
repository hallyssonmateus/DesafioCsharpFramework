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
    public partial class btn_cad_peças : Form
    {
        public btn_cad_peças()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastro frm = new Cadastro();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta frm = new Consulta();
            frm.Show();
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Excluir frm = new Excluir();
            frm.Show();
        }

        private void btn_vendas_Click(object sender, EventArgs e)
        {
            Vendas frm = new Vendas();
            frm.Show();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            Edicao frm = new Edicao();
            frm.Show();
        }
    }
}
