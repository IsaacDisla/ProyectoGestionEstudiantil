using Capa.Negocio;
using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Capa.Negocios.ProfesorBl;

namespace Capa.Presentacion
{
    public partial class Form5 : Form
    {

        int idProfesorMateria = 0;

        ProfesorMateriaBL profesorMateriaBL = new ProfesorMateriaBL();

        private MateriaBL materiaBL = new MateriaBL();
        private ProfesorBL profesorBL = new ProfesorBL();

        private void Limpiar()
        {
            idProfesorMateria = 0;
            cboProfesor.SelectedIndex = 0;
            cboMateria.SelectedIndex = 0;
        }

        private void CargarGrid()
        {
            dgvProfesorMateria.DataSource = profesorMateriaBL.Listar();
        }


        private void CargarProfesores()
        {
            cboProfesor.DataSource = null;
            cboProfesor.DataSource = profesorBL.Listar();
            cboProfesor.DisplayMember = "NombreCompleto";  // 🔥 CAMBIO AQUÍ
            cboProfesor.ValueMember = "Id_Profesor";
        }


        private void CargarMaterias()
        {
            cboMateria.DataSource = null;
            // Uso de los nombres reales de la clase Materia: NombreMateria e IdMateria
            cboMateria.DisplayMember = "NombreMateria";
            cboMateria.ValueMember = "IdMateria";
            cboMateria.DataSource = materiaBL.Listar();
        }

        private void Listar()
        {
            dgvProfesorMateria.DataSource = profesorMateriaBL.Listar();

            if (dgvProfesorMateria.Columns.Contains("id_ProfesorMateria"))
                dgvProfesorMateria.Columns["id_ProfesorMateria"].Visible = false;

            if (dgvProfesorMateria.Columns.Contains("Estado"))
                dgvProfesorMateria.Columns["Estado"].Visible = false;
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarMaterias();
            Listar();

            // Fuente general
            dgvProfesorMateria.Font = new Font("Seoge UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvProfesorMateria.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvProfesorMateria.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvProfesorMateria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvProfesorMateria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesorMateria.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProfesorMateria.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvProfesorMateria.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProfesorMateria.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvProfesorMateria.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvProfesorMateria.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvProfesorMateria.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvProfesorMateria.BorderStyle = BorderStyle.None;
            dgvProfesorMateria.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfesorMateria.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvProfesorMateria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfesorMateria.RowTemplate.Height = 36;

            dgvProfesorMateria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesorMateria.MultiSelect = false;
            dgvProfesorMateria.ReadOnly = true;
            dgvProfesorMateria.AllowUserToAddRows = false;
            dgvProfesorMateria.AllowUserToResizeRows = false;

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProfesorMateria == 0)
            {
                // INSERTAR
                profesorMateriaBL.Insertar(
                    Convert.ToInt32(cboProfesor.SelectedValue),
                    Convert.ToInt32(cboMateria.SelectedValue)
                );

                MessageBox.Show("Asignación guardada correctamente");
            }
            else
            {
                // ACTUALIZAR
                profesorMateriaBL.Actualizar(
                   idProfesorMateria,
                   Convert.ToInt32(cboProfesor.SelectedValue),
                   Convert.ToInt32(cboMateria.SelectedValue),
                   true
               );

                MessageBox.Show("Asignación actualizada correctamente");
            }

            CargarGrid(); // 🔥 ESTO ES CLAVE


            Limpiar();
            Listar();
        }

        private void dgvProfesorMateria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idProfesorMateria = Convert.ToInt32(
                    dgvProfesorMateria.Rows[e.RowIndex]
                    .Cells["id_ProfesorMateria"].Value
                );

                cboProfesor.Text = dgvProfesorMateria.Rows[e.RowIndex]
                    .Cells["Profesor"].Value.ToString();

                cboMateria.Text = dgvProfesorMateria.Rows[e.RowIndex]
                    .Cells["Materia"].Value.ToString();
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProfesorMateria == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            profesorMateriaBL.Eliminar(idProfesorMateria);
            Listar();
            Limpiar();

            MessageBox.Show("Registro eliminado correctamente");
        }

        private void btnEstudianteMateria_Click(object sender, EventArgs e)
        {
            FrmMatricula f = new FrmMatricula();
            f.Show();
            this.Hide();
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
