using System;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia 
{

public interface IRepositorioEstadio
{
    IEnumerable<Estadio> GetAllEstadios();
    Estadio AddEstadio(Estadio Estadio);
    //Estadio UpdateEstadio(Estadio Estadio);
    //Estadio UpdateEstadio(string nombre, Estadio estadio);
    Estadio UpdateEstadio(Estadio estadio);
    //Estadio UpdateEstadio(Estadio estadio);
    void DeleteEstadio(int idEstadio);
    Estadio GetEstadio(int idEstadio);
    Municipio AsignarMunicipio(int idEstadio, int idMunicipio);
    IEnumerable<Estadio> SearchEstadios(string nombre);

}

}