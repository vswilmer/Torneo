using System.Collections.Generic;
using System.Linq;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {

        /// <summary>
        /// Referencia al contexto de Municipio
        /// </summary>
        //private readonly AppContext _appContext;
        private readonly AppContext _appContext = new AppContext();
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
       /* public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }*/

        
        Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
            var MunicipioAdicionado = _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return MunicipioAdicionado.Entity;
        }


        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var MunicipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Id == idMunicipio);
            if (MunicipioEncontrado == null)
                return;
            _appContext.Municipios.Remove(MunicipioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipios()
        {
            return _appContext.Municipios;
        }

        Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(m => m.Id == idMunicipio);
        }        

        Municipio IRepositorioMunicipio.UpdateMunicipio(string nombre, Municipio municipio)
        {
            var MunicipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Nombre == nombre);
            if (MunicipioEncontrado != null)
            {
                MunicipioEncontrado.Nombre = municipio.Nombre;


                _appContext.SaveChanges();

            }
            return MunicipioEncontrado;
        }


        










    }
}

