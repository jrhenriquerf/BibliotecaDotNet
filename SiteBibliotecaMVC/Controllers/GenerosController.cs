using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SiteBibliotecaMVC.Models;

namespace SiteBibliotecaMVC.Controllers
{
    public class GenerosController : Controller
    {
        private readonly ILogger<GenerosController> _logger;
        private readonly HttpClient _httpClient;

        public GenerosController(ILogger<GenerosController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: Generos
        public async Task<IActionResult> Index()
        {
            var url = $"/Generos";
            var resposta = await _httpClient.GetFromJsonAsync<GeneroListViewModel>(url);

            return View("List", resposta.Generos);
        }

        // GET: Generos/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Generos/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<GeneroViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Generos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] GeneroViewModel genero)
        {
            var url = $"/Generos";
            var resposta = await _httpClient.PostAsJsonAsync<GeneroViewModel>(url, genero);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var mensagens = await resposta.Content.ReadFromJsonAsync<BadRequestResponse>();

            foreach (var atrError in mensagens.Errors)
            {
                foreach(var erro in atrError.Value)
                    ModelState.AddModelError(atrError.Key, erro);
            }
                
            return View(genero);
        }

        // GET: Generos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Generos/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<GeneroViewModel>(url);
            return View(resposta);
        }

        // POST: Generos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] GeneroViewModel genero)
        {
            if (id != genero.GeneroId)
            {
                return NotFound();
            }

            var url = $"/Generos/{id}";
            var resposta = await _httpClient.PutAsJsonAsync<GeneroViewModel>(url, genero);

            if (resposta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ErrorMessage = resposta;
                
            return View(resposta);
        }

        // GET: Generos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"/Generos/{id}";
            var resposta = await _httpClient.GetFromJsonAsync<GeneroViewModel>(url);

            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Generos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = $"/Generos/{id}";
            var resposta = await _httpClient.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }
    }
}
