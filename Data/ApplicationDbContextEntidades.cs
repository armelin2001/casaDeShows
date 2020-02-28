using System;
using System.Collections.Generic;
using System.Text;
using casaDeShows.Models;
using Microsoft.EntityFrameworkCore;
namespace casaDeShows.Data
{
    /*para consequir subir as entidades para o bd e necessario dar os dois comandos a baixo
    /dotnet ef database update --context ApplicationDbContextEntidades
    O comando a cima vai subir as migrations relacionadas a esta classe,
    logo sera necessario fazer um, dotnet ef database update --context applicationDbContext
    para podermos subir a classe que corresponde ao identity frame work*/
    public class ApplicationDbContextEntidades:DbContext
    {
        public DbSet<Evento> Eventos{get;set;}
        public DbSet<CasaDeShow> CasaDeShows{get;set;}
        public DbSet<GeneroEvento> GeneroEventos{get;set;}
        public DbSet<CompraEvento> CompraEventos{get;set;}
        
        public ApplicationDbContextEntidades(DbContextOptions<ApplicationDbContextEntidades> options):base(options){

        }
    }
}