namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Respuesta")]
    public partial class Respuesta
    {
        public Respuesta()
        {
            Historial = new HashSet<Historial>();
        }

        [Key]
        public int IdRespuesta { get; set; }

        [Column("Respuesta")]
        [StringLength(50)]
        public string Respuesta1 { get; set; }

        public double? Valor { get; set; }

        public int? IdPregunta { get; set; }

        public int? IdComponente { get; set; }

        public virtual Componentes Componentes { get; set; }

        public virtual ICollection<Historial> Historial { get; set; }

        public virtual Preguntas Preguntas { get; set; }
    }
}
