using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;
using Microsoft.AspNetCore.Authorization;
namespace casaDeShows.Controllers
{
    public class CompraEventoController:Controller
    {
        private readonly CompraEventoRepositorio _compraEventoRepositorio;
        private readonly EventoRepositorio _eventoRepositorio;
        public CompraEventoController(CompraEventoRepositorio compraEventoRepositorio,EventoRepositorio eventoRepositorio){
            _compraEventoRepositorio = compraEventoRepositorio;
            _eventoRepositorio = eventoRepositorio;
        }

        public IActionResult RealizandoCompra(int id){
            var comprarEvento = _eventoRepositorio.BuscarEvento(id);
            var comprar = new CompraEvento(){
                Evento = comprarEvento,
                EventoId = id
            };
            return View(comprar);
        }
        [Authorize]
        [HttpPost]
        public IActionResult RealizandoCompra(CompraEvento com){
            if(ModelState.IsValid){
                CompraEvento comprar = new CompraEvento();
                comprar.Evento = _eventoRepositorio.BuscarEvento(com.EventoId);
                comprar.QtdIngresso = com.QtdIngresso;
                comprar.ValorCompra = com.ValorCompra*com.QtdIngresso;
                _compraEventoRepositorio.FazerCompra(comprar);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("RealizandoCompra");    
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Historico(){
            var historico = _compraEventoRepositorio.HistoricoDeCompras();
            return View(historico);
        }
    }
}