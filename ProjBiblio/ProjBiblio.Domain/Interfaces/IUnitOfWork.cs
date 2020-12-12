using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAutorRepository AutorRepository { get; }

        ICampanhaMarketingRepository CampanhaMarketingRepository { get; }

        ILivroRepository LivroRepository { get; }

        ICarrinhoRepository CarrinhoRepository { get; }

        IUsuarioRepository UsuarioRepository { get; }

        IGeneroRepository GeneroRepository { get; }

        IEmprestimoRepository EmprestimoRepository { get; }

         void Commit();
    }
}