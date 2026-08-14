using Capa.Entidades;
using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa.Presentacion
{
    public partial class Form3 : Form
    {

        AreaTecnicaBL bl = new AreaTecnicaBL();
        int idAreaSeleccionada = 0;

        private void CargarDatos()
        {
            dgvAreaTecnica.DataSource = bl.Listar();

            dgvAreaTecnica.Columns["id_AreaTecnica"].Visible = false;
        }

        private void Limpiar()
        {
            txtNombreArea.Clear();
            txtBuscar.Clear();
            idAreaSeleccionada = 0;

            btnGuardar.Text = "Guardar";

        }

        public Form3()
        {
            InitializeComponent();
            CargarDatos();

            // Fuente general
            dgvAreaTecnica.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvAreaTecnica.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvAreaTecnica.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvAreaTecnica.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvAreaTecnica.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAreaTecnica.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAreaTecnica.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvAreaTecnica.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAreaTecnica.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvAreaTecnica.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvAreaTecnica.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvAreaTecnica.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvAreaTecnica.BorderStyle = BorderStyle.None;
            dgvAreaTecnica.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAreaTecnica.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvAreaTecnica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAreaTecnica.RowTemplate.Height = 36;

            dgvAreaTecnica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreaTecnica.MultiSelect = false;
            dgvAreaTecnica.ReadOnly = true;
            dgvAreaTecnica.AllowUserToAddRows = false;
            dgvAreaTecnica.AllowUserToResizeRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreArea.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del área técnica");
                return;
            }

            AreaTecnica area = new AreaTecnica();
            area.Nombre_Area = txtNombreArea.Text.Trim();

            if (idAreaSeleccionada == 0)
            {
                bl.Insertar(area);
                MessageBox.Show("Área técnica registrada");
            }
            else
            {
                area.id_AreaTecnica = idAreaSeleccionada;
                bl.Actualizar(area);
                MessageBox.Show("Área técnica actualizada");
            }

            Limpiar();
            CargarDatos();
        }

        private void dgvAreaTecnica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idAreaSeleccionada = Convert.ToInt32(
                    dgvAreaTecnica.Rows[e.RowIndex].Cells["id_AreaTecnica"].Value
                );

                txtNombreArea.Text =
                    dgvAreaTecnica.Rows[e.RowIndex].Cells["Nombre_Area"].Value.ToString();

                btnGuardar.Text = "Actualizar";

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAreaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar el área técnica?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r == DialogResult.Yes)
            {
                bl.Eliminar(idAreaSeleccionada);
                MessageBox.Show("Área técnica eliminada");

                Limpiar();
                CargarDatos();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
                dgvAreaTecnica.DataSource = bl.Listar();
            else
                dgvAreaTecnica.DataSource = bl.BuscarPorNombre(txtBuscar.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void btnEstudianteMateria_Click(object sender, EventArgs e)
        {
            FrmMatricula f = new FrmMatricula();
            f.Show();
            this.Hide();
        }
    }
}
