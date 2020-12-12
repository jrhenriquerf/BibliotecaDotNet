using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class GeneroService : IGeneroService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public GeneroService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public GeneroListViewModel Get()
        {
            var generos = this._uow.GeneroRepository.Get();

            return new GeneroListViewModel()
            {
                Generos =  _mapper.Map<IEnumerable<GeneroViewModel>>(generos)
            };
        }

        public GeneroViewModel Get(int id)
        {
            var genero = this._uow.GeneroRepository.GetById(a => a.GeneroID == id);
            return _mapper.Map<GeneroViewModel>(genero);
        }

        public GeneroViewModel Post(GeneroInputModel autorInputModel)
        {
            var genero = _mapper.Map<Genero>(autorInputModel);

            _uow.GeneroRepository.Add(genero);
            _uow.Commit();

            return _mapper.Map<GeneroViewModel>(genero);
        }

        public GeneroViewModel Put(int id, GeneroInputModel autorInputModel)
        {
            var genero = _mapper.Map<Genero>(autorInputModel);

            _uow.GeneroRepository.Update(genero);
            _uow.Commit();

            return _mapper.Map<GeneroViewModel>(genero);
        }

        public GeneroViewModel Delete(int id)
        {
            var genero = this._uow.GeneroRepository.GetById(a => a.GeneroID == id);

            if (genero == null)
            {
                return null;
            }

            _uow.GeneroRepository.Delete(genero);
            _uow.Commit();

            return _mapper.Map<GeneroViewModel>(genero);
        }
    }
}