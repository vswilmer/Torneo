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
    public class CreateModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio {get; set;}
        public CreateModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public void OnGet()
        {
            estadio = new Estadio();
        }

        public IActionResult OnPost(Estadio estadio)
        {
            if(ModelState.IsValid)
            {
                _repoEstadio.AddEstadio(estadio);
                return RedirectToPage("ListEstadio");
            }
            else
            {
                return Page();
            }
        }
    }
}
