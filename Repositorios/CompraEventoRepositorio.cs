using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace casaDeShows.Repositorios
{
    public class CompraEventoRepositorio
    {
        private readonly ApplicationDbContextEntidades _dataBase;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompraEventoRepositorio(ApplicationDbContextEntidades dataBase,IHttpContextAccessor httpContextAccessor){
            _dataBase = dataBase;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<CompraEvento> HistoricoDeCompras(){
            string UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var buscaCompra = _dataBase.CompraEventos.Include(x=> x.Evento.CasaDeShow).Where(x=>x.UserId == UserId).ToList();
            return buscaCompra;
        }
        public int ContarIngressoVendido(int idEvento){
            var QtdIngressoVendido = _dataBase.CompraEventos.Include(x=> x.Evento).Where(x=>x.Evento.Id==idEvento).Sum(x => x.QtdIngresso);
            return QtdIngressoVendido;
        }
        public void FazerCompra(CompraEvento compra){
            _dataBase.CompraEventos.Add(compra);
            _dataBase.SaveChanges();
        }
    }
}