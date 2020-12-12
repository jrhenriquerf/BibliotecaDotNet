namespace ProjBiblio.Domain.Entities
{
    public class CampanhaMarketingLivro
    {
        public int LivroID { get; set; }
        public Livro Livro { get; set; }

        public int MarketingID { get; set; }
        public CampanhaMarketing CampanhaMarketing { get; set; }
    }
}