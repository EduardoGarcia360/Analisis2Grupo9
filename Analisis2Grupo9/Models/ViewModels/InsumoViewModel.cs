using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Analisis2Grupo9.Models.ViewModels
{
    public class InsumoViewModel
    {
        [Required]
        [Display(Name ="ID insumo")]
        public int id_insumo { get; set; }
        [Required]
        [Display(Name = "ID categoria insumo")]
        public int id_categoria_insumo { get; set; }
        [Required]
        [Display(Name = "Código insumo")]
        public string codigo { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public int estado { get; set; }
    }


    public class InsumoEditViewModel
    {
        [Required]
        [Display(Name = "ID insumo")]
        public int id_insumo { get; set; }
        [Required]
        [Display(Name = "ID categoria insumo")]
        public int id_categoria_insumo { get; set; }
        [Required]
        [Display(Name = "Código insumo")]
        public string codigo { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public int estado { get; set; }
    }

}