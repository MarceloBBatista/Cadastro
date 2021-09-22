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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void botao4_Click(object sender, EventArgs e)
        {
            Form2 OutroForm = new Form2();
            OutroForm.Show();
            this.Hide();
        }
    }
}
