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
    public class CampanhaMarketingService : ICampanhaMarketingService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public CampanhaMarketingService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public CampanhaMarketingListViewModel Get()
        {
            var campanhaMarketing = this._uow.CampanhaMarketingRepository.Get();

            return new CampanhaMarketingListViewModel()
            {
                CampanhaMarketing =  _mapper.Map<IEnumerable<CampanhaMarketingViewModel>>(campanhaMarketing)
            };
        }

        public CampanhaMarketingViewModel Get(int id)
        {
            var campanhaMarketing = this._uow.CampanhaMarketingRepository.GetById(a => a.MarketingID == id);
            return _mapper.Map<CampanhaMarketingViewModel>(campanhaMarketing);
        }

        public CampanhaMarketingViewModel Post(CampanhaMarketingInputModel campanhaMarketingInputModel)
        {
            var campanhaMarketing = _mapper.Map<CampanhaMarketing>(campanhaMarketingInputModel);

            _uow.CampanhaMarketingRepository.Add(campanhaMarketing);
            _uow.Commit();

            return _mapper.Map<CampanhaMarketingViewModel>(campanhaMarketing);
        }

        public CampanhaMarketingViewModel Put(int id, CampanhaMarketingInputModel campanhaMarketingInputModel)
        {
            var campanhaMarketing = _mapper.Map<CampanhaMarketing>(campanhaMarketingInputModel);

            _uow.CampanhaMarketingRepository.Update(campanhaMarketing);
            _uow.Commit();

            return _mapper.Map<CampanhaMarketingViewModel>(campanhaMarketing);
        }

        public CampanhaMarketingViewModel Delete(int id)
        {
            var campanhaMarketing = this._uow.CampanhaMarketingRepository.GetById(a => a.MarketingID == id);

            if (campanhaMarketing == null)
            {
                return null;
            }

            _uow.CampanhaMarketingRepository.Delete(campanhaMarketing);
            _uow.Commit();

            return _mapper.Map<CampanhaMarketingViewModel>(campanhaMarketing);
        }

        public IList<CampanhaMarketingSelectListDto> ListagemCampanhaMarketingPorLivro(int idLivro)
        {
            var campanhaMarketing = this._uow.CampanhaMarketingRepository.Get().ToList();
            var campanhaMarketingLivro = this._uow.CampanhaMarketingRepository.GetCampanhaMarketingPorLivro(idLivro);

            return (from a in campanhaMarketing
                    select new CampanhaMarketingSelectListDto
                    {
                        MarketingID = a.MarketingID,
                        Descricao = a.Descricao,
                        Selecionado = campanhaMarketingLivro.Any(la => la.MarketingID == a.MarketingID)
                    }).ToList();
        }
    }
}