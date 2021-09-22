using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroPaciente
{
    public partial class cadastro : Form
    {
        List<Pessoa> pessoas;
        public cadastro()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();
        }

        private void cadastro_Load(object sender, EventArgs e)
        {

        }

        private void botao1_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(pessoa);
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome.");
                txtNome.Focus();
                return;
            }

            if (txtTelefone.Text == "")
            {
                MessageBox.Show("Preencha o campo telefone.");
                txtTelefone.Focus();
                return;
            }

            if (txtCPF.Text == "")
            {
                MessageBox.Show("Preencha o campo cpf.");
                txtCPF.Focus();
                return;
            }

            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'N';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.Data = txtData.Text;
            p.CPF = txtCPF.Text;
            p.Telefone = txtTelefone.Text;
            p.Email = txtEmail.Text;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            botao2_Click(botao2, EventArgs.Empty);

            Listar();
        }

        private void botao2_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            radioM.Checked = true;
            radioF.Checked = false;
            radioN.Checked = false;
            txtNome.Focus();
        }

        private void Listar()
        {
            Lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);
            }
        }

        private void botao3_Click(object sender, EventArgs e)
        {
            int indice = Lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();
        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text = p.Nome;
            txtData.Text = p.Data;
            txtCPF.Text = p.CPF;
            txtTelefone.Text = p.Telefone;
            txtEmail.Text = p.Email;
            
            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioN.Checked = true;
                    break;
            }
        }
    }
}
