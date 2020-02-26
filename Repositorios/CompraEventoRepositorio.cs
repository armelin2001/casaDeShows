using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace casaDeShows.Repositorios
{
    public class CompraEventoRepositorio
    {
        private readonly ApplicationDbContextEntidades _dataBase;
        public CompraEventoRepositorio(ApplicationDbContextEntidades dataBase){
            _dataBase = dataBase;
        }
        public List<CompraEvento> HistoricoDeCompras(){
            var buscaCompra = _dataBase.CompraEventos.ToList();
            return buscaCompra;
        }
        public void FazerCompra(CompraEvento compra){
            _dataBase.CompraEventos.Add(compra);
            _dataBase.SaveChanges();
        }
    }
}