using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableViewsModels
{
    public class InsumosTableViewModel
    {
        public int? id_insumo { get; set; }
        public int id_categoria_insumo { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int estado { get; set; }

    }
}