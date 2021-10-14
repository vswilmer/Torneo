using System;
using System.Collections.Generic;
using Sistema.App.Dominio;
namespace Sistema.App.Persistencia 
{

public interface IRepositorioPersona
{
    IEnumerable<Persona> GetAllPersonas();
    Persona AddPersona(Persona Persona);
    Persona UpdatePersona(Persona Persona);
    void DeletePersona(int idPersona);
    Persona GetPersona(int idPersona);

}

}