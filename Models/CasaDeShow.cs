using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace casaDeShows.Models
{
    public class CasaDeShow
    {
        public int Id{get;set;}
        [Required(ErrorMessage="A casa de shows deve ter mais do que 3 letras")]
        [MinLength(3)]
        public string NomeCasaDeShow{get;set;}
        [Required(ErrorMessage="O endereço deve ter mais do que 10 letras")]
        [MinLength(10)]
        public string Endereco{get;set;}
        public int CasaDeShowRefIdCasa{get;set;}
        public Evento evento{get;set;}
    }
}