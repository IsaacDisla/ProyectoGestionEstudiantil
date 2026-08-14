using Capa.Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Capa.Negocios.ProfesorBl;

namespace Capa.Presentacion
{
    public partial class Form4 : Form
    {
        public int Id_profesor { get; private set; }
        public int Id_Profesor { get; private set; }

        private ProfesorBL bl = new ProfesorBL();

        int id_Profesor = 0;

        private bool CamposVacios()
        {
            return txtNombre.Text == "" ||
                   txtApellidos.Text == "" ||
                   txtDireccion.Text == "" ||
                   txtTelefono.Text == "" ||
                   txtEmail.Text == "";
        }
        public Form4()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            btnGuardar.Text = "Guardar";
            id_Profesor = 0;

            foreach (DataGridViewRow row in dgvProfesores.Rows)
                row.Cells["Estado"].Value = false;
        }

        private void Activar(bool estado)
        {
            txtNombre.Enabled = estado;
            btnGuardar.Enabled = estado;
            btnEliminar.Enabled = !estado;
        }

        private void Listar()
        {
            dgvProfesores.DataSource = bl.Listar();

            if (dgvProfesores.Columns.Contains("id_Profesor"))
                dgvProfesores.Columns["id_Profesor"].Visible = false;

            if (dgvProfesores.Columns.Contains("Estado"))
                dgvProfesores.Columns["Estado"].Visible = false;
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            Profesor p = new Profesor
            {
                Id_Profesor = Id_Profesor,
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text
            };

            if (Id_Profesor == 0)
            {
                bl.Insertar(p);

                MessageBox.Show(
                    "Profesor ingresado con éxito",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                bl.Actualizar(p);

                MessageBox.Show(
                    "Profesor actualizado con éxito",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            Listar();
            Limpiar();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Listar();

            // Fuente general
            dgvProfesores.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvProfesores.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvProfesores.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvProfesores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvProfesores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProfesores.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvProfesores.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProfesores.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvProfesores.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvProfesores.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvProfesores.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvProfesores.BorderStyle = BorderStyle.None;
            dgvProfesores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfesores.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfesores.RowTemplate.Height = 36;

            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.MultiSelect = false;
            dgvProfesores.ReadOnly = true;
            dgvProfesores.AllowUserToAddRows = false;
            dgvProfesores.AllowUserToResizeRows = false;
        }

        private void CargarDatos()
        {
            dgvProfesores.DataSource = bl.Listar();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
                Listar();
            else
                dgvProfesores.DataSource = bl.Buscar(txtBuscar.Text.Trim());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Id_Profesor == 0) return;

            bl.Eliminar(Id_Profesor);

            Listar();
            Limpiar();

            MessageBox.Show(
                  "Estudiante Eliminado Correctamente",
                  "Aviso",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
              );
        }

        private void dgvProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvProfesores.Columns["Estado"].Index)
            {
                // Guardar el ID seleccionado
                Id_Profesor = Convert.ToInt32(
                    dgvProfesores.Rows[e.RowIndex].Cells["id_Profesor"].Value
                );

                // Cargar datos en los TextBox
                txtNombre.Text = dgvProfesores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellidos.Text = dgvProfesores.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                txtTelefono.Text = dgvProfesores.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvProfesores.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDireccion.Text = dgvProfesores.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

                // Cambiar botón
                btnGuardar.Text = "Actualizar";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
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

        private void btnEstudianteMateria_Click(object sender, EventArgs e)
        {
            FrmMatricula f = new FrmMatricula();
            f.Show();
            this.Hide();
        }
    }
}
