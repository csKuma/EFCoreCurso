using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Dominio;
using WebApplication2.Repo;

namespace WebApplication.Repo
{
    public class EFcoreRepository : IEFcoreRepository

    {
        private readonly HeroiContext _context;

        public EFcoreRepository( HeroiContext context) // contexto
        {
            _context = context;
        }
        public void Add<t>(t entity) where t : class //adicionar entidade
        {
            _context.Add(entity);
        }

        public void Delete<t>(t entity) where t : class // remover enditade
        {
            _context.Remove(entity);
        }

        public void Update<t>(t entity) where t : class //atualizar endidade
          {
            _context.Update(entity);
          }

        public async Task<bool> SaveCHangeAsync()
        {
          return  (await _context.SaveChangesAsync())>0; 
        }

        public async Task<Heroi[]> GetAllHerois(bool incluirBatalha = false) //listar todos os herois
        {
            IQueryable<Heroi> heroi = _context.Herois
                .Include(h => h.Identidade)
                .Include(h => h.Armas);
            if(incluirBatalha)
            {
              heroi = heroi.Include(h => h.HeroisBatalhas)
                            .ThenInclude(heroib => heroib.Batalha);
            }
          
            heroi = heroi.AsNoTracking().OrderBy(h => h.Id);

           return await heroi.ToArrayAsync();
        }

        public async Task<Heroi> GetHeroiById(int id, bool incluirBatalha=false) //lista os herois por id
        {

            IQueryable<Heroi> heroi = _context.Herois
                .Include(h => h.Identidade)
                .Include(h => h.Armas);
            if (incluirBatalha)
            {
                heroi = heroi.Include(h => h.HeroisBatalhas)
                              .ThenInclude(heroib => heroib.Batalha);
            }

            heroi = heroi.AsNoTracking().OrderBy(h => h.Id);

            return await heroi.FirstOrDefaultAsync(h=>h.Id == id);
        }

        public async Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha=false) // lista os herois por nome
        {

            IQueryable<Heroi> heroi = _context.Herois
                .Include(h => h.Identidade)
                .Include(h => h.Armas);
            if (incluirBatalha)
            {
                heroi = heroi.Include(h => h.HeroisBatalhas)
                              .ThenInclude(heroib => heroib.Batalha);
            }

            heroi = heroi.AsNoTracking()
                .Where(h => h.Nome.Contains(nome))
                .OrderBy(h => h.Id);

            return await heroi.ToArrayAsync();
        }

        public async Task<Batalha[]> GetAllBatalhas(bool incluirHerois = false) /// listar todas as batalhas 
        {
            IQueryable<Batalha> batalha = _context.Batalhas;

            if (incluirHerois)
            {
                batalha = batalha.Include(h => h.HeroisBatalhas)
                              .ThenInclude(heroi => heroi.Heroi);
            }

            batalha = batalha.AsNoTracking().OrderBy(h => h.Id);

            return await batalha.ToArrayAsync();
        }

        public async Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false) //listar todas as batalhas por id

        {
            IQueryable<Batalha> batalha = _context.Batalhas;
               
            if (incluirHerois)
            {
                batalha = batalha.Include(h => h.HeroisBatalhas)
                              .ThenInclude(heroib => heroib.Batalha);
            }

            batalha = batalha.AsNoTracking().OrderBy(h => h.Id);

            return await batalha.FirstOrDefaultAsync(h => h.Id == id);

        }

    }
}
