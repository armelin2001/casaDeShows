using casaDeShows.Data;
using casaDeShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<GeneroEvento> MostrarGenerosEventos(){
            return _dataBase.GeneroEventos.ToList();
        }
        //Chamar o list de casa de show no controller
        
        //Methodos para busca de objetos 
        public Evento BuscarGeneroDoEvento(GeneroEvento idGenero){//testar em uma view para ver se conseguimos pegar um gero de evento direto
            var buscaGeneroDoEvento = _dataBase.Eventos.FirstOrDefault(encontraGenero => encontraGenero.IdGeneroDoEvento
            == idGenero);
            return buscaGeneroDoEvento;
        }
        public Evento BuscarObjetoCasaDeShow(CasaDeShow idCasaDeShow){
            var buscaObjeto = _dataBase.Eventos.FirstOrDefault(encontraObjeto => encontraObjeto.IdCasaDeShows == idCasaDeShow);
            return buscaObjeto;
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
        public void DeletarEventos(Evento deletaEvento){
            _dataBase.Eventos.Remove(deletaEvento);
            _dataBase.SaveChanges();
        }
    }
}