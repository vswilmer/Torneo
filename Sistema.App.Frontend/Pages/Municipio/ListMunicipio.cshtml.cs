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
    public class ListMunicipioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        //private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        public IEnumerable<Municipio> municipios {get; set;}
        public ListMunicipioModel(IRepositorioMunicipio repoMunicipio)
        {
           _repoMunicipio = repoMunicipio;
        }
        
        public void OnGet()

        {
             municipios = _repoMunicipio.GetAllMunicipios();
        }
    }
}
