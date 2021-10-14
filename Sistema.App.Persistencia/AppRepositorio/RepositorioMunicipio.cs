using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {

        
        private readonly AppContext _appContext = new AppContext();
        

        
        //Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        public Municipio AddMunicipio(Municipio municipio)
        {
            var municipioAdicionado = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdicionado.Entity;
        }


        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            //var MunicipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Id == idMunicipio);
            var MunicipioEncontrado = _appContext.Municipios.Find(idMunicipio);
            if (MunicipioEncontrado == null)
                return;
            _appContext.Municipios.Remove(MunicipioEncontrado);
            _appContext.SaveChanges();
        }

        //IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipios()
         public IEnumerable<Municipio> GetAllMunicipios()
        {
            return _appContext.Municipios;
        }

       // Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        public Municipio GetMunicipio(int idMunicipio)
        {
            //return _appContext.Municipios.FirstOrDefault(m => m.Id == idMunicipio);
            return _appContext.Municipios.Find(idMunicipio);
            
        }        

       /* Municipio IRepositorioMunicipio.UpdateMunicipio(string nombre, Municipio municipio)
        {
            //var MunicipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Nombre == nombre);
            var MunicipioEncontrado = _appContext.Municipios.Find(nombre);
            if (MunicipioEncontrado != null)
            {
                MunicipioEncontrado.Nombre = municipio.Nombre;


                _appContext.SaveChanges();

            }
            return MunicipioEncontrado;
        }*/

        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var MunicipioEncontrado = _appContext.Municipios.FirstOrDefault(p => p.Id == municipio.Id);
            if (MunicipioEncontrado != null)
            {
                MunicipioEncontrado.Nombre=municipio.Nombre;
                //EstadioEncontrado.Id=Estadio.Id;
                //EstadioEncontrado.Municipio=Estadio.Municipio;
                //EstadioEncontrado.Genero=Estadio.Genero;
                //MunicipioEncontrado.Direccion=municipio.Direccion;
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
            return MunicipioEncontrado;
        }


        IEnumerable<Municipio> IRepositorioMunicipio.SearchMunicipios(string nombre)
        {
            return _appContext.Municipios
                        .Where(p => p.Nombre.Contains(nombre));
        }
        










    }
}

