using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorSenha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "Escolha o \n tamanho da senha";
            
        }
        ConexaoBanco bd = new ConexaoBanco();

        private void btnGerar_Click(object sender, EventArgs e)
        {

            txtSenha.Text = GerarSenha().ToString();
            if(checkBox1.Checked == true )
            {
                SalvarSenha();
            }
        }
        public string GerarSenha()
        {
            const string digitos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder pass = new StringBuilder();
            Random rd =  new Random();
            int tamanho = int.Parse(cmbTamanhoSemha.Text);
            while( 0 < tamanho--)
            {
                pass.Append(digitos[rd.Next(digitos.Length)]);
            }
            return pass.ToString();
        }
        public string SalvarSenha()
        {
            string inserir = String.Format("insert into senhas(site,email, senha)values('{0}', '{1}','{2}')", txtSite.Text,txtEmail.Text, txtSenha.Text);
            bd.executarComandos(inserir);
            return inserir;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
