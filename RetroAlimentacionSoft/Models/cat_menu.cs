namespace RetroAlimentacionSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cat_menu
    {
        public cat_menu()
        {
            menu_roles = new HashSet<menu_roles>();
        }

        [Key]
        public int id_menu { get; set; }

        [StringLength(520)]
        public string Nombre { get; set; }

        [StringLength(520)]
        public string Link { get; set; }

        public int? Padre { get; set; }

        public virtual ICollection<menu_roles> menu_roles { get; set; }
    }
}
