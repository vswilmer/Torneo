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
            //comentario
            //AgregarDirectorTecnico();
            //BuscarDirectorTecnico(1);
            //EliminarDirectorTecnico(1);
            //ActualizarDirectorTecnico();
            //MostrarDirectoresTecnicos();

            //AgregarFutbolista();
            //BuscarFutbolista(2);
            //EliminarFutbolista(1);
            //EliminarFutbolista(1);
            //ActualizarFutbolista();
            //MostrarFutbolistas();

            //AgregarTorneo();
            //BuscarTorneo(2);
            //EliminarTorneo(3);
            //ActualizarTorneo();

            //AddMunicipio();
            //BuscarMunicipio(1);
            //DeleteMunicipio(1);
            //UpdateMunicipio();

            //AddPartido();
            //BuscarPartido(1);
            //DeletePartido(7);
            //UpdatePartido();
            //AsignarEquipoLocal();
            //AsignarEquipoVisitante();
            //AsignarArbitro();
            //AsignarEstadio();


            //AddArbitro();
            //BuscarArbitro(6);
            //DeleteArbitro(7);
            //UpdateArbitro();

            //AddEstadio();
            //BuscarEstadio(2);
            //MostrarEstadios();
            //BorrarEstadio(2);

        }

        private static IRepositorioDirectorTecnico _repoDirectorTecnico = new repoDirectorTecnico();
        private static IRepositorioFutbolista _repoFutbolista = new RepositorioFutbolista(new Persistencia.AppContext());
        private static IRepositorioTorneo _repoTorneo = new RepositorioTorneo(new Persistencia.AppContext());
        //private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido(new Persistencia.AppContext());
        private static IRepositorioArbitro _repoArbitro = new RepositorioArbitro(new Persistencia.AppContext());
        //private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext());
        private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio();


        /// CRUD director tecnico ///

        private static void MostrarDirectoresTecnicos()
        {
            var TodosDts = _repoDirectorTecnico.GetAllDirectorTecnico();

            foreach (DirectorTecnico directorTecnico in TodosDts)
            {
                Console.WriteLine(directorTecnico.Nombre + " " + directorTecnico.Apellido);
            }
        }
        private static void AgregarDirectorTecnico()
        {
            var Dt = new DirectorTecnico
            {
                Nombre = "Santiago",
                Apellido = "Viana",
                Documento = 1234,
                Telefono = "3197499064"
            };
            _repoDirectorTecnico.AddDirectorTecnico(Dt);
        }
        private static void BuscarDirectorTecnico(int idDirectorTecnico)
        {
            var directorTecnico = _repoDirectorTecnico.GetDirectorTecnico(idDirectorTecnico);
            Console.WriteLine(directorTecnico.Nombre + " " + directorTecnico.Apellido);
        }
        private static void EliminarDirectorTecnico(int idDirectorTecnico)
        {
            _repoDirectorTecnico.DeleteDirectorTecnico(idDirectorTecnico);
        }
        private static void ActualizarDirectorTecnico()
        {
            Console.WriteLine("Por favor digite el documento que desea modificar");
            int documento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo número telefónico: ");
            string telefono = Console.ReadLine();
            var NuevoDt = new DirectorTecnico
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono
            };

            var directorTecnico = _repoDirectorTecnico.UpdateDirectorTecnico(documento, NuevoDt);
            Console.WriteLine("---");
            Console.WriteLine("Director tecnico actualizado:");
            Console.WriteLine(directorTecnico.Nombre + " " + directorTecnico.Apellido);
        }

        /// CRUD director tecnico ///

        /// CRUD Futbolista ///

        private static void MostrarFutbolistas()
        {
            var TodosFutbolistas = _repoFutbolista.GetAllFutbolista();

            foreach (Futbolista futbolista in TodosFutbolistas)
            {
                Console.WriteLine(futbolista.Nombre + " " + futbolista.Apellido);
            }
        }
        private static void AgregarFutbolista()
        {
            var futbolista = new Futbolista
            {
                Nombre = "Santiago",
                Apellido = "Viana",
                Documento = 1234,
                Telefono = "3197499064",
                NumeroCamiseta = 1,
                PosicionCancha = "Defensa"
            };
            _repoFutbolista.AddFutbolista(futbolista);
        }
        private static void BuscarFutbolista(int idFutbolista)
        {

            var futbolista = _repoFutbolista.GetFutbolista(idFutbolista);
            Console.WriteLine(futbolista.Nombre + " " + futbolista.Apellido);
        }
        private static void EliminarFutbolista(int idFutbolista)
        {
            _repoFutbolista.DeleteFutbolista(idFutbolista);
        }
        private static void ActualizarFutbolista()
        {
            Console.WriteLine("Por favor digite el documento que desea modificar");
            int documento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo número telefónico: ");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Numero de camiseta: ");
            int numerocamiseta = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nueva posicion en la cancha: ");
            string posicioncancha = Console.ReadLine();
            var NuevoFutbolista = new Futbolista
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                NumeroCamiseta = numerocamiseta,
                PosicionCancha = posicioncancha

            };

            var futbolista = _repoFutbolista.UpdateFutbolista(documento, NuevoFutbolista);
            Console.WriteLine("---");
            Console.WriteLine("Futbolista actualizado:");
            Console.WriteLine(futbolista.Nombre + " " + futbolista.Apellido);
        }

        /// CRUD Futbolista ///

        /// CRUD Torneo (toca hacer unos cambios es mas COMPLEJO) ///

        private static void AgregarTorneo()
        {
            var torneo = new Torneo
            {
            };
            _repoTorneo.AddTorneo(torneo);
        }
        private static void BuscarTorneo(int idTorneo)
        {
            var torneo = _repoTorneo.GetTorneo(idTorneo);
            Console.WriteLine("Torneo encontrado");
        }
        private static void EliminarTorneo(int idTorneo)
        {
            _repoTorneo.DeleteTorneo(idTorneo);
        }
        private static void ActualizarTorneo()
        {

        }

        /// CRUD Torneo ///

        // Implementacion de Repositorio Municipio---------------------



        private static void AddMunicipio()
        {
            var Municipio = new Municipio
            {
                Nombre = "Soacha",



            };
            _repoMunicipio.AddMunicipio(Municipio);

        }

        private static void BuscarMunicipio(int idMunicipio)
        {
            var Municipio = _repoMunicipio.GetMunicipio(idMunicipio);
            Console.WriteLine(Municipio.Nombre + " ");
        }


        private static void DeleteMunicipio(int idMunicipio)
        {
            var Municipio = new Municipio
            {
                Id = idMunicipio,
            };

            _repoMunicipio.DeleteMunicipio(idMunicipio);

        }

        private static void UpdateMunicipio()
        {
            Console.WriteLine("Por favor digite el municipio que desea modificar");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo nombre: ");
            string nombreN = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombreN,
            };
            var nuevoMunicipio = _repoMunicipio.UpdateMunicipio(nombre, municipio);
            Console.WriteLine("---");
            Console.WriteLine("Municipio actualizado:");
            Console.WriteLine(nuevoMunicipio.Nombre + " ");

        }

        // Implementacion de Repositorio Partido---------------------


        private static void AddPartido()
        {

            var Partido = new Partido
            {

                Hora = DateTime.Parse("08:30"),
                Fecha = DateTime.Parse("2021/10/02"),



            };
            _repoPartido.AddPartido(Partido);

        }


        private static void BuscarPartido(int idPartido)
        {
            var Partido = _repoPartido.GetPartido(idPartido);
            if (Partido.Local == null && Partido.Visitante == null)
            {
                Console.WriteLine("No se encontraron equipos para el partido fecha: " + Partido.Fecha + " Hora: " + Partido.Hora);
            }
            else
            {
                Console.WriteLine("El partido sera entre: " + Partido.Local + " Local" + Partido.Visitante + " Visitante Fecha: " + Partido.Fecha + " Hora: " + Partido.Hora + " Arbitro: " + Partido.Arbitro + " Cancha: " + Partido.Cancha + " ");
            }

        }


        private static void DeletePartido(int idPartido)
        {
            var Partido = new Partido
            {
                Id = idPartido,
            };

            _repoPartido.DeletePartido(idPartido);

        }


        private static void UpdatePartido()
        {
            Console.WriteLine("Por favor ingrese el ID del partido: ");
            int idPartido = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva fecha: ");
            DateTime fechaN = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva hora: ");
            DateTime horaN = DateTime.Parse(Console.ReadLine());
            var partido = new Partido
            {
                Fecha = fechaN,
                Hora = horaN,
            };
            var nuevoPartido = _repoPartido.UpdatePartido(idPartido, partido);
            Console.WriteLine("---");
            Console.WriteLine("Partido actualizado:");
            Console.WriteLine(nuevoPartido.Fecha + " " + nuevoPartido.Hora + " ");

        }

        //Asignación
        private static void AsignarEquipoLocal()
        {
            var local = _repoPartido.AsignarEquipoLocal(7, 7);
            Console.WriteLine(local.nombre + " ");
        }
        private static void AsignarEquipoVisitante()
        {
            var visitante = _repoPartido.AsignarEquipoVisitante(7, 7);
            Console.WriteLine(visitante.nombre + " ");
        }
        private static void AsignarArbitro()
        {
            var arbitro = _repoPartido.AsignarArbitro(7, 7);
            Console.WriteLine(arbitro.Nombre + " " + arbitro.Apellido);
        }

        private static void AsignarEstadio()
        {
            var estadio = _repoPartido.AsignarEstadio(1, 1);
            Console.WriteLine(estadio.Nombre + " " + estadio.Municipio);
        }


        // Implementacion de Repositorio Arbitro---------------------

        private static void AddArbitro()
        {
            var Arbitro = new Arbitro
            {
                Nombre = "julian",
                Apellido = "jimenez",
                Documento = 10423596,
                Telefono = "31245981",
                Escuela = "Educa Arbitros",


            };
            _repoArbitro.AddArbitro(Arbitro);

        }

        private static void BuscarArbitro(int idArbitro)
        {
            var Arbitro = _repoArbitro.GetArbitro(idArbitro);
            Console.WriteLine(Arbitro.Nombre + " " + Arbitro.Apellido + " " + Arbitro.Documento + " " + Arbitro.Telefono + " " + Arbitro.Escuela + " ");
        }


        private static void DeleteArbitro(int idArbitro)
        {
            var Arbitro = new Arbitro
            {
                Id = idArbitro,
            };

            _repoArbitro.DeleteArbitro(idArbitro);

        }

        private static void UpdateArbitro()
        {
            Console.WriteLine("Por favor digite el documento del arbitro que desea modificar");
            int documento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo número telefónico: ");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese nueva Escuela: ");
            string escuela = Console.ReadLine();
            var arbitro = new Arbitro
            {
                Nombre = nombre,
                Apellido = apellido,
                Documento = documento,
                Telefono = telefono,
                Escuela = escuela,
            };
            var nuevoArbitro = _repoArbitro.UpdateArbitro(documento, arbitro);
            Console.WriteLine("---");
            Console.WriteLine("Arbitro actualizado:");
            Console.WriteLine(nuevoArbitro.Nombre + " " + nuevoArbitro.Apellido + " " + nuevoArbitro.Documento + " " + nuevoArbitro.Telefono + " " + nuevoArbitro.Escuela + " ");

        }

        //CRUD Estadio //

        private static void AddEstadio()

        {
            var estadio = new Estadio

            {
                Nombre = "El Campín",
                //Id = 1,
                //NumeroTelefono = "3001645",
                //Genero = Genero.Masculino,
                Direccion = "Calle 56 No 28-94",
                //Longitud = 5.07062F,
                //Latitud = -75.52290F,
                //Municipio = Municipio.Id(2)
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







    }
}
