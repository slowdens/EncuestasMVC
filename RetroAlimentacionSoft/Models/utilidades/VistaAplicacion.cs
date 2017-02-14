using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RetroAlimentacionSoft.Models;
using System.ComponentModel.DataAnnotations;

namespace RetroAlimentacionSoft.Models.utilidades
{
    public class VistaAplicacion
    {
        public int SelectSoftware { get; set; }
        [Required(ErrorMessage = "selecciona una opcion")]
        public IEnumerable<Software> sofware { get; set; }
    }
}