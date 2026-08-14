using Capa.Datos;
using Capa.Entidades;
using Capa.Negocios;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa.Presentacion
{
    public partial class FrmMatricula : Form
    {

        private int idMateriaSeleccionada = 0;
        private int idProfesorSeleccionado = 0;
        private int idAreaTecnicaSeleccionada = 0;
        int idEstudianteSeleccionado = 0;
        int idMatriculaSeleccionada = 0;
        EstudianteMateriaBL bl = new EstudianteMateriaBL();
        public int idEstudiante;


        void CargarMatriculacion()
        {
            dgvMatriculacion.DataSource = bl.Listar();
        }

        private void ListarEstudianteMateria()
        {
            dgvMatriculacion.DataSource = bl.Listar();

            // 🔥 OCULTAR IDS
            dgvMatriculacion.Columns["id_Estudiantes_Materia"].Visible = false;
            dgvMatriculacion.Columns["id_estudiante"].Visible = false;
            dgvMatriculacion.Columns["id_materia"].Visible = false;
            dgvMatriculacion.Columns["id_profesor"].Visible = false;
            dgvMatriculacion.Columns["id_areaTecnica"].Visible = false;
            dgvMatriculacion.Columns["Estado"].Visible = false;
        }

        private void Limpiar()
        {
            idEstudianteSeleccionado = 0;
            idMateriaSeleccionada = 0;
            idProfesorSeleccionado = 0;
            idAreaTecnicaSeleccionada = 0;

            txtEstudiante.Clear();
            txtAreaTecnica.Clear();
            txtMateria.Clear();
            txtProfesor.Clear();

            btnGuardar.Text = "Guardar";

        }


        public FrmMatricula()
        {
            InitializeComponent();
            ListarEstudianteMateria();
            CargarMatriculacion();

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void btnEstudianteMateria_Click(object sender, EventArgs e)
        {
            FrmMatricula f = new FrmMatricula();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Fuente general
            dgvMatriculacion.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvMatriculacion.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvMatriculacion.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvMatriculacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvMatriculacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMatriculacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatriculacion.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvMatriculacion.RowsDefaultCellStyle.BackColor = Color.White;
            dgvMatriculacion.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvMatriculacion.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvMatriculacion.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvMatriculacion.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvMatriculacion.BorderStyle = BorderStyle.None;
            dgvMatriculacion.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMatriculacion.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvMatriculacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriculacion.RowTemplate.Height = 36;

            dgvMatriculacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriculacion.MultiSelect = false;
            dgvMatriculacion.ReadOnly = true;
            dgvMatriculacion.AllowUserToAddRows = false;
            dgvMatriculacion.AllowUserToResizeRows = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idEstudianteSeleccionado == 0 || idMateriaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar estudiante y materia");
                return;
            }

            EstudianteMateria em = new EstudianteMateria();
            em.IdEstudiante = idEstudianteSeleccionado;
            em.IdMateria = idMateriaSeleccionada;
            em.IdProfesor = idProfesorSeleccionado;
            em.IdAreaTecnica = idAreaTecnicaSeleccionada;
            em.Estado = true;

            // 🔥 SI ES NUEVO → INSERTAR
            if (idMatriculaSeleccionada == 0)
            {
                if (bl.Existe(idEstudianteSeleccionado, idMateriaSeleccionada))
                {
                    MessageBox.Show("Este estudiante ya está inscrito en esta materia");
                    return;
                }

                bl.Insertar(em);
                MessageBox.Show("Matrícula guardada correctamente");
            }
            else
            {
                // 🔥 SI YA EXISTE → ACTUALIZAR
                em.IdEstudiantesMateria = idMatriculaSeleccionada;

                bl.Actualizar(em);
                MessageBox.Show("Matrícula actualizada correctamente");
            }

            CargarMatriculacion();
            Limpiar();

            idMatriculaSeleccionada = 0;
            btnGuardar.Text = "Guardar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idMatriculaSeleccionada > 0)
            {
                bl.Eliminar(idMatriculaSeleccionada);

                MessageBox.Show("Eliminado correctamente");

                ListarEstudianteMateria();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione una matrícula");
            }

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnSeleccionarEstudiante_Click(object sender, EventArgs e)
        {
            FrmBuscarEstudiante frm = new FrmBuscarEstudiante();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                idEstudianteSeleccionado = frm.EstudianteSeleccionado.IdEstudiante;
                idAreaTecnicaSeleccionada = frm.EstudianteSeleccionado.IdAreaTecnica;

                txtEstudiante.Text = frm.EstudianteSeleccionado.NombreEstudiante;
                txtAreaTecnica.Text = frm.EstudianteSeleccionado.AreaTecnica;
            }
        }

        private void btnSeleccionarMateria_Click(object sender, EventArgs e)
        {
            FrmBuscarMateria frm = new FrmBuscarMateria();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                idMateriaSeleccionada = frm.IdMateria;
                idProfesorSeleccionado = frm.IdProfesor;

                txtMateria.Text = frm.NombreMateria;
                txtProfesor.Text = frm.NombreProfesor;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (idEstudianteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un estudiante");
                return;
            }

            Formreportematrulas frm =
                new Formreportematrulas(idEstudianteSeleccionado);

            frm.ShowDialog();
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvMatriculacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idMatriculaSeleccionada = Convert.ToInt32(
                dgvMatriculacion.Rows[e.RowIndex].Cells["id_Estudiantes_Materia"].Value);

            idEstudianteSeleccionado = Convert.ToInt32(
                dgvMatriculacion.Rows[e.RowIndex].Cells["id_estudiante"].Value);

            idMateriaSeleccionada = Convert.ToInt32(
                dgvMatriculacion.Rows[e.RowIndex].Cells["id_materia"].Value);

            idProfesorSeleccionado = Convert.ToInt32(
                dgvMatriculacion.Rows[e.RowIndex].Cells["id_profesor"].Value);

            idAreaTecnicaSeleccionada = Convert.ToInt32(
                dgvMatriculacion.Rows[e.RowIndex].Cells["id_areaTecnica"].Value);

            txtEstudiante.Text = dgvMatriculacion.Rows[e.RowIndex].Cells["Estudiante"].Value.ToString();
            txtAreaTecnica.Text = dgvMatriculacion.Rows[e.RowIndex].Cells["AreaTecnica"].Value.ToString();
            txtMateria.Text = dgvMatriculacion.Rows[e.RowIndex].Cells["Materia"].Value.ToString();
            txtProfesor.Text = dgvMatriculacion.Rows[e.RowIndex].Cells["Profesor"].Value.ToString();

            btnGuardar.Text = "Actualizar";
        }
    }
}


