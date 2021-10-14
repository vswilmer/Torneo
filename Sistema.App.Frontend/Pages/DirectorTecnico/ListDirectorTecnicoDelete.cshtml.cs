using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Persistencia;
using Sistema.App.Dominio;

namespace Sistema.App.Frontend.Pages
{
    public class ListDirectorTecnicoDeleteModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        public DirectorTecnico directorTecnico { get; set; }
        public ListDirectorTecnicoDeleteModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
            _repoDirectorTecnico = repoDirectorTecnico;
        }
        public IActionResult OnGet(int id)
        {
            _repoDirectorTecnico.DeleteDirectorTecnico(id);
            if (directorTecnico == null)
            {
                return RedirectToPage("./ListDirectorTecnico");
            }
            else
            {
                return Page();
            }
        }
    }
}
