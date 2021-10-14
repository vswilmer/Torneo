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
    public class ListMunicipioDetailsModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Municipio municipio {get; set;}
        public ListMunicipioDetailsModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }

        public IActionResult OnGet(int id)
        {
            municipio = _repoMunicipio.GetMunicipio(id);
            if(municipio == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
