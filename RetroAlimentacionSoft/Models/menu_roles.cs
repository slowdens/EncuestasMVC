namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class menu_roles
    {
        [Key]
        public int id_menu_rol { get; set; }

        public int? id_rol { get; set; }

        public int? id_menu { get; set; }

        public virtual cat_menu cat_menu { get; set; }

        public virtual Cat_roles Cat_roles { get; set; }
    }
}
