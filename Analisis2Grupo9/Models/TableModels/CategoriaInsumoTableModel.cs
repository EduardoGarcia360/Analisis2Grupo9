using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analisis2Grupo9.Models.TableModels
{
    public class CategoriaInsumoTableModel
    {
        public int id_categoria_insumo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int? estado { get; set; }
    }
}