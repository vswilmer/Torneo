using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Dominio;
using Sistema.App.Persistencia;

namespace Sistema.App.Frontend.Page
{
    public class ListDirectorTecnicoCreateModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        public DirectorTecnico directorTecnico {get; set;}
        public ListDirectorTecnicoCreateModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
            _repoDirectorTecnico = repoDirectorTecnico;
        }
        public void OnGet()
        {
            directorTecnico = new DirectorTecnico();
        }
        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {
            if(ModelState.IsValid)
            {
                _repoDirectorTecnico.AddDirectorTecnico(directorTecnico);
                return RedirectToPage("ListDirectorTecnico");
            }
            else
            {
                return Page();
            }
        }
    }
}