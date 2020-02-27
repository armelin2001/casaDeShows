using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace casaDeShows.Controllers
{
    public class CompraEventoController : Controller
    {
        private readonly CompraEventoRepositorio _compraEventoRepositorio;
        private readonly EventoRepositorio _eventoRepositorio;
        private readonly GenerosRepositorio _generoRepositorio;
        private readonly CasaDeShowRepositorio _casaDeShowRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompraEventoController(CompraEventoRepositorio compraEventoRepositorio, EventoRepositorio eventoRepositorio, 
        GenerosRepositorio generoRepositorio, CasaDeShowRepositorio casaDeShowRepositorio, IHttpContextAccessor httpContextAccessor)
        {
            _compraEventoRepositorio = compraEventoRepositorio;
            _eventoRepositorio = eventoRepositorio;
            _generoRepositorio = generoRepositorio;
            _casaDeShowRepositorio = casaDeShowRepositorio;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        public IActionResult RealizandoCompra(int id)
        {
            ViewBag.Generos = _generoRepositorio.PegandoListaDeGeneros();
            ViewBag.CasasDeShow = _casaDeShowRepositorio.ListaCasaDeShows();
            var comprarEvento = _eventoRepositorio.BuscarEvento(id);
            var comprar = new CompraEvento()
            {
                Evento = comprarEvento,
                EventoId = id
            };
            return View(comprar);
        }
        [Authorize]
        [HttpPost]
        public IActionResult RealizandoCompra(CompraEvento com)
        {

            CompraEvento comprar = new CompraEvento();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var idEventoComprado = _eventoRepositorio.BuscarEvento(com.Evento.Id);
            comprar.UserId = userId; //TODO - pegar o id do usuario
            comprar.Evento = idEventoComprado;
            comprar.QtdIngresso = com.QtdIngresso;
            comprar.ValorCompra = com.ValorCompra * com.QtdIngresso;
            _compraEventoRepositorio.FazerCompra(comprar);
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Historico()
        {
            var historico = _compraEventoRepositorio.HistoricoDeCompras();
            return View(historico);
        }
    }
}