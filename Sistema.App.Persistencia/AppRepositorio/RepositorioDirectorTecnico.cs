using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    ///Repositorio completo///
    public class RepositorioDirectorTecnico : IRepositorioDirectorTecnico
    {
        /// <summary>
        /// Referencia al contexto Director Tecnico
        /// </summary>

        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioDirectorTecnico(AppContext appContext)
        {
            _appContext = appContext;
        }
        DirectorTecnico IRepositorioDirectorTecnico.AddDirectorTecnico(DirectorTecnico directorTecnico)
        {
            var DirectorTecnicoAdicionado = _appContext.DirectoresTecnicos.Add(directorTecnico);
            _appContext.SaveChanges();
            return DirectorTecnicoAdicionado.Entity;
        }
        void IRepositorioDirectorTecnico.DeleteDirectorTecnico(int idDirectorTecnico)
        {
            var DirectorTecnicoEncontrado = _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Id == idDirectorTecnico);
            if (DirectorTecnicoEncontrado == null)
            {
                Console.WriteLine("No se encontró director técnico");
            }
            else
            {
                _appContext.DirectoresTecnicos.Remove(DirectorTecnicoEncontrado);
                _appContext.SaveChanges();
                Console.WriteLine("Fue eliminado director técnico");
            }
            return;
        }

        DirectorTecnico IRepositorioDirectorTecnico.UpdateDirectorTecnico(int documento, DirectorTecnico Dt)
        {
            var DirectorTecnicoEncontrado = _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Documento == documento);
            if (DirectorTecnicoEncontrado != null)
            {
               DirectorTecnicoEncontrado.Nombre = Dt.Nombre;
               DirectorTecnicoEncontrado.Apellido = Dt.Apellido;
               DirectorTecnicoEncontrado.Telefono = Dt.Telefono;
               _appContext.SaveChanges();
               return DirectorTecnicoEncontrado;
            }   
            return null;
        }

        DirectorTecnico IRepositorioDirectorTecnico.GetDirectorTecnico(int idDirectorTecnico)
        {
            var DirectorTecnicoEncontrado = _appContext.DirectoresTecnicos.FirstOrDefault(p => p.Id == idDirectorTecnico);
            return DirectorTecnicoEncontrado;
        }
        IEnumerable<DirectorTecnico> IRepositorioDirectorTecnico.GetAllDirectorTecnico()
        {
            return _appContext.DirectoresTecnicos;
        }
    }
}