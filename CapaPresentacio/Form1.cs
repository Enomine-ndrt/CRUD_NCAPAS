using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacio
{
    public partial class Form1 : Form
    {
        CN_Productos objectCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objecto = new CN_Productos();
            dataGridView1.DataSource = objecto.MostrarProd();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objectCN.InsertarPROD(nombre.Text, descripcion.Text, marca.Text, precio.Text, stock.Text);
                    MessageBox.Show("Se ha insertado correctamente");
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos " + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objectCN.EditarProd(nombre.Text, descripcion.Text, marca.Text, precio.Text, stock.Text,idProducto);
                    MessageBox.Show("Se ha actualizado correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al editar "+ex);
                }
            }
        }
        private void limpiarForm()
        {
            nombre.Clear();
            descripcion.Clear();
            marca.Clear();
            precio.Clear();
            stock.Clear();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                descripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                marca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                precio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                stock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                objectCN.EliminarPROD(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");

        }
    }
}
