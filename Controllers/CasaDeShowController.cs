using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using casaDeShows.Repositorios;
using casaDeShows.Models;
namespace casaDeShows.Controllers
{
    public class CasaDeShowController:Controller
    {   
        private readonly CasaDeShowRepositorio _casaDeShowRepositorio;
        public CasaDeShowController (CasaDeShowRepositorio casaDeShowRepositorio){
            _casaDeShowRepositorio = casaDeShowRepositorio;
        }
        [HttpGet]
        public IActionResult ListarCasasDeShow(){
            var listaDeCasas = _casaDeShowRepositorio.MostrarCasasDeShow();
            return View(listaDeCasas);
        }
        [HttpGet]
        public IActionResult NovaCasaDeShowFormulario(){
            return View();
        }
        [HttpPost]
        public ActionResult NovaCasaDeShow(CasaDeShow casa){
            if(ModelState.IsValid){
                _casaDeShowRepositorio.AdicionarCasaDeShow(casa);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("NovaCasaDeShowFormulario");
            }
        }
        [HttpGet]
        public IActionResult EditarCasaDeShow(int id){
            var editaCasaDeShow = _casaDeShowRepositorio.BuscarCasaDeShow(id);
            return View(editaCasaDeShow);
        }
        [HttpPost]
        public IActionResult EditarCasaDeShow(CasaDeShow casa){
            if(ModelState.IsValid){
                _casaDeShowRepositorio.EditarCasaDeShow(casa);
                return RedirectToAction("Index","Home");
            }
            else{
                return View("EditarCasaDeShow");
            }
        }
        public ActionResult DeletarCasaDeShow(int id){
            var casa = _casaDeShowRepositorio.BuscarCasaDeShow(id);
            _casaDeShowRepositorio.DeletarCasaDeShows(casa);
            return RedirectToAction("Index","Home");
        }
    }
}