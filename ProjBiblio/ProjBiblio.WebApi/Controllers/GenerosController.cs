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

    public class GenerosController  : ControllerBase
    {
        private IGeneroService _generoService;

        public GenerosController(IGeneroService generoService)
        {
            this._generoService = generoService;
        }

        [HttpGet]
        public GeneroListViewModel Get()
        {
            return _generoService.Get();
        }

        [HttpGet("{id}", Name="GetGeneroDetails")]
        public ActionResult<GeneroViewModel> Get(int id) 
        { 
            var result = _generoService.Get(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public ActionResult Post([FromBody] GeneroInputModel genero)
        {
            var result = _generoService.Post(genero);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.GeneroId}, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GeneroInputModel genero)
        {
            if (id != genero.GeneroId)
            {
                return BadRequest();
            }

            var result = _generoService.Put(id, genero);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.GeneroId }, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<GeneroViewModel> Delete(int id)
        {
            var result = _generoService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}