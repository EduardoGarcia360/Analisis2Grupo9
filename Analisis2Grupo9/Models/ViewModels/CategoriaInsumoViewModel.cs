using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.ComponentModel;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class CategoriaInsumoViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} carácteres", MinimumLength = 1)]
        [Display(Name = "Código")]
        public string codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

    }

    public class EditCategoriaInsumoViewModel
    {
        public int id_categoria_insumo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} carácteres", MinimumLength = 1)]
        [Display(Name = "Código")]
        public string codigo { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

    }
}