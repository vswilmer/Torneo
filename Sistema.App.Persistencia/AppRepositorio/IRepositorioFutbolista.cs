using System;
using System.Collections.Generic;
using Sistema.App.Dominio;

namespace Sistema.App.Persistencia
{
    ///Interface completa///
    public interface IRepositorioFutbolista
    {
        IEnumerable<Futbolista> GetAllFutbolista();
        Futbolista AddFutbolista(Futbolista futbolista);
        Futbolista UpdateFutbolista(int documento, Futbolista NuevoFutbolista);
        void DeleteFutbolista(int idFutbolista);
        Futbolista GetFutbolista(int idFutbolista); 
    }
}