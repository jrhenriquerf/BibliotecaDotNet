using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.ViewComponents
{
    public class GeneroListViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public GeneroListViewComponent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var produtos = await GetListagemGenerosAsync();
            return View(produtos);
        }

        private async Task<IEnumerable<GeneroViewModel>> GetListagemGenerosAsync()
        {
            var url = $"/Generos";
            var resposta = await _httpClient.GetFromJsonAsync<GeneroListViewModel>(url);

            return resposta.Generos;
        }
    }
}