//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analisis2Grupo9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket_Seguimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket_Seguimiento()
        {
            this.Requisicion_Interna = new HashSet<Requisicion_Interna>();
        }
    
        public int id_ticket_seguimiento { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public Nullable<int> id_ticket { get; set; }
        public Nullable<System.DateTime> fecha_seguimiento { get; set; }
        public string descripcion_seguimiento { get; set; }
        public Nullable<System.DateTime> fecha_inicio_seguimiento { get; set; }
        public Nullable<System.DateTime> fecha_fin_seguimiento { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisicion_Interna> Requisicion_Interna { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
