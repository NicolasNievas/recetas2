using recetas2.dominio;
using recetas2.servicio;
using recetas2.servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recetas2
{
    public partial class FrmAltaRecetasMio : Form
    {
        private Receta nuevo;
        private IServicio service;
        public FrmAltaRecetasMio()
        {
            InitializeComponent();
            nuevo = new Receta();
            service = new ServicoFactoryImp().crearServicio();
        }

        private void FrmAltaRecetasMio_Load(object sender, EventArgs e)
        {
            ProximaReceta();
            CargarCombo();
        }

        private void CargarCombo()
        {
            cboProducto.DataSource = service.ObtenerIngredientes();
            cboProducto.ValueMember = "IngredienteID";
            cboProducto.DisplayMember = "Nombre";
            cboProducto.SelectedIndex = -1;
        }

        private void ProximaReceta()
        {
            int next = service.ProximaReceta();
            if (next > 0)
            {
                lblNro.Text += next.ToString();
            }
            else
            {
                MessageBox.Show("Error de datos, no se obtuvimos la proxima receta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar()
        {
            txtNombre.Text = "";
            txtCheff.Text = "";
            cboProducto.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            nudCantidad.Value = 1;
        }
        private void calcularTotal()
        {
            lblTotalIngredientes.Text = "Total de ingredientes: " + dgvDetalles.Rows.Count;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 3)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
            }
        }
        private bool validarAgregar()
        {
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un ingrediente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nudCantidad.Value == 0)
            {
                MessageBox.Show("Seleccione una cantidad valida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colingrediente"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Ingrediente: " + cboProducto.Text + " ya se agrego este ingrediente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(validarAgregar())
            {
                DetalleReceta dt = new DetalleReceta();
                dt.Cantidad = (int)nudCantidad.Value;
                dt.Ingrediente = (Ingrediente)cboProducto.SelectedItem;
                nuevo.AgregarDetalle(dt);
                dgvDetalles.Rows.Add(new object[] { dt.Ingrediente.IngredienteID, dt.Ingrediente.Nombre, dt.Cantidad });
            }
            calcularTotal();
        }
        private bool validarAceptar()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("La receta debe tener un nombre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCheff.Text == "")
            {
                MessageBox.Show("La receta debe tener un cheff", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("La receta debe tener un tipo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("Ha olvidado ingredientes?", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(validarAceptar())
            {
                nuevo.RecetaNro = service.ProximaReceta();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Cheff = txtCheff.Text;
                nuevo.TipoReceta = Convert.ToInt32(cboProducto.SelectedIndex);
                if (service.ConfirmarReceta(nuevo))
                {
                    MessageBox.Show("Receta Agregada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la receta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                calcularTotal();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que desea cancelar y salir?","AVISO",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
