using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class AddTicketViewModel
    {
        [Required]
        [Display(Name = "Titulo")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Descripcion { get; set; }
    }
}