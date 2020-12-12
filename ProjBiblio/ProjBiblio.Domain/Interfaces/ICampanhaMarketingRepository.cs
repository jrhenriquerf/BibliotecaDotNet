using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface ICampanhaMarketingRepository : IRepository<CampanhaMarketing>
    {
        IEnumerable<CampanhaMarketing> GetCampanhaMarketingContemNome(string descricao);

        IEnumerable<CampanhaMarketing> GetCampanhaMarketingPorLivro(int idLivro);
    }
}