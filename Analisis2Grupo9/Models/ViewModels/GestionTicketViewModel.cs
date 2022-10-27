using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class GestionTicketViewModel
    {
        // ID de la Gestion no es necesario, es autoincrementable y solo importa el ID del Ticket original
        [Display(Name = "#Ticket")]
        public int idTicketMostrar { get; set; }
        [Required]
        
        public int idTicket { get; set; } // ID del Ticket original
        [Required]
        [Display(Name = "Titulo Ticket")]
        public string TituloTicket { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public int idEmpledo { get; set; }
        [Required]
        [Display(Name = "Descripción Ticket")]
        public string DescripcionTicket { get; set; }
        [Required]
        [Display(Name = "Fecha Seguimiento Ticket")]
        public DateTime FechaSeguimiento { get; set; }
        [Required]
        [Display(Name = "Descripción de Seguimiento")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string DescripcionSeguimiento { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime HoraInicio { get; set; }

        [Display(Name = "Fecha Fin")]
        public DateTime HoraFinal { get; set; }
        public int idEstadoTicket { get; set; }
    }
}