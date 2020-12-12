using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class CampanhaMarketingRepository : Repository<CampanhaMarketing>, ICampanhaMarketingRepository
    {
        public CampanhaMarketingRepository(BibliotecaDbContext context) : base(context)
        {
            
        }

        public IEnumerable<CampanhaMarketing> GetCampanhaMarketingContemNome(string descricao)
        {
            return _context.Set<CampanhaMarketing>()
                .Where(a => a.Descricao.Contains(descricao));
        }

        public IEnumerable<CampanhaMarketing> GetCampanhaMarketingPorLivro(int idLivro)
        {
            return _context.CampanhaMarketing.AsNoTracking()
                .Include(l => l.LivMarketing)
                .Where(l => l.LivMarketing.Any(la => la.LivroID == idLivro));
        }
    }
}