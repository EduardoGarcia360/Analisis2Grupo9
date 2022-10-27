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
    }

    public class EditcatTicket
    {

        public int idCategoriaTicket { get; set; }

    
        [Required]
        [Display(Name = "Codigo categoría ticket")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre categoría")]
        public string Nombre { get; set; }
    }
}