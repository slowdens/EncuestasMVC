using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetroAlimentacionSoft.Models.utilidades
{
    public class ViewmodelNominaRol
    {
        [Required(ErrorMessage = "Escriba una nómina")]
        public string Nomina { get; set; }
        [Required(ErrorMessage = "selecciona una opcion")]
        public IEnumerable<Cat_roles> rol { get; set; }

    }
}