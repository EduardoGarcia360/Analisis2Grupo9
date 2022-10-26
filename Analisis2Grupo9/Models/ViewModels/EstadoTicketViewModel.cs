using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class EstadoTicket
    {
       
        public int idEstadoTicket { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Estado { get; set; }
    }

    public class EditEstadoTicket
    {

        public int idEstadoTicket { get; set; }


    
        [Required]
        [Display(Name = "Nombre estado")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Estado categoría")]
        public int Estado { get; set; }
    }

    public class IdEstadoTikcet
    {

        public int idEstadoTicket { get; set; }


  
        [Required]
        [Display(Name = "Nombre estado")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Estado estado")]
        public int Estado { get; set; }
    }
}