using System;

namespace Sistema.App.Dominio{

    public class Partido{
        public int Id {get;set;}
        public Equipo Local {get;set;}
        public Equipo Visitante {get;set;}
        public DateTime Hora {get; set;}
        public DateTime Fecha {get; set;}
        public Arbitro Arbitro {get; set;}
        public Estadio Cancha {get; set;}
    }
}