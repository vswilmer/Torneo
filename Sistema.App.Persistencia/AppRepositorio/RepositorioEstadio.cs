using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
            
            //return _appContext.Estadios;
            var estadio = _appContext.Estadios
                //.Where(p => p.Id == idEstadio)
                .Include(p => p.Municipio)
                .ToList();
            return estadio;
        }

        /*public Estadio GetEstadio(int idEstadio)
        {
            var estadio = _appContext.Estadios
                .Where(p => p.Id == idEstadio)
                .Include(p => p.Municipio)
               
                .FirstOrDefault();
            return estadio;
        }*/

        Estadio IRepositorioEstadio.GetEstadio(int idEstadio)
        {
            //return _appContext.Estadios.FirstOrDefault(p => p.Id == idEstadio);
            var estadio = _appContext.Estadios
                .Where(p => p.Id == idEstadio)
                .Include(p => p.Municipio)
               
                .FirstOrDefault();
            return estadio;
        }

        Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var EstadioEncontrado = _appContext.Estadios.FirstOrDefault(p => p.Id == estadio.Id);
            if (EstadioEncontrado != null)
            {
                EstadioEncontrado.Nombre=estadio.Nombre;
                //EstadioEncontrado.Id=Estadio.Id;
                //EstadioEncontrado.Municipio=Estadio.Municipio;
                //EstadioEncontrado.Genero=Estadio.Genero;
                EstadioEncontrado.Direccion=estadio.Direccion;
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

        /*Estadio IRepositorioEstadio.UpdateEstadio(string nombre, Estadio estadio)
        //Estadio IRepositorioEstadio.UpdateEstadio(Estadio estadio)
        {
            var EstadioEncontrado = _appContext.Estadios.FirstOrDefault(m => m.Nombre == nombre);
            if (EstadioEncontrado != null)
            {
                EstadioEncontrado.Nombre = estadio.Nombre;


                _appContext.SaveChanges();

            }
            return EstadioEncontrado;
        }*/

        IEnumerable<Estadio> IRepositorioEstadio.SearchEstadios(string nombre)
        {
            return _appContext.Estadios
                        .Where(p => p.Nombre.Contains(nombre));
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