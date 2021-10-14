using System;
using System.Collections.Generic;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia

{
    public interface IRepositorioPartido
    {
        IEnumerable<Partido> GetAllPartidos();

        Partido AddPartido(Partido partido);

        Partido UpdatePartido(int idPartido, Partido partido);

        void DeletePartido(int idPartido);

        Partido GetPartido(int idPartido);

        Arbitro AsignarArbitro(int idPartido, int idArbitro);
        Estadio AsignarEstadio(int idPartido, int idEstadio); 
        Equipo AsignarEquipoLocal(int idPartido, int idEquipo);
        Equipo AsignarEquipoVisitante(int idPartido, int idEquipo);



    }

}