using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    ///Repositorio completo///
    public class RepositorioFutbolista : IRepositorioFutbolista
    {
        /// <summary>
        /// Referencia al contexto Futbolista
        /// </summary>

        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioFutbolista(AppContext appContext)
        {
            _appContext = appContext;
        }
        Futbolista IRepositorioFutbolista.AddFutbolista(Futbolista futbolista)
        {
            var FutbolistaAdicionado = _appContext.Futbolistas.Add(futbolista);
            _appContext.SaveChanges();
            return FutbolistaAdicionado.Entity;
        }
        void IRepositorioFutbolista.DeleteFutbolista(int idFutbolista)
        {
            var FutbolistaEncontrado = _appContext.Futbolistas.FirstOrDefault(p => p.Id == idFutbolista);
            if (FutbolistaEncontrado == null)
            {
                Console.WriteLine("No se encontró futbolista");
            }
            else
            {
                _appContext.Futbolistas.Remove(FutbolistaEncontrado);
                _appContext.SaveChanges();
                Console.WriteLine("Fue eliminado futbolista");
            }
            return;
        }

        Futbolista IRepositorioFutbolista.UpdateFutbolista(int documento, Futbolista NuevoFutbolista)
        {
            var  FutbolistaEncontrado = _appContext.Futbolistas.FirstOrDefault(p => p.Documento == documento);
            if (FutbolistaEncontrado != null)
            {
               FutbolistaEncontrado.Nombre = NuevoFutbolista.Nombre;
               FutbolistaEncontrado.Apellido = NuevoFutbolista.Apellido;
               FutbolistaEncontrado.Telefono = NuevoFutbolista.Telefono;
               FutbolistaEncontrado.NumeroCamiseta = NuevoFutbolista.NumeroCamiseta;
               FutbolistaEncontrado.PosicionCancha = NuevoFutbolista.PosicionCancha;
               _appContext.SaveChanges();
               return FutbolistaEncontrado;
            }   
            return null;
        }

        Futbolista IRepositorioFutbolista.GetFutbolista(int idFutbolista)
        {
            var FutbolistaEncontrado = _appContext.Futbolistas.FirstOrDefault(p => p.Id == idFutbolista);
            return FutbolistaEncontrado;
        }
        IEnumerable<Futbolista> IRepositorioFutbolista.GetAllFutbolista()
        {
            return _appContext.Futbolistas;
        }
    }
}