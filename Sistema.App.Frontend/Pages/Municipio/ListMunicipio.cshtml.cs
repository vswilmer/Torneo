using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Persistencia;
using Sistema.App.Dominio;

namespace Sistema.App.Frontend.Pages.Municipios
{
    public class ListMunicipioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        //private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        public IEnumerable<Municipio> municipios {get; set;}
        public string bActual {get; set;}
        public ListMunicipioModel(IRepositorioMunicipio repoMunicipio)
        {
           _repoMunicipio = repoMunicipio;
        }
        
       /* public void OnGet()

        {
             municipios = _repoMunicipio.GetAllMunicipios();
        }*/

        public void OnGet(string b)
        {
            if (String.IsNullOrEmpty(b))
            {
                bActual = "";
                municipios = _repoMunicipio.GetAllMunicipios();
            }
            else{
               bActual = b;
               municipios = _repoMunicipio.SearchMunicipios(b);
             }

/*
            if (g.HasValue && g.Value != -1)
            {
                gActual = g.Value;    
                municipios = _repoMunicipio.GetMunicipiosGenero(g.Value);
            }
            else{
               gActual = -1;
               municipios = _repoMunicipio.GetAllMunicipios();
             }
*/            
        }

    }
}
