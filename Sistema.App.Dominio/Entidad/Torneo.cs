using System;
using System.Collections.Generic;

namespace Sistema.App.Dominio{
    
    public class Torneo{
        public int Id {get;set;}
        public List<Equipo> Participante {get;set;}
    }
}