namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calificacion")]
    public partial class Calificacion
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string Nomina { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string Sigla { get; set; }

        [Column("Calificacion")]
        public double? Calificacion1 { get; set; }

        public int? IdEstatus { get; set; }

        public virtual ValorCalificacion ValorCalificacion { get; set; }
    }
}
