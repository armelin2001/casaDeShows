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
        public int QtdIngresso{get;set;}
        public double ValorCompra{get;set;}

        public int? EventoId{get;set;}
        [ForeignKey("EventoId")]
        public virtual Evento Evento{get;set;}
    }
}