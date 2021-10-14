using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Persistencia;
using Sistema.App.Dominio;

namespace Sistema.App.Frontend.pages
{
    public class ListDirectorTecnicoDetailsModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        public DirectorTecnico directorTecnico {get; set;}
        public ListDirectorTecnicoDetailsModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
           _repoDirectorTecnico = repoDirectorTecnico;
        }
        public IActionResult OnGet(int id)
        {
            directorTecnico = _repoDirectorTecnico.GetDirectorTecnico(id);
            if(directorTecnico == null)
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
