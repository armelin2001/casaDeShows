using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casaDeShows.Repositorios
{
    public class CasaDeShowRepositorio
    {
        private readonly ApplicationDbContextEntidades _dataBase;
        public CasaDeShowRepositorio(ApplicationDbContextEntidades dataBase){
            _dataBase = dataBase;
        }
        public CasaDeShow BuscarCasaDeShow(int id){
            var buscaCasaDeshow = _dataBase.CasaDeShows.FirstOrDefault(casa => casa.Id == id);
            return buscaCasaDeshow;
        }
        public List<CasaDeShow> MostrarCasasDeShow(){
            return _dataBase.CasaDeShows.ToList();
        }
        public static List<CasaDeShow> GetCasa(){
            var novaListaCasas = new List<CasaDeShow>();
            return novaListaCasas;
        }
        public void AdicionarCasaDeShow(CasaDeShow casa){
            _dataBase.CasaDeShows.Add(casa);
            _dataBase.SaveChanges();
        }
        public void EditarCasaDeShow(CasaDeShow casa){
            _dataBase.CasaDeShows.Update(casa);
            _dataBase.SaveChanges();
        }
        public void DeletarCasaDeShows(CasaDeShow casa){
            _dataBase.CasaDeShows.Remove(casa);
            _dataBase.SaveChanges();
        }
    }
}