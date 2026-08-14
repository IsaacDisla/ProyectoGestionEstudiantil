using Capa.Datos;
using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa.Presentacion
{
    public partial class FrmBuscarMateria : Form
    {



        MateriaBL bl = new MateriaBL();
        MateriaDAL dal = new MateriaDAL();
        public int IdMateria;
        public int IdProfesor;
        public string NombreMateria;
        public string NombreProfesor;

        private void CargarDatos()
        {
            dgvMaterias.DataSource = bl.ListarMateriaConProfesor();

            // 🔥 Ocultar IDs
            dgvMaterias.Columns["id_Materia"].Visible = false;
            dgvMaterias.Columns["id_Profesor"].Visible = false;

            // Opcional – mejorar vista
            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterias.RowHeadersVisible = false;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.MultiSelect = false;
        }



        public FrmBuscarMateria()
        {
            InitializeComponent();
        }

        private void FrmBuscarMateria_Load(object sender, EventArgs e)
        {
            CargarDatos();

            // Fuente general
            dgvMaterias.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dgvMaterias.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dgvMaterias.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dgvMaterias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvMaterias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMaterias.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dgvMaterias.RowsDefaultCellStyle.BackColor = Color.White;
            dgvMaterias.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dgvMaterias.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dgvMaterias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dgvMaterias.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dgvMaterias.BorderStyle = BorderStyle.None;
            dgvMaterias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMaterias.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterias.RowTemplate.Height = 36;

            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.MultiSelect = false;
            dgvMaterias.ReadOnly = true;
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.AllowUserToResizeRows = false;

        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterias.CurrentRow != null)
            {
                IdMateria = Convert.ToInt32(
                    dgvMaterias.CurrentRow.Cells["id_Materia"].Value);

                IdProfesor = Convert.ToInt32(
                    dgvMaterias.CurrentRow.Cells["id_Profesor"].Value);

                NombreMateria = dgvMaterias.CurrentRow.Cells["Materia"].Value.ToString();

                NombreProfesor = dgvMaterias.CurrentRow.Cells["Profesor"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            }
        }
    }

