using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CampanhaMarketingController  : ControllerBase
    {
        private ICampanhaMarketingService _campanhaMarketingService;

        public CampanhaMarketingController(ICampanhaMarketingService campanhaMarketingService)
        {
            this._campanhaMarketingService = campanhaMarketingService;
        }

        [HttpGet]
        public CampanhaMarketingListViewModel Get()
        {
            return _campanhaMarketingService.Get();
        }

        [HttpGet("{id}", Name="GetCampanhaMarketingDetails")]
        public ActionResult<CampanhaMarketingViewModel> Get(int id) 
        { 
            var result = _campanhaMarketingService.Get(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CampanhaMarketingInputModel campanhaMarketing)
        {
            var result = _campanhaMarketingService.Post(campanhaMarketing);

            return new CreatedAtRouteResult("GetCampanhaMarketingDetails", 
                new { id = result.MarketingId}, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CampanhaMarketingInputModel campanhaMarketing)
        {
            if (id != campanhaMarketing.MarketingId)
            {
                return BadRequest();
            }

            var result = _campanhaMarketingService.Put(id, campanhaMarketing);

            return new CreatedAtRouteResult("GetCampanhaMarketingDetails", 
                new { id = result.MarketingId }, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<CampanhaMarketingViewModel> Delete(int id)
        {
            var result = _campanhaMarketingService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("listcampanhamaketinglivro/{id}")]
        public IList<CampanhaMarketingSelectListDto> ListagemCampanhaMarketingPorLivro(int id)
        {
            var result = _campanhaMarketingService.ListagemCampanhaMarketingPorLivro(id);

            return result;
        }
    }
}