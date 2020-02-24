using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;
namespace casaDeShows.Controllers
{
    public class CompraIngresso:Controller
    {
        private readonly EventoRepositorio _eventoRepositorio;
        public CompraIngresso(EventoRepositorio eventoRepositorio){
            _eventoRepositorio = eventoRepositorio;
        }
        [HttpGet]
        public IActionResult RealizandoCompra(int id){
            var pegandoEvento = _eventoRepositorio.BuscarEvento(id);
            int ingresso = pegandoEvento.Capacidade;
            return View(pegandoEvento);
        }
        [HttpPost]
        public IActionResult RealizandoCompra(Evento evento){
            int ingresso = evento.Capacidade;
            if(ingresso<=evento.Capacidade){
                int retirandoIngresso = ingresso - evento.Capacidade;
                _eventoRepositorio.EditarEvento(evento);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("RealizandoCompra");
            }
        }
    }
}