using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class GeneroListViewModel
    {
        public IEnumerable<GeneroViewModel> Generos { get; set; }
    }
}