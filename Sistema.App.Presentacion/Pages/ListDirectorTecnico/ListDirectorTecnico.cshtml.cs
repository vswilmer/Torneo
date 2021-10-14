using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema.App.Dominio;
using Sistema.App.Persistencia;

namespace Sistema.App.Presentacion.Pages
{
    public class ListDirectorTecnicoModel : PageModel
    {
        private static IRepositorioDirectorTecnico repoDirectorTecnico = new RepositorioDirectorTecnico(new Persistencia.AppContext());
        public IEnumerable<DirectorTecnico> DirectorTecnico {get; set;}
        
        //public List<DirectorTecnico> TraerDts()
        //{
        //    List<DirectorTecnico> listDirectorTecnico = new List<DirectorTecnico>();
        //    var Dts = _repoDirectorTecnico.GetAllDirectorTecnico();
        //    foreach (DirectorTecnico directorTecnico in Dts)
        //    {
        //        listDirectorTecnico.Add(directorTecnico);
        //   }
        //    return listDirectorTecnico;
        //}
        
        public void OnGet()
        {    
            DirectorTecnico = repoDirectorTecnico.GetAllDirectorTecnico();
        }
    }
}
