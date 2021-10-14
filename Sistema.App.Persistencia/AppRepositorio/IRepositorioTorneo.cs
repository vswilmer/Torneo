using System;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    ///Interface completa///
    public interface IRepositorioTorneo
    {
        Torneo AddTorneo(Torneo torneo);
        Torneo UpdateTorneo(int Id, Torneo NuevoTorneo);
        void DeleteTorneo(int idTorneo);
        Torneo GetTorneo(int idTorneo); 
    }
}