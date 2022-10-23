using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class AdminTicketTableModel
    {
        public int IdTicket { get; set; }
        public int IdEmpleadoSolicitud { get; set; }
        public string NombreEmpSoli { get; set; }
        public string ApellidoEmpSoli { get; set; }
        public int IdEmpleadoAsignacion { get; set; }
        public string NombreEmpAsig { get; set; }
        public string ApellidoEmpAsig { get; set; }
        public int IdCategoriaTicket { get; set; }
        public string NombreCatTicket { get; set; }
        public int IdEstadoTicket { get; set; }
        public string NombreEstadoTicket { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}