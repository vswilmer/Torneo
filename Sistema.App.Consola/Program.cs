using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Sistema.App.Dominio;
using Sistema.App.Persistencia;

namespace Sistema.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Torneo Futbol");
            AddEstadio();

        }


        //private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static Sistema.App.Persistencia.AppContext appContext = new Sistema.App.Persistencia.AppContext();
        //private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext());
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio();
        

        //CRUD Estadio //

        private static void AddEstadio()
        {
            Estadio estadio = new Estadio
            {
                Nombre = "El Campín",
                //Id = 1,
                //NumeroTelefono = "3001645",
                //Genero = Genero.Masculino,
                Direccion = "Calle 56 No 28-94",
                //Longitud = 5.07062F,
                //Latitud = -75.52290F,
                Municipio = new Municipio {Nombre = "Bogota"}
                //FechaNacimiento = new DateTime(1990, 04, 12)
            };
            _repoEstadio.AddEstadio(estadio);
        }

        private static void BuscarEstadio(int idEstadio)
        {
            var estadio = _repoEstadio.GetEstadio(idEstadio);
            //Console.WriteLine(estadio.Nombre+" "+estadio.Id);
            Console.WriteLine(estadio.Nombre);
        }

        private static void MostrarEstadios()
        {
            var estadios = _repoEstadio.GetAllEstadios();
            foreach (var estadio in estadios)
            {
                //Console.WriteLine(estadio.Nombre+" "+estadio.Id+" esta en la ciudad "+estadio.Ciudad);
                Console.WriteLine(estadio.Nombre + " esta en la direccion " + estadio.Direccion);
            }

        }

        private static void BorrarEstadio(int idEstadio)
        {
            var estadio1 = _repoEstadio.GetEstadio(idEstadio);
            _repoEstadio.DeleteEstadio(idEstadio);
            //Console.WriteLine(estadio.Nombre+" "+estadio.Id);
            Console.WriteLine(estadio1.Nombre + " fue borrado de la base de datos");
        }

        /*private static void ActualizarEstadio(Estadio Estadio)
        {
             
             _repoEstadio.UpdateEstadio(Estadio.Id);
             //Console.WriteLine(estadio.Nombre+" "+estadio.Id);
             Console.WriteLine("Base de datos actualizada");
        }*/
        
        private static void AgregarMunicipio()
        {
            Municipio municipio = new Municipio
            {
                Nombre = "Bogota"
            };
            _repoMunicipio.AddMunicipio(municipio);
        }
    }
}
