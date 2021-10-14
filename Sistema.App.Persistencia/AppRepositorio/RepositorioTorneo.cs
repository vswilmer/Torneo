using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    /// Repositorio incompleto (toca hacer unos cambios es mas COMPLEJO) ///
    public class RepositorioTorneo : IRepositorioTorneo
    {
        /// <summary>
        /// Referencia al contexto Torneo
        /// </summary>

        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioTorneo(AppContext appContext)
        {
            _appContext = appContext;
        }
        Torneo IRepositorioTorneo.AddTorneo(Torneo torneo)
        {
            var TorneoAdicionado = _appContext.Torneos.Add(torneo);
            _appContext.SaveChanges();
            return TorneoAdicionado.Entity;
        }
        void IRepositorioTorneo.DeleteTorneo(int idTorneo)
        {
            var TorneoEncontrado = _appContext.Torneos.FirstOrDefault(p => p.Id == idTorneo);
            if (TorneoEncontrado == null)
            {
                Console.WriteLine("No se encontró torneo");
            }
            else
            {
                _appContext.Torneos.Remove(TorneoEncontrado);
                _appContext.SaveChanges();
                Console.WriteLine("Fue eliminado Torneo");
            }
            return;
        }

        Torneo IRepositorioTorneo.UpdateTorneo(int Id, Torneo NuevoTorneo)
        {
            var  TorneoEncontrado = _appContext.Torneos.FirstOrDefault(p => p.Id == Id);
            if (TorneoEncontrado != null)
            {
               TorneoEncontrado.Participante = NuevoTorneo.Participante;
               _appContext.SaveChanges();
               return TorneoEncontrado;
            }   
            return null;
        }

        Torneo IRepositorioTorneo.GetTorneo(int idTorneo)
        {
            var TorneoEncontrado = _appContext.Torneos.FirstOrDefault(p => p.Id == idTorneo);
            return TorneoEncontrado;
        }
    }
}