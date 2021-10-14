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
    public class AddMunicipioModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioMunicipio _repoMunicipio;
        public Estadio estadio {get; set;}
        public IEnumerable<Municipio> municipios {get; set;}
        public AddMunicipioModel(IRepositorioEstadio repoEstadio, IRepositorioMunicipio repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(int idEstadio, int idMunicipio)
        {
            _repoEstadio.AsignarMunicipio(idEstadio, idMunicipio);
            return RedirectToPage("ListEstadioDetails", new{id = idEstadio});
        }
    }
}
