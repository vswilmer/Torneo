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
    public class ListDirectorTecnicoEditModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        [BindProperty]
        public DirectorTecnico directorTecnico { get; set; }
        public ListDirectorTecnicoEditModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
            _repoDirectorTecnico = repoDirectorTecnico;
        }
        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
            {
                directorTecnico = _repoDirectorTecnico.GetDirectorTecnico(id.Value);
            }
            else
            {
                DirectorTecnico directorTecnico = new DirectorTecnico();
            }
            if (directorTecnico == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(DirectorTecnico directorTecnico)
        {
            if(directorTecnico.Id>0)
            {
                _repoDirectorTecnico.UpdateDirectorTecnico(directorTecnico);
            }
            else
            {
                _repoDirectorTecnico.AddDirectorTecnico(directorTecnico);
            }
            return RedirectToPage("./ListDirectorTecnico");
        }
    }
}
