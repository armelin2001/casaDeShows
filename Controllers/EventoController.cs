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
    public class EventoController:Controller
    {
        private readonly EventoRepositorio _eventoRepositorio;
        private readonly CasaDeShowRepositorio _casaDeShowRepositorio;
        private readonly GenerosRepositorio _generoRepositorio;

        public EventoController(EventoRepositorio eventoRepositorio, CasaDeShowRepositorio casaDeShowRepositorio, GenerosRepositorio generoRepositorio){
            _eventoRepositorio = eventoRepositorio;
            _casaDeShowRepositorio = casaDeShowRepositorio;
            _generoRepositorio = generoRepositorio;
            
        }
        [Authorize(Policy="Usuario")]
        [HttpGet]
        public IActionResult FaltaEvento(){
            return View();
        }
        [Authorize(Policy="Usuario")]
        [HttpGet]
        public IActionResult NovoEventoFormulario(){
            ViewBag.Generos = _generoRepositorio.PegandoListaDeGeneros();
            ViewBag.CasasDeShow = _casaDeShowRepositorio.ListaCasaDeShows();
            var checarListaCasaDeshow = _casaDeShowRepositorio.ListaCasaDeShows();
            int tamanhoLista = checarListaCasaDeshow.Count;
            if(tamanhoLista>0){
                return View();
            }
            else{
                return View("FaltaEvento");
            }
        }
        [HttpPost]
        public ActionResult NovoEvento(Evento evento){
            if(ModelState.IsValid){
                _eventoRepositorio.AdicionarEventos(evento);
                 return RedirectToAction("Index","Home");
            }   
            else{
                ViewBag.Generos = _generoRepositorio.PegandoListaDeGeneros();
                ViewBag.CasasDeShow = _casaDeShowRepositorio.ListaCasaDeShows();
                return View("NovoEventoFormulario");
            }
        }
        [Authorize(Policy="Usuario")]
        [HttpGet]
        public IActionResult EditarEvento(int id){
            ViewBag.Generos = _generoRepositorio.PegandoListaDeGeneros();
            ViewBag.CasasDeShow = _casaDeShowRepositorio.ListaCasaDeShows();
            var editarEvento = _eventoRepositorio.BuscarEvento(id);
            return View(editarEvento);
        }
        [HttpPost]
        public IActionResult EditarEvento(Evento editarEvento){
            if(ModelState.IsValid){
                _eventoRepositorio.EditarEvento(editarEvento);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("EditarEvento");
            }
        }
        [HttpGet]
        public IActionResult RealizandoCompra(int id){
            var comprarEvento = _eventoRepositorio.BuscarEvento(id);
            return View(comprarEvento);
        }
        [HttpPost]
        public IActionResult RealizandoCompra(Evento evento,CompraEvento compra){
            int qtd = compra.QtdIngresso;
            double preco = compra.ValorCompra;
            if(ModelState.IsValid){
                if(qtd<=evento.Capacidade){
                    int cap = qtd-evento.Capacidade;
                    double compraFinal = preco*qtd;
                    _eventoRepositorio.FazerCompra(compra);
                    return RedirectToAction("Index","Home");
                }
                else{
                    return View("RealizandoCompra");    
                }
            }
            else{
                return View("RealizandoCompra");    
            }
        }
        public ActionResult DeletarEvento(int id){
            var evento = _eventoRepositorio.BuscarEvento(id);
            _eventoRepositorio.ExcluiEvento(evento);
            return RedirectToAction("Index","Home");
        }

    }
}