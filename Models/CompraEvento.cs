using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
namespace casaDeShows.Models
{
    public class CompraEvento
    {
        public int Id{get;set;}

        public string UserId{get;set;}
        [Required]
        [Range(1,int.MaxValue,ErrorMessage="A capacidade deve ser maior que {1}")]
        public int QtdIngresso{get;set;}
        [Required(ErrorMessage="O preço do ingresso deve ser maior que 0")]
        [Range(0,double.MaxValue)]
        public double ValorCompra{get;set;}
        public int EventoId{get;set;}
        [ForeignKey("EventoId")]
        public virtual Evento Evento{get;set;}

        
    }
}