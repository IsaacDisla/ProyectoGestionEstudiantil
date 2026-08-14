using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;

namespace Capa.Negocios
{
    public class ReporteBL
    {
        // 👇 CREAR LA INSTANCIA DEL DAL
        private ReporteDAL dal = new ReporteDAL();

        public DataTable ReporteEstudiantesPorArea()
        {
            return dal.ReporteEstudiantesPorArea();
        }
    }
}

