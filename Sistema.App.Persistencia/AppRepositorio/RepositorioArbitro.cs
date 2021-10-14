using System.Collections.Generic;
using System.Linq;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {

        /// <summary>
        /// Referencia al contexto de Municipio
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioArbitro(AppContext appContext)
        {
            _appContext = appContext;
        }

        Arbitro IRepositorioArbitro.AddArbitro(Arbitro arbitro)
        {
            var ArbitroAdicionado = _appContext.Arbitros.Add(arbitro);
            _appContext.SaveChanges();
            return ArbitroAdicionado.Entity;
        }

        void IRepositorioArbitro.DeleteArbitro(int idArbitro)
        {
            var ArbitroEncontrado = _appContext.Arbitros.FirstOrDefault(a => a.Id == idArbitro);
            if (ArbitroEncontrado == null)
                return;
            _appContext.Arbitros.Remove(ArbitroEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Arbitro> IRepositorioArbitro.GetAllArbitros()
        {
            return _appContext.Arbitros;
        }

        Arbitro IRepositorioArbitro.GetArbitro(int idArbitro)
        {
            return _appContext.Arbitros.FirstOrDefault(a => a.Id == idArbitro);
        }

        Arbitro IRepositorioArbitro.UpdateArbitro(int documento, Arbitro arbitro)
        {
            var ArbitroEncontrado = _appContext.Arbitros.FirstOrDefault(a => a.Documento == documento);
            if (ArbitroEncontrado != null)
            {
                ArbitroEncontrado.Nombre = arbitro.Nombre;
                ArbitroEncontrado.Apellido = arbitro.Apellido;
                ArbitroEncontrado.Documento = arbitro.Documento;
                ArbitroEncontrado.Telefono = arbitro.Telefono;
                ArbitroEncontrado.Escuela = arbitro.Escuela;



                _appContext.SaveChanges();

            }
            return ArbitroEncontrado;
        }




    }
}