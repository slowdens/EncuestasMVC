namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Software")]
    public partial class Software
    {
        public Software()
        {
            Historial = new HashSet<Historial>();
            Preguntas = new HashSet<Preguntas>();
        }

        [Key]
        [StringLength(6)]
        public string Sigla { get; set; }

        [StringLength(500)]
        public string NombreSoftware { get; set; }

        public virtual ICollection<Historial> Historial { get; set; }

        public virtual ICollection<Preguntas> Preguntas { get; set; }
    }
}
