using System.Collections.Generic;
using Sistema.App.Dominio;


namespace Sistema.App.Persistencia

{
    public interface IRepositorioArbitro
    {
        IEnumerable<Arbitro> GetAllArbitros();

        Arbitro AddArbitro(Arbitro arbitro);

        Arbitro UpdateArbitro(int documento, Arbitro arbitro);

        void DeleteArbitro(int idArbitro);

        Arbitro GetArbitro(int idArbitro);


        




    }

}