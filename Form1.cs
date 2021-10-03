using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoParqueadero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender ,EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            BaseParqueaderoEntities1 contexto = new BaseParqueaderoEntities1();
            dataGridView1.DataSource = contexto.ClientesParqueadero.ToList();
        }
        private void lbid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.textCliente.Text);
            string Nombre = textNombre.Text;
            string telefono = textTelefono.Text;
            string Direccion = textDireccion.Text;

            using (BaseParqueaderoEntities1 contexto = new BaseParqueaderoEntities1())
            {
                ClientesParqueadero c = new ClientesParqueadero
                {
                    idCliente = id,
                    Nombre = Nombre,
                    Teléfono = telefono,
                    Dirección = Direccion
                };
                contexto.ClientesParqueadero.Add(c);
                contexto.SaveChanges();
                cargar();
            }
        }
    }
}
