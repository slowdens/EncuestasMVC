namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ValorCalificacion")]
    public partial class ValorCalificacion
    {
        public ValorCalificacion()
        {
            Calificacion = new HashSet<Calificacion>();
        }

        [Key]
        public int IdEstatus { get; set; }

        [StringLength(50)]
        public string Estatus { get; set; }

        public double? MayorQue { get; set; }

        public double? MenorQue { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }
    }
}
