using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class EstadoTicket
    {
       
        [Required]
        [Display(Name = "Nombre estado")]
        public string Nombre { get; set; }

    }

    public class EditEstadoTicket
    {

        public int idEstadoTicket { get; set; }
        [Required]
        [Display(Name = "Nombre estado")]
        public string Nombre { get; set; }
    }
}