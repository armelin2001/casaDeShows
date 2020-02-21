using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;

namespace casaDeShows.Controllers
{
    public class GeneroController:Controller
    {
        private readonly GenerosRepositorio _generoRepositorio;
        public GeneroController(GenerosRepositorio generosRepositorio){
            _generoRepositorio = generosRepositorio;
        }
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
            return RedirectToAction();
        }
    }
}