using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class CampanhaMarketingListViewModel
    {
        public IEnumerable<CampanhaMarketingViewModel> CampanhaMarketing { get; set; }
    }
}