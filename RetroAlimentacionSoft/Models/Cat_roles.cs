namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_roles
    {
        public Cat_roles()
        {
            menu_roles = new HashSet<menu_roles>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_rol { get; set; }

        [StringLength(520)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public bool? Activo { get; set; }

        public virtual ICollection<menu_roles> menu_roles { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
