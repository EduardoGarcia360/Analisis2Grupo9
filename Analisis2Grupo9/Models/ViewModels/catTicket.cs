using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class catTicket
    {

        [Required]
        [Display(Name = "Codigo categoría ticket")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre categoría")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Estado categoría")]
        public int? Estado { get; set; }
    }

    public class EditcatTicket
    {
        private string codigo;

    

        [Required]
        [Display(Name = "Codigo categoría ticket")]
        public string Codigo { get => codigo; set => codigo = value; }
        [Required]
        [Display(Name = "Nombre categoría")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Estado categoría")]
        public int? Estado { get; set; }
    }
}