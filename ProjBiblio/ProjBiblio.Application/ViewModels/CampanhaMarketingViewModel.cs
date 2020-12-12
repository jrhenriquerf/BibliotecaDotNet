namespace ProjBiblio.Application.ViewModels
{
    public class CampanhaMarketingViewModel
    {
        public int MarketingId { get; set; }

        public string Descricao { get; set; }

        public string DataInicio {get; set; }

        public string DataFim {get; set; }

        public double PercentualDesconto {get; set; }
    }
}