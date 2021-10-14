using System.Collections.Generic;
using System.Linq;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {

        /// <summary>
        /// Referencia al contexto de Municipio
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioPartido(AppContext appContext)
        {
            _appContext = appContext;
        }


        Partido IRepositorioPartido.AddPartido(Partido partido)
        {
            var PartidoAdicionado = _appContext.Partidos.Add(partido);
            _appContext.SaveChanges();
            return PartidoAdicionado.Entity;
        }

        void IRepositorioPartido.DeletePartido(int idPartido)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado == null)
                return;
            _appContext.Partidos.Remove(PartidoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Partido> IRepositorioPartido.GetAllPartidos()
        {
            return _appContext.Partidos;
        }

        Partido IRepositorioPartido.GetPartido(int idPartido)
        {
            return _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
        }

        Partido IRepositorioPartido.UpdatePartido(int idPartido, Partido partido)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado == null)
            {

                PartidoEncontrado.Hora = partido.Hora;
                PartidoEncontrado.Fecha = partido.Fecha;


                _appContext.SaveChanges();

            }
            return PartidoEncontrado;
        }

        Arbitro IRepositorioPartido.AsignarArbitro(int idPartido, int idArbitro)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado != null)
            {
                var ArbitroEncontrado = _appContext.Arbitros.FirstOrDefault(a => a.Id == idArbitro);
                if (ArbitroEncontrado != null)
                {
                    PartidoEncontrado.Arbitro = ArbitroEncontrado;
                    _appContext.SaveChanges();
                }
                return ArbitroEncontrado;
            }
            return null;
        }

        Estadio IRepositorioPartido.AsignarEstadio(int idPartido, int idEstadio)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado != null)
            {
                var EstadioEncontrado = _appContext.Estadios.FirstOrDefault(e => e.Id == idEstadio);
                if (EstadioEncontrado != null)
                {
                    PartidoEncontrado.Cancha = EstadioEncontrado;
                    _appContext.SaveChanges();
                }
                return EstadioEncontrado;
            }
            return null;
        }

        Equipo IRepositorioPartido.AsignarEquipoLocal(int idPartido, int idEquipo)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado != null)
            {
                var EquipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.Id == idEquipo);
                if (EquipoEncontrado != null)
                {
                    PartidoEncontrado.Local = EquipoEncontrado;
                    _appContext.SaveChanges();
                }
                return EquipoEncontrado;
            }
            return null;
        }

        Equipo IRepositorioPartido.AsignarEquipoVisitante(int idPartido, int idEquipo)
        {
            var PartidoEncontrado = _appContext.Partidos.FirstOrDefault(p => p.Id == idPartido);
            if (PartidoEncontrado != null)
            {
                var EquipoEncontrado = _appContext.Equipos.FirstOrDefault(e => e.Id == idEquipo);
                if (EquipoEncontrado != null)
                {
                    PartidoEncontrado.Visitante = EquipoEncontrado;
                    _appContext.SaveChanges();
                }
                return EquipoEncontrado;
            }
            return null;
        }







    }
}