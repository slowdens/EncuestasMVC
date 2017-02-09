namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        [Key]
        public int IdConsecutivo { get; set; }

        [StringLength(12)]
        public string Nomina { get; set; }

        [StringLength(6)]
        public string Sigla { get; set; }

        public int? IdPregunta { get; set; }

        public int? IdRespuesta { get; set; }

        public DateTime? Fecha { get; set; }

        public double? Valor { get; set; }

        public string Comentario { get; set; }

        public virtual Preguntas Preguntas { get; set; }

        public virtual Respuesta Respuesta { get; set; }

        public virtual Software Software { get; set; }
    }
}
