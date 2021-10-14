using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.App.Dominio{

    public class Persona
    {
        public int Id {get;set;}
        [Required, StringLength(50)]
        public string Nombre {get;set;}
        [Required, StringLength(50)]
        public string Apellido {get;set;}
        public int Documento {get;set;}
        [Required, StringLength(50)]
        public string Telefono {get;set;}
    }
}