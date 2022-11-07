using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {

        private readonly ProEventosContext context;
        public PalestrantePersistence(ProEventosContext context)
        {
            this.context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(p => p.RedesSociais)
               .AsNoTracking();

            if (includeEventos)
            {
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(e => e.RedesSociais)
               .AsNoTracking();

            if (includeEventos)
            {
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
               .Include(e => e.RedesSociais)
               .AsNoTracking();

            if (includeEventos)
            {
                query = query
                        .Include(p => p.PalestrantesEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                    .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}