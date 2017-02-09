using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetroAlimentacionSoft.Models;
using System.ComponentModel.DataAnnotations;
namespace RetroAlimentacionSoft.Models.utilidades
{
    public class VistaRol
    {
        
        public int SelectRol { get; set; }
        [Required(ErrorMessage = "selecciona una opcion")]
        public IEnumerable<Cat_roles> rol { get; set; }
    }
}