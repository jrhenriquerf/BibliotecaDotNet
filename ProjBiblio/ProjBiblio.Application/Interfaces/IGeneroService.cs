using System.Collections.Generic;
using System.Threading.Tasks;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IGeneroService
    {
        GeneroListViewModel Get();

        GeneroViewModel Get(int id);

        GeneroViewModel Post(GeneroInputModel genero);

        GeneroViewModel Put(int id, GeneroInputModel genero);

        GeneroViewModel Delete(int id);
    }
}