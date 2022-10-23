using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class AdminTicketViewModel
    {
        public int IdTicket { get; set; }
        [ReadOnly(true)]
        [Display(Name = "# Ticket")]
        public int IdTicketMostrar { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Solicitado")]
        public DateTime Solicitado { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Solicito")]
        public string EmpleadoSolicito { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Asignacion")]
        public int IdEmpleadoAsignacion { get; set; }

    }
}