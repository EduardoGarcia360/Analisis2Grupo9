using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class TicketTableModel
    {
        public int IdTicket { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoriaTicket { get; set; }
        public string CategoriaTicketDesc { get; set; }
        public int IdEstadoTicket { get; set; }
        public string EstadoTicketDesc { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string NombreEmpleadoAsignado { get; set; }
        public string ApellidoEmpleadoAsignado { get; set; }
    }
}