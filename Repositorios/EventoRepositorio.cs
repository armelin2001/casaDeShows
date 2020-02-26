using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace casaDeShows.Repositorios
{
    public class EventoRepositorio
    {
        private readonly ApplicationDbContextEntidades _dataBase;
        public EventoRepositorio(ApplicationDbContextEntidades dataBase){
            _dataBase = dataBase;
        }
        //Metodos para listagem de objetos
        public List<Evento> MostrarEventos(){
            return _dataBase.Eventos.ToList();
        }
        public Evento BuscarEvento(int id){
            var buscaEventoId = _dataBase.Eventos.FirstOrDefault(encontrandoEvento => encontrandoEvento.Id == id);
            return buscaEventoId; 
        }
        public void AdicionarEventos(Evento eventoAdd){
            _dataBase.Eventos.Add(eventoAdd);
            _dataBase.SaveChanges();
        }
        public void EditarEvento(Evento editaEvento){
            _dataBase.Eventos.Update(editaEvento);
            _dataBase.SaveChanges();
        }
        public void ExcluiEvento(Evento deletaEvento){
            _dataBase.Eventos.Remove(deletaEvento);
            _dataBase.SaveChanges();
        }
    }
}