using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace casaDeShows.Models
{
    public class GeneroEvento
    {
        public int Id{get;set;}
        [Required(ErrorMessage="O genero musical deve ter mais do que 3 letras")]
        [MinLength(3)]
        public string Genero{get;set;}
    }
}