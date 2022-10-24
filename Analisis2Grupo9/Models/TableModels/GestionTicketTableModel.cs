using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class GestionTicketTableModel
    {
        public int id_ticket_seguimiento { get; set; }
        public int id_empleado { get; set; }
        public int id_ticket { get; set; }
        public DateTime fecha_seguimiento { get; set; }
        public string descripcion_seguimiento { get; set; }
        public DateTime fecha_inicio_seguimiento { get; set; }
        public DateTime fecha_fin_seguimiento { get; set; }
    }
}