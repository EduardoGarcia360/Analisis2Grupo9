using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class PuestoViewModel
    {
        [Required]
        [Display(Name ="Codigo")]
        [StringLength(10, ErrorMessage ="El {0} debe tener al menos {1} caracteres", MinimumLength =1)]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }
    }

    public class EditPuestoViewModel
    {
        public int IdPuesto { get; set; }
        [Required]
        [Display(Name = "Codigo")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }
    }
}