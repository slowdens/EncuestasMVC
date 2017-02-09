namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Componentes
    {
        public Componentes()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        [Key]
        public int IdComponente { get; set; }

        [StringLength(10)]
        public string Compenente { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
