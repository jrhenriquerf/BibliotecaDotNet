using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class GeneroInputModel
    {
        public int GeneroId { get; set; }
        
        public string Descricao { get; set; }
    }

    public class GeneroInputModelValidator : AbstractValidator<GeneroInputModel>
    {
        public GeneroInputModelValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("A Descrição é obrigatória.")
                            .Length(0, 500).WithMessage("A Descrição não pode exceder 500 caracteres.");  
        }
    }
}