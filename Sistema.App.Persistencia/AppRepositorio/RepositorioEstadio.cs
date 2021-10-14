using System.Collections.Generic;
using System.Linq;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia 
{

public class RepositorioEstadio : IRepositorioEstadio
    {

        /// <summary>
        /// Referencia al contexto Estadio
        /// </summary>

        //private readonly AppContext _appContext;
        private readonly AppContext _appContext = new AppContext();

        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        /*public RepositorioEstadio(AppContext appContext)
        {
            _appContext = appContext;
        }*/
        
        Estadio IRepositorioEstadio.AddEstadio(Estadio estadio)
        {
            var EstadioAdicionado = _appContext.Estadios.Add(estadio);
            _appContext.SaveChanges();
            return EstadioAdicionado.Entity;
        }

        void IRepositorioEstadio.DeleteEstadio(int idEstadio)
        {
            var EstadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
            if (EstadioEncontrado == null)
            return;
            _appContext.Estadios.Remove(EstadioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Estadio> IRepositorioEstadio.GetAllEstadios()
        {
            return _appContext.Estadios;
        }

        Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
        {
            return _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
        }

        Estadio IRepositorioEstadio.UpdateEstadio(Estadio Estadio)
        {
            var EstadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == Estadio.Id);
            if (EstadioEncontrado != null)
            {
                EstadioEncontrado.Nombre=Estadio.Nombre;
                EstadioEncontrado.Id=Estadio.Id;
                EstadioEncontrado.Municipio=Estadio.Municipio;
                //EstadioEncontrado.Genero=Estadio.Genero;
                EstadioEncontrado.Direccion=Estadio.Direccion;
                //EstadioEncontrado.Latitud=Estadio.Latitud;
                //EstadioEncontrado.Longitud=Estadio.Longitud;
                //EstadioEncontrado.Ciudad=Estadio.Ciudad;
                //EstadioEncontrado.FechaNacimiento=Estadio.FechaNacimiento;
                //EstadioEncontrado.Familiar=Estadio.Familiar;
                //EstadioEncontrado.Enfermera=Estadio.Enfermera;
                //EstadioEncontrado.Medico=Estadio.Medico;
                //EstadioEncontrado.Historia=Estadio.Historia;

                _appContext.SaveChanges();
    
            }
            return EstadioEncontrado;
        }

//**********************************************************************************************************
        Municipio IRepositorioEstadio.AsignarMunicipio(int idEstadio, int idMunicipio)
        {
            var estadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
            if (estadioEncontrado != null)
            {
                var municipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Id == idMunicipio);
                if (municipioEncontrado != null)
                {
                    estadioEncontrado.Municipio = municipioEncontrado;
                    _appContext.SaveChanges();
                }
                return municipioEncontrado;
            }
            return null;
        }
//**********************************************************************************************************
    }

}