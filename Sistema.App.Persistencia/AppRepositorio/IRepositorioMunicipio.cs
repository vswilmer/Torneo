using System;
using System.Collections.Generic;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia

{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> GetAllMunicipios();

        Municipio AddMunicipio(Municipio municipio);

        //Municipio UpdateMunicipio(string nombre, Municipio municipio);
         Municipio UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int idMunicipio);

        Municipio GetMunicipio(int idMunicipio);
        IEnumerable<Municipio> SearchMunicipios(string nombre);

       




    }

}