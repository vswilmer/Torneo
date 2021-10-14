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
    public class ListEstadioDetailsModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public Estadio estadio {get; set;}
        public ListEstadioDetailsModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio = repoEstadio;
        }

        public IActionResult OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            if(estadio == null)
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
