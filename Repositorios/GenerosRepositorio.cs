using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casaDeShows.Repositorios
{
    public class GenerosRepositorio
    {
        private readonly ApplicationDbContextEntidades _dataBase;
        public GenerosRepositorio(ApplicationDbContextEntidades database){
            _dataBase  = database;
        }        
        public List<GeneroEvento> MostrarGenerosEventos(){
            return _dataBase.GeneroEventos.ToList();
        }
        public GeneroEvento BuscarGeneroEvento(int id){
            var buscaGeneroEvento = _dataBase.GeneroEventos.FirstOrDefault(genero=> genero.Id == id);
            return buscaGeneroEvento;
        }
        public void AdicionarGenero(GeneroEvento genero){
            _dataBase.GeneroEventos.Add(genero);
            _dataBase.SaveChanges();
        }
        public void DeletarGenero(GeneroEvento genero){
            _dataBase.GeneroEventos.Remove(genero);
            _dataBase.SaveChanges();
        }
    }
}