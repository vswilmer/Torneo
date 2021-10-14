using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Persistencia;
using Sistema.App.Dominio;

namespace Sistema.App.Frontend.Pages
{
    public class ListEstadioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        //private static IRepositorioEstadio _repoEstadio = new RepositorioEstadio(new Persistencia.AppContext());
        public IEnumerable<Estadio> estadios {get; set;}
        public ListEstadioModel(IRepositorioEstadio repoEstadio)
        {
           _repoEstadio = repoEstadio;
        }
        public void OnGet()
        {
            estadios = _repoEstadio.GetAllEstadios();
        }
    }
}
