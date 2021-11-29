using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Dominio;

namespace WebApplication.Repo
{
    public interface IEFcoreRepository
    {
       

        void Add<t>(t entity) where t : class;
        void Update<t>(t entity) where t : class;
        void Delete<t>(t entity) where t : class;

        Task<bool> SaveCHangeAsync();
        Task<Heroi[]> GetAllHerois(bool incluirBatalha =false);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha=false);
        Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha=false);

        Task<Batalha[]> GetAllBatalhas(bool incluirHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);
        


    }
}
