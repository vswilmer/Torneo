using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Persistencia;
using Sistema.App.Dominio;

namespace Sistema.App.Frontend.Pages.Estadios
{
    public class ListEstadioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        //private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext());
        public IEnumerable<Estadio> estadios {get; set;}
        public string bActual {get; set;}
        public ListEstadioModel(IRepositorioEstadio repoEstadio)
        {
           _repoEstadio = repoEstadio;
        }
        public void OnGet(string b)
        {
            if (String.IsNullOrEmpty(b))
            {
                bActual = "";
                estadios = _repoEstadio.GetAllEstadios();
            }
            else{
               bActual = b;
               estadios = _repoEstadio.SearchEstadios(b);
             }

/*
            if (g.HasValue && g.Value != -1)
            {
                gActual = g.Value;    
                pacientes = _repoPaciente.GetPacientesGenero(g.Value);
            }
            else{
               gActual = -1;
               pacientes = _repoPaciente.GetAllPacientes();
             }
*/            
        }
    }
}
