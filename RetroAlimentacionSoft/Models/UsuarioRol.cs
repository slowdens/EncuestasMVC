namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioRol")]
    public partial class UsuarioRol
    {
        [Key]
        [StringLength(50)]
        public string Nomina { get; set; }

        public int? id_rol { get; set; }

        public virtual Cat_roles Cat_roles { get; set; }
    }
}
