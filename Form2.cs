using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GeradorSenha
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Consultar();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        ConexaoBanco bd = new ConexaoBanco();
        private void Consultar()
        {
            string select = "Select * from senhas order by id";
            DataTable dt = bd.executarConsulta(select);
            dt.AsDataView();
            dataGridView1.DataSource = dt;
        }
        private void Buscar()
        {
            string sel = String.Format("Select * from senhas where site like '%{0}%' or senha like '%{0}%' or email like '%{0}%' or id like '%{0}%'", txtBuscar.Text);
            txtBuscar.Clear();
            DataTable dt = bd.executarConsulta(sel);
            dt.AsDataView();
            dataGridView1.DataSource = dt;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
