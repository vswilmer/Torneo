using System;
using System.Collections.Generic;

namespace Sistema.App.Dominio{

    public class Equipo{
        public int Id {get;set;}
        public string nombre {get;set;}
        public DirectorTecnico Dt {get; set;}
        public List<Futbolista> Plantilla {get; set;}
        public Municipio Municipio {get; set;}
    }
}