using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class CategoriaTicketTableModel
    {
        public int IdCategoriaTicket { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}