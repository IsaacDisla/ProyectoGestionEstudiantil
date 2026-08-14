using Capa.Datos;
using Capa.Entidades;
using Capa.Negocios;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Capa.Presentacion
{

    public partial class Form1 : Form
    {
        private EstudianteBL bl = new EstudianteBL();
        int idEstudiante = 0;
        private readonly string conexion;

        AreaTecnicaBL blArea = new AreaTecnicaBL();
        private bool CamposVacios()
        {
            return txtNombre.Text == "" ||
                   txtApellidos.Text == "" ||
                   txtDireccion.Text == "" ||
                   txtTelefono.Text == "" ||
                   txtEmail.Text == "";
        }

        private void CargarAreaTecnica()
        {
            EstudianteDAL dal = new EstudianteDAL();

            cboAreaTecnica.DataSource = dal.ListarAreas();
            cboAreaTecnica.DisplayMember = "Nombre_Area";
            cboAreaTecnica.ValueMember = "id_AreaTecnica";
            cboAreaTecnica.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = bl.Listar();

        }

        private void Limpiar()
        {
            idEstudiante = 0;
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            buttonGuardar.Text = "Guardar";
        }

        private void Listar()
        {
            dataGridView1.DataSource = bl.Listar();
            dataGridView1.DataSource = bl.Listar();

            if (dataGridView1.Columns.Contains("id_Estudiante"))
                dataGridView1.Columns["id_Estudiante"].Visible = false;

            if (dataGridView1.Columns.Contains("id_AreaTecnica"))
                dataGridView1.Columns["id_AreaTecnica"].Visible = false;

            if (dataGridView1.Columns.Contains("NombreArea"))
                dataGridView1.Columns["NombreArea"].HeaderText = "Área Técnica";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CargarAreaTecnica();
            Listar();

            if (dataGridView1.Columns.Contains("NombreArea"))
            {
                dataGridView1.Columns["NombreArea"].HeaderText = "Área Técnica";
            }
            dataGridView1.Columns["id_Estudiante"].Visible = false;
            // Fuente general
            dataGridView1.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // Fuente del encabezado
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            // Quitar estilos por defecto
            dataGridView1.EnableHeadersVisualStyles = false;

            // 🔵 ENCABEZADO AZUL
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;

            // ⚪ FILAS NORMALES
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;

            // 🟢 FILAS ALTERNAS
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(224, 242, 241); // verde claro

            // 🟠 FILA SELECCIONADA
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 153, 51); // naranja
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes limpios
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.LightGray;

            // Ajustes pro 😎
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 36;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            Estudiante estudiante = new Estudiante
            {
                IdEstudiante = idEstudiante,
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Id_AreaTecnica = Convert.ToInt32(cboAreaTecnica.SelectedValue)
            };

            if (idEstudiante == 0)
            {
                estudiante.Estado = true;
                bl.Guardar(estudiante);

                MessageBox.Show(
                    "Estudiante agregado correctamente",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                estudiante.Estado = true;
                bl.Actualizar(estudiante);

                MessageBox.Show(
                    "Estudiante actualizado correctamente",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            Listar();
            Limpiar();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idEstudiante = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                cboAreaTecnica.SelectedValue =
                dataGridView1.CurrentRow.Cells["id_AreaTecnica"].Value;
                dataGridView1.Columns["id_AreaTecnica"].Visible = false;


                buttonGuardar.Text = "Actualizar";
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
                Listar();
            else
            {
                dataGridView1.DataSource = bl.BuscarPorNombre(txtBuscar.Text.Trim());

                if (dataGridView1.Columns.Contains("id_Estudiante"))
                    dataGridView1.Columns["id_Estudiante"].Visible = false;

                if (dataGridView1.Columns.Contains("id_AreaTecnica"))
                    dataGridView1.Columns["id_AreaTecnica"].Visible = false;
            }

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idEstudiante == 0) return;

            bl.Eliminar(idEstudiante);

            Listar();
            Limpiar();

            MessageBox.Show(
                  "Estudiante Eliminado Correctamente",
                  "Aviso",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information
              );
        }

        private void cboAreaTecnica_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}

