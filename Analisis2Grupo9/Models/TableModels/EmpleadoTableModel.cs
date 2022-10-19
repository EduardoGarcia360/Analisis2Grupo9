using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class EmpleadoTableModel
    {
        public int IdEmpleado { get; set; }
        public int IdPuesto { get; set; }
        public string Puesto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }

    }
}