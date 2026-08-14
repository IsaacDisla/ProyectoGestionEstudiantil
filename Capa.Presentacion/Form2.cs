using Capa.Datos;
using Capa.Entidades;
using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Capa.Presentacion
{

    public partial class Form2 : Form
    {
        MateriaBL bl = new MateriaBL();
        MateriaDAL dal = new MateriaDAL();

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();


        }

        private bool CamposVacios()
        {
            return txtMateria.Text.Trim() == "";
        }

        private void Limpiar()
        {
            txtMateria.Clear();
            idMateria = 0;
            btnGuardar.Text = "Guardar";
        }

        private void Activar(bool estado)
        {
            txtMateria.Enabled = estado;
            btnGuardar.Enabled = estado;
            btnEliminar.Enabled = !estado;
        }


        private void Listar()
        {
            dgvMaterias.AutoGenerateColumns = true;
            dgvMaterias.DataSource = dal.Listar();

            if (dgvMaterias.Columns.Contains("IdMateria"))
                dgvMaterias.Columns["IdMateria"].Visible = false;

            if (dgvMaterias.Columns.Contains("Estado"))
                dgvMaterias.Columns["Estado"].Visible = false;
        }

        private void CargarDatos()
        {
            dgvMaterias.DataSource = null;
            dgvMaterias.DataSource = bl.Listar();


        }

        private void EstiloGrid()
        {
            dgvMaterias.BackgroundColor = Color.White;
            dgvMaterias.BorderStyle = BorderStyle.None;

            dgvMaterias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvMaterias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterias.EnableHeadersVisualStyles = false;

            dgvMaterias.RowsDefaultCellStyle.BackColor = Color.Black;
            dgvMaterias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        }



        public Form2()
        {
            InitializeComponent();

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

        int idMateria = 0;

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void txtMateria_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe completar el campo");
                return;
            }

            Materia m = new Materia
            {
                IdMateria = idMateria,
                NombreMateria = txtMateria.Text
            };

            if (idMateria == 0)
                bl.Insertar(m);
            else
                bl.Actualizar(m);
            Listar();
            Limpiar();

            MessageBox.Show(
                   "Materia insertada correctamente",
                   "Aviso",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMateria == 0) return;

            bl.Eliminar(idMateria);

            Listar();
            Limpiar();
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idMateria = Convert.ToInt32(dgvMaterias.CurrentRow.Cells[0].Value);
                txtMateria.Text = dgvMaterias.CurrentRow.Cells[1].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                Listar(); // vuelve a mostrar todo
            }
            else
            {
                dgvMaterias.DataSource = dal.Buscar(txtBuscar.Text.Trim());
            }
        }

        private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                Listar(); // vuelve a mostrar todo
            }
            else
            {
                dgvMaterias.DataSource = dal.Buscar(txtBuscar.Text.Trim());
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                Listar(); // vuelve a mostrar todo
            }
            else
            {
                dgvMaterias.DataSource = dal.Buscar(txtBuscar.Text.Trim());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvMaterias.DataSource = dal.Buscar(txtBuscar.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
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

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
