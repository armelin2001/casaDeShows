using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using casaDeShows.Models;
using casaDeShows.Repositorios;
using Microsoft.AspNetCore.Identity;

namespace casaDeShows.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventoRepositorio _eventoRepositorio;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, EventoRepositorio eventoRepositorio, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _eventoRepositorio = eventoRepositorio;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var lista = _eventoRepositorio.MostrarEventos();
            return View(lista);
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
