using System;

namespace Sistema.App.Dominio{
     
    public class DesempenoEquipo{
        public int Id {get;set;}
        public int PartidoJugado {get;set;}
        public int PartidoGanado {get;set;}
        public int GolFavor {get;set;}
        public int GolEnContra {get;set;}
        public int PartidoEmpatado {get;set;}
        public int Puntaje{get;set;}
        public EstadisticaPartido ResultadoPartido {get;set;}
    }
}