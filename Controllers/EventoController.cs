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
        
        [HttpGet]
        public IActionResult NovoEventoFormulario(){
            ViewBag.Generos = _generoRepositorio.GetSelectList();
                ViewBag.CasasDeShow = _casaDeShowRepositorio.GetSelectList();
            return View();
        }
        /*/public ActionResult listarCasaDeShow(){
            using (var db = new NorthwindEntities()){
                var casaDeShow = db.casaDeShow.Select(c=>new{
                        NomeCasaDeShow = c.NomeCasaDeShow
                }).ToList();
                ViewBag.casaDeShow = new MultiSelectList(casaDeShow,"NomeCasaDeShow");
                return View();
            }
        }*/

        [HttpPost]
        public ActionResult NovoEvento(Evento evento){
            if(ModelState.IsValid){
                _eventoRepositorio.AdicionarEventos(evento);
                
                return RedirectToAction();//redirecionar para uma oputra tela apos o cadastro
            }
            else{
                ViewBag.Generos = _generoRepositorio.GetSelectList();
                ViewBag.CasasDeShow = _casaDeShowRepositorio.GetSelectList();
                return View("NovoEventoFormulario");
            }
        }
        [HttpGet]
        public IActionResult EditarEvento(int id){
            var editarEvento = _eventoRepositorio.BuscarEvento(id);
            return View(editarEvento);
        }
        [HttpPost]
        public IActionResult EditarEvento(Evento editarEvento){
            if(ModelState.IsValid){
                _eventoRepositorio.EditarEvento(editarEvento);
                return RedirectToAction();//Direcionar para uma pagina onde mostre que a edição foi feita com sucesso
            }
            else{
                return View("EditarEvento");
            }
        }
        public ActionResult DeletarEvento(int id){
            var evento = _eventoRepositorio.BuscarEvento(id);
            _eventoRepositorio.DeletarEvento(evento);
            return RedirectToAction();//Avisar ao usuario que a deleççao foi feita com sucesso
        }

    }
}