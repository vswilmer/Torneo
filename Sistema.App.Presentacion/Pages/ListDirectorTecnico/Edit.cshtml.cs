using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Dominio;
using Sistema.App.Persistencia;

namespace Sistema.App.Presentacion.Pages
{
    public class EditModel : PageModel
    {
        private static IRepositorioDirectorTecnico repoDirectorTecnico = new RepositorioDirectorTecnico(new Persistencia.AppContext());
        private DirectorTecnico DirectorTecnico {get; set;}
        
//        public DirectorTecnico TraerDirectorTecnico (int idDirectorTecnico)
//        {
//            var DirectorTecnicoEncontrado = repoDirectorTecnico.GetDirectorTecnico(idDirectorTecnico);
//        }
        public IActionResult OnGet(int idDirectorTecnico)
       {
            DirectorTecnico = repoDirectorTecnico.GetDirectorTecnico(idDirectorTecnico);
            if (DirectorTecnico == null)
            {
                return RedirectToPage("./NotFound");           
            }
            else
            {
                return Page();
            }
        }
    }
}

