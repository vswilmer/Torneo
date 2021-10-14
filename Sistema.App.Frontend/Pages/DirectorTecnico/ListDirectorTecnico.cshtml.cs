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
    public class ListDirectorTecnicoModel : PageModel
    {
        private readonly IRepositorioDirectorTecnico _repoDirectorTecnico;
        
        public IEnumerable<DirectorTecnico> directorTecnico {get; set;}
        public ListDirectorTecnicoModel(IRepositorioDirectorTecnico repoDirectorTecnico)
        {
           _repoDirectorTecnico = repoDirectorTecnico;
        }
        public void OnGet()
        {
            
            directorTecnico = _repoDirectorTecnico.GetAllDirectorTecnico();
        }
    }
}