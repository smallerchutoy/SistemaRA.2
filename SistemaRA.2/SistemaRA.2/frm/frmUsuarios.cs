using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using SistemaRA._2.Datos;

namespace SistemaRA._2
{
    public partial class frmUsuarios : Form
    {
        //string parametros = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA;";
        string query = "";
        string nombre = "";
        string rol = "";
        string contraseña = "";
        string telefono = "";
        string dato1 = string.Empty;
        string dato2 = string.Empty;
        int id = 0;
        int codigo = 0;
        conexion conectandose = new conexion();
        fusuarios fusuarios = new fusuarios();




        DataSet datos = new DataSet();
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=123;Database=SistemaRA");
        public frmUsuarios()
        {
            InitializeComponent();

            dataGridView1.DataSource = fusuarios.Consultar();            
            dataGridView1.Columns[0].HeaderText = "CODIGO";
            dataGridView1.Columns[1].HeaderText = "NOMBRE";
            dataGridView1.Columns[2].HeaderText = "ROL";
            dataGridView1.Columns[3].HeaderText = "CONTRASEÑA";
            dataGridView1.Columns[4].HeaderText = "TELEFONO";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;// obtengo la fila actualmente sellecionada en del datagrid

            

            textBox5.Text = Convert.ToString(fila.Cells[0].Value);

            textBox1.Text = Convert.ToString(fila.Cells[1].Value);//optengo el valor de la columna seleccionada

            cbRol.Text = Convert.ToString(fila.Cells[2].Value);

            textBox3.Text = Convert.ToString(fila.Cells[3].Value);

            textBox4.Text = Convert.ToString(fila.Cells[4].Value);
        }
        public bool vacio; // Variable utilizada para saber si hay algún TextBox vacio.

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton de Registrar
            if (textBox5.Text != "" & textBox1.Text != "" & cbRol.Text != "" & textBox3.Text != ""   
                & textBox4.Text != "")
            {
            codigo = Convert.ToInt32(textBox5.Text);
            nombre = textBox1.Text;
            //rol = textBox2.Text;
            contraseña = textBox3.Text;
            telefono = textBox4.Text;
            rol = cbRol.Text;

            
             fusuarios.Insertar(codigo, nombre, rol, contraseña, telefono);
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }
            dataGridView1.DataSource = fusuarios.Consultar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Boton de Eliminar
            DataGridViewRow fila = dataGridView1.CurrentRow;//Obtengo la fila actualment seleccionada

            id = Convert.ToInt32(fila.Cells[0].Value);
            fusuarios.eliminarRegistro(id);
            dataGridView1.DataSource = fusuarios.Consultar();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton de editar
            codigo = Convert.ToInt32(textBox5.Text);
            nombre = textBox1.Text;
            rol = cbRol.Text;
            contraseña = textBox3.Text;
            telefono = textBox4.Text;
            DataGridViewRow fila = dataGridView1.CurrentRow;//Obtengo la fila actualment seleccionada

            id = Convert.ToInt32(fila.Cells[0].Value);
            if (textBox5.Text != "" & textBox1.Text != "" & cbRol.Text != "" & textBox3.Text != ""
               & textBox4.Text != "")
            {
                fusuarios.actualizarRegistro(codigo, nombre, rol, contraseña, telefono);
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Faltan datos por llenar");
            }

            dataGridView1.DataSource = fusuarios.Consultar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
