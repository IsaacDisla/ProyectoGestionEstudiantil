using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;
using Capa.Entidades;

namespace Capa.Presentacion
{


    public partial class FrmBuscarEstudiante : Form
    {


        EstudianteBL bl = new EstudianteBL();
        public EstudianteSeleccionado EstudianteSeleccionado { get; set; }
        int idAreaSeleccionada;
        private void CargarDatos()
        {
            dgvEstudiantes.DataSource = bl.Listar();

            if (dgvEstudiantes.Columns.Contains("id_Estudiante"))
                dgvEstudiantes.Columns["id_Estudiante"].Visible = false;

            if (dgvEstudiantes.Columns.Contains("id_AreaTecnica"))
                dgvEstudiantes.Columns["id_AreaTecnica"].Visible = false;
        }

        private void Listar()
        {
            dgvEstudiantes.DataSource = bl.Listar();

        }

        public FrmBuscarEstudiante()
        {
            InitializeComponent();
        }

        private void FrmBuscarEstudiante_Load(object sender, EventArgs e)
        {
            CargarDatos();
            // Fuente general
            dgvEstudiantes.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvEstudiantes.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvEstudiantes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEstudiantes.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvEstudiantes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvEstudiantes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvEstudiantes.BorderStyle = BorderStyle.None;
            dgvEstudiantes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEstudiantes.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstudiantes.RowTemplate.Height = 36;

            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstudiantes.MultiSelect = false;
            dgvEstudiantes.ReadOnly = true;
            dgvEstudiantes.AllowUserToAddRows = false;
            dgvEstudiantes.AllowUserToResizeRows = false;
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEstudiantes.CurrentRow != null)
            {
                EstudianteSeleccionado = new EstudianteSeleccionado
                {
                    IdEstudiante = Convert.ToInt32(
          dgvEstudiantes.CurrentRow.Cells["id_Estudiante"].Value),

                    IdAreaTecnica = Convert.ToInt32(
          dgvEstudiantes.CurrentRow.Cells["id_AreaTecnica"].Value),

                    NombreEstudiante = dgvEstudiantes.CurrentRow.Cells["Nombre"].Value.ToString(),

                    AreaTecnica = dgvEstudiantes.CurrentRow.Cells["AreaTecnica"].Value.ToString()
                };


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
                Listar();
            else
            {
                dgvEstudiantes.DataSource = bl.BuscarPorNombre(txtBuscar.Text.Trim());

                if (dgvEstudiantes.Columns.Contains("id_Estudiante"))
                    dgvEstudiantes.Columns["id_Estudiante"].Visible = false;

                if (dgvEstudiantes.Columns.Contains("id_AreaTecnica"))
                    dgvEstudiantes.Columns["id_AreaTecnica"].Visible = false;
            }
        }
    }
}
