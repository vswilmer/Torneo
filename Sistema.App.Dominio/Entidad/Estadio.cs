using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.App.Dominio{

    public class Estadio{
        public int Id {get;set;}

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Longitad maxima 10")]
        public string Nombre {get;set;}
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion {get; set;}
        public Municipio Municipio { get; set; }
    }
}