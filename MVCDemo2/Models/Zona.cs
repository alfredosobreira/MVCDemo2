//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDemo2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zona
    {
        public int Id { get; set; }
        public long Numero { get; set; }
        public string Nome { get; set; }
        public int AlarmeId { get; set; }
    
        public virtual Alarme Alarme { get; set; }
    }
}
