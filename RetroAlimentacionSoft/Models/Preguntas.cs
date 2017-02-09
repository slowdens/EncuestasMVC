namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Preguntas
    {
        public Preguntas()
        {
            Historial = new HashSet<Historial>();
            Respuesta = new HashSet<Respuesta>();
        }

        [Key]
        public int IdPregunta { get; set; }

        public string Pregunta { get; set; }

        [StringLength(6)]
        public string Sigla { get; set; }

        public virtual ICollection<Historial> Historial { get; set; }

        public virtual Software Software { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
