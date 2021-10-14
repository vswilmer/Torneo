using System;

namespace Sistema.App.Dominio{

    public class EstadisticaPartido{
        public int Id {get;set;}
        public Partido PartidoJugado {get;set;}
        public int Marcador {get;set;}
        public int Gol {get;set;}
        public int Amarilla {get;set;}
        public int Roja {get;set;}
        public int Minuto{get;set;}
    }
}