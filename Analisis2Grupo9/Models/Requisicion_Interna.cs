//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Analisis2Grupo9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requisicion_Interna
    {
        public int id_requisicion { get; set; }
        public Nullable<int> id_ticket_seguimiento { get; set; }
        public Nullable<int> id_insumo { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<System.DateTime> fecha_solicitud { get; set; }
    
        public virtual Insumo Insumo { get; set; }
        public virtual Ticket_Seguimiento Ticket_Seguimiento { get; set; }
    }
}