using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace casaDeShows.Models
{
    public class Evento
    {
        public int Id{get;set;}
        public CasaDeShow IdCasaDeShows{get;set;}//Criar um um metodo em que vai fazer uma consulta no bd para listar todas as casas de shows existentes
        public GeneroEvento IdGeneroDoEvento{get;set;}//fazer a mesma logica da casa de eventos
        
        [Required(ErrorMessage="O nome do evento deve ter mais de 3 letras")]
        [MinLength(3)]
        public string NomeDoEvento{get;set;}   
        
        public int Capacidade{get;set;}
        [Required(ErrorMessage="O preço do ingresso deve ser maior que 0")]
        [Range(0,double.MaxValue)]
        public double PrecoIngresso{get;set;}
        
        [Required(ErrorMessage="Selecione uma data para o evento")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name="Data do Evento")]
        public DateTime DataEvento{get;set;}
    }
}