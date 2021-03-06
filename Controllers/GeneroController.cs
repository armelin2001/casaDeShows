using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;
using Microsoft.AspNetCore.Authorization;
namespace casaDeShows.Controllers
{
    public class GeneroController:Controller
    {
        private readonly GenerosRepositorio _generoRepositorio;
        public GeneroController(GenerosRepositorio generosRepositorio){
            _generoRepositorio = generosRepositorio;
        }
        [Authorize(Policy="Admin")]
        [HttpGet]
        public IActionResult ListarGeneros(){
            var listaDeGeneros =  _generoRepositorio.MostrarGenerosEventos();
            return View(listaDeGeneros);
        }
        [Authorize(Policy="Admin")]
        [HttpGet]
        public IActionResult NovoGeneroFormulario(){
            return View();
        }
        [HttpPost]
        public IActionResult NovoGenero(GeneroEvento novoGenero){
            if(ModelState.IsValid){
                _generoRepositorio.AdicionarGenero(novoGenero);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("NovoGeneroFormulario");
            }   
        }
        public IActionResult DeletarGenero(int id){
            var genero =  _generoRepositorio.BuscarGeneroEvento(id);
            _generoRepositorio.DeletarGenero(genero);
            return RedirectToAction("Index","Home");
        }
        [Authorize(Policy="Admin")]
        [HttpGet]
        public IActionResult EditarGenero(int id){
            var buscarGenero = _generoRepositorio.BuscarGeneroEvento(id);
            return View(buscarGenero);
        }
        [HttpPost]
        public IActionResult EditarGenero(GeneroEvento genero){
            if(ModelState.IsValid){
                _generoRepositorio.Editar(genero);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("EditarGenero");
            }
        }
    }
}