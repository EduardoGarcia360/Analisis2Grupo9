using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        [Required]
        [Display(Name = "Puesto")]
        public int IdPuesto { get; set; }
        [Required]
        [Display(Name = "Codigo")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Password { get; set; }
    }

    public class EditEmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        [Required]
        [Display(Name = "Puesto")]
        public int IdPuesto { get; set; }
        [Required]
        [Display(Name = "Codigo")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Password { get; set; }
    }
}