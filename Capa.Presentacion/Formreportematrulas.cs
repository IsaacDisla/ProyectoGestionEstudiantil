using Capa.Datos;
using Capa.Negocios;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion
{
    public partial class Formreportematrulas : Form
    {
        public int idEstudiante;

        public Formreportematrulas()
        {
            InitializeComponent();
        }

        public Formreportematrulas(int idEstudianteSeleccionado)
        {
            InitializeComponent();
            idEstudiante = idEstudianteSeleccionado;   // ✅ Correcto

        }

        private void Formreportematrulas_Load(object sender, EventArgs e)
        {

            ReporteDAL dal = new ReporteDAL();

            DataTable dt = dal.ReportePorEstudiante(idEstudiante);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds =
                new ReportDataSource("DataSet3", dt);

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportEmbeddedResource =
                "Capa.Presentacion.Report1.rdlc";

            reportViewer1.RefreshReport();
        }
        

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
