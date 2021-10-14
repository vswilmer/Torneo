using System.Collections.Generic;
using System.Linq;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia 
{

public class RepositorioPersona : IRepositorioPersona
    {

        /// <summary>
        /// Referencia al contexto Persona
        /// </summary>

        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo constructor utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        Persona IRepositorioPersona.AddPersona(Persona Persona)
        {
            var PersonaAdicionado = _appContext.Personas.Add(Persona);
            _appContext.SaveChanges();
            return PersonaAdicionado.Entity;
        }

        void IRepositorioPersona.DeletePersona(int idPersona)
        {
            var PersonaEncontrado = _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
            if (PersonaEncontrado == null)
            return;
            _appContext.Personas.Remove(PersonaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas()
        {
            return _appContext.Personas;
        }

        Persona IRepositorioPersona.GetPersona(int idPersona)
        {
            return _appContext.Personas.FirstOrDefault(p => p.Id == idPersona);
        }

        Persona IRepositorioPersona.UpdatePersona(Persona Persona)
        {
            var PersonaEncontrado = _appContext.Personas.FirstOrDefault(p => p.Id == Persona.Id);
            if (PersonaEncontrado != null)
            {
                PersonaEncontrado.Nombre=Persona.Nombre;
                PersonaEncontrado.Apellido=Persona.Apellido;
                PersonaEncontrado.Id=Persona.Id;
                PersonaEncontrado.Telefono=Persona.Telefono;
                //PersonaEncontrado.Municipio=Persona.Municipio;
                //PersonaEncontrado.Genero=Persona.Genero;
                //PersonaEncontrado.Direccion=Persona.Direccion;
                //PersonaEncontrado.Latitud=Persona.Latitud;
                //PersonaEncontrado.Longitud=Persona.Longitud;
                //PersonaEncontrado.Ciudad=Persona.Ciudad;
                //PersonaEncontrado.FechaNacimiento=Persona.FechaNacimiento;
                //PersonaEncontrado.Familiar=Persona.Familiar;
                //PersonaEncontrado.Enfermera=Persona.Enfermera;
                //PersonaEncontrado.Medico=Persona.Medico;
                //PersonaEncontrado.Historia=Persona.Historia;

                _appContext.SaveChanges();
    
            }
            return PersonaEncontrado;
        }

    }

}