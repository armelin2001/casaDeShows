using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using casaDeShows.Models;
using casaDeShows.Repositorios;

namespace casaDeShows.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventoRepositorio _eventoRepositorio;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, EventoRepositorio eventoRepositorio)
        {
            _logger = logger;
            _eventoRepositorio = eventoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_eventoRepositorio.MostrarEventos());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
