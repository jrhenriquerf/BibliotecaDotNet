using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class CampanhaMarketingInputModel
    {
        public int MarketingId { get; set; }

        public string Descricao { get; set; }

        public string DataInicio {get; set; }

        public string DataFim {get; set; }

        public double PercentualDesconto {get; set; }
    }

    public class CampanhaMarketingInputModelValidator : AbstractValidator<CampanhaMarketingInputModel>
    {
        public CampanhaMarketingInputModelValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("A Descricao é obrigatório.")
                            .Length(0, 100).WithMessage("A Descricao não pode exceder 100 caracteres.");  
        }
    }
}